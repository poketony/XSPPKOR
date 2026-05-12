#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
xhf_text_tool.py - Xenosaga Pied Piper .xhf help text extractor/rebuilder

Design:
- Extracts .xhf into a translator-friendly TXT format:
    ## TOC
    TOC:0:...
    ...
    ## SEC:1
    XREF:12:line=2
    0:...
- Rebuild is NOT an in-place patch. It rebuilds title/string blobs from scratch
  and recalculates every offset.
- The original .xhf is used as a structural template so menu jump flags are kept.
- The only hard text limit is the file format's 1-byte per-line length field:
  each encoded TOC/line text must be <= 255 bytes.

Known format:
- TOC header:
    u8 toc_count
    repeat toc_count:
        u8 section_id
        u16be absolute_text_offset
        u8 byte_length
    text strings, each followed by 00 00
- Section block, repeated until EOF:
    u8 line_count
    repeat line_count:
        u8 flag_or_xref      # FF = normal line, otherwise clickable/jump id
        u16be relative_text_offset_from_section_start
        u8 byte_length
    text strings, each followed by 00 00
"""

from __future__ import annotations

import argparse
import json
import re
import sys
from dataclasses import dataclass
from pathlib import Path
from typing import Dict, List, Optional, Tuple


@dataclass
class TocEntry:
    section_id: int
    offset: int
    length: int
    text: str


@dataclass
class LineEntry:
    flag: int
    rel_offset: int
    length: int
    text: str


@dataclass
class Section:
    number: int
    base: int
    entries: List[LineEntry]


@dataclass
class Xhf:
    toc: List[TocEntry]
    sections: List[Section]


def load_charmap(path: Optional[str]) -> Tuple[Dict[bytes, str], Dict[str, bytes]]:
    """Return (bytes_to_char, char_to_bytes)."""
    b2c: Dict[bytes, str] = {}
    c2b: Dict[str, bytes] = {}

    if not path:
        return b2c, c2b

    obj = json.loads(Path(path).read_text(encoding="utf-8"))
    table = obj.get("sjis_to_unicode", obj)

    for hex_code, uni in table.items():
        h = hex_code.upper()
        val = int(h, 16)

        # The charmap may write one-byte codes as 00A1, 0020, etc.
        # Those must be encoded as a single byte when possible.
        if len(h) <= 2:
            raw = bytes([val])
        elif len(h) == 4 and h.startswith("00") and val <= 0xFF:
            raw = bytes([val])
        else:
            raw = bytes.fromhex(h)

        ch = chr(int(uni))
        b2c[raw] = ch
        c2b.setdefault(ch, raw)

    return b2c, c2b


def decode_text(raw: bytes, b2c: Dict[bytes, str]) -> str:
    if not raw:
        return ""

    out: List[str] = []
    i = 0
    while i < len(raw):
        # Prefer explicit 2-byte custom mapping.
        if i + 2 <= len(raw) and raw[i:i+2] in b2c:
            out.append(b2c[raw[i:i+2]])
            i += 2
            continue

        # Then explicit 1-byte mapping.
        if raw[i:i+1] in b2c:
            out.append(b2c[raw[i:i+1]])
            i += 1
            continue

        # Fallback to Python Shift-JIS for unlisted standard bytes.
        b = raw[i]
        if (0x81 <= b <= 0x9F) or (0xE0 <= b <= 0xFC):
            if i + 2 > len(raw):
                out.append("�")
                i += 1
            else:
                out.append(raw[i:i+2].decode("shift_jis", errors="replace"))
                i += 2
        else:
            out.append(raw[i:i+1].decode("shift_jis", errors="replace"))
            i += 1

    return "".join(out)


def encode_text(text: str, c2b: Dict[str, bytes]) -> bytes:
    out = bytearray()
    missing: List[str] = []

    for ch in text:
        if ch in c2b:
            out += c2b[ch]
            continue

        try:
            out += ch.encode("shift_jis")
        except UnicodeEncodeError:
            missing.append(ch)

    if missing:
        uniq = "".join(dict.fromkeys(missing))
        raise ValueError(f"charmap/SJIS에 없는 문자: {uniq!r}")

    if len(out) > 0xFF:
        raise ValueError(f"한 줄 encoded 길이가 255바이트를 초과함: {len(out)} bytes / {text!r}")

    return bytes(out)


def normalize_input_text(text: str, allow_lossy_fix: bool = True) -> str:
    """Normalize translator TXT text before encoding.

    Some editors/encoding conversions corrupt Shift-JIS roman numerals into
    replacement-character sequences such as "�T", "�U", "�V". Those exact
    patterns are recoverable in this help file, so fix them by default.
    A lone U+FFFD is still treated as an error later because its original byte
    is unknowable.
    """
    if not allow_lossy_fix:
        return text
    return (text
            .replace("�T", "Ⅰ")
            .replace("�U", "Ⅱ")
            .replace("�V", "Ⅲ"))


def u16be(data: bytes, off: int) -> int:
    return (data[off] << 8) | data[off + 1]


def parse_xhf(data: bytes, b2c: Dict[bytes, str]) -> Xhf:
    if not data:
        raise ValueError("empty file")

    toc_count = data[0]
    toc_header_end = 1 + toc_count * 4
    if toc_header_end > len(data):
        raise ValueError("TOC header is truncated")

    toc: List[TocEntry] = []
    first_section_base = toc_header_end

    for i in range(toc_count):
        p = 1 + i * 4
        section_id = data[p]
        offset = u16be(data, p + 1)
        length = data[p + 3]
        raw = data[offset:offset + length]
        toc.append(TocEntry(section_id, offset, length, decode_text(raw, b2c)))
        first_section_base = max(first_section_base, offset + length + 2)

    # Section blocks begin after TOC strings. Each string is followed by 00 00.
    base = first_section_base
    sections: List[Section] = []
    sec_no = 1

    while base < len(data):
        count = data[base]
        table_end = base + 1 + count * 4
        if table_end > len(data):
            raise ValueError(f"section {sec_no} table is truncated at 0x{base:X}")

        entries: List[LineEntry] = []
        block_end = table_end

        for i in range(count):
            p = base + 1 + i * 4
            flag = data[p]
            rel = u16be(data, p + 1)
            length = data[p + 3]
            start = base + rel
            raw = data[start:start + length]
            entries.append(LineEntry(flag, rel, length, decode_text(raw, b2c)))
            block_end = max(block_end, start + length + 2)

        if block_end <= base:
            raise ValueError(f"section {sec_no} has invalid size at 0x{base:X}")

        sections.append(Section(sec_no, base, entries))
        base = block_end
        sec_no += 1

    return Xhf(toc, sections)


def write_txt(xhf: Xhf, out_path: str) -> None:
    lines: List[str] = []

    lines.append("## TOC")
    for i, ent in enumerate(xhf.toc):
        lines.append(f"TOC:{i}:{ent.text}")
    lines.append("")

    for sec in xhf.sections:
        lines.append(f"## SEC:{sec.number}")

        # Informational only. Repack recalculates offsets and preserves flags from template.
        for idx, ent in enumerate(sec.entries):
            if ent.flag != 0xFF:
                lines.append(f"XREF:{ent.flag:02X}:line={idx}")

        for idx, ent in enumerate(sec.entries):
            lines.append(f"{idx}:{ent.text}")

        lines.append("")

    Path(out_path).write_text("\n".join(lines), encoding="utf-8", newline="\n")


def parse_txt(path: str) -> Tuple[Dict[int, str], Dict[int, Dict[int, str]], Dict[int, Dict[int, int]]]:
    toc: Dict[int, str] = {}
    sections: Dict[int, Dict[int, str]] = {}
    # section_no -> line_idx -> xref flag
    xrefs: Dict[int, Dict[int, int]] = {}
    cur_sec: Optional[int] = None

    sec_re = re.compile(r"^##\s*SEC:(\d+)\s*$")
    toc_re = re.compile(r"^TOC:(\d+):(.*)$")
    line_re = re.compile(r"^(\d+):(.*)$")
    # Supported forms:
    #   XREF:12:line=2
    #   XREF:0B:line=9
    # Older diagnostic-only forms like XREF:12:00:062B are ignored because
    # they do not say which current translated line should receive the flag.
    xref_re = re.compile(r"^XREF:([0-9A-Fa-f]{1,2}):line=(\d+)\s*$")

    for raw_line in Path(path).read_text(encoding="utf-8-sig").splitlines():
        line = raw_line.rstrip("\n\r")

        if not line.strip():
            continue

        if line.startswith("## TOC"):
            cur_sec = None
            continue

        m = sec_re.match(line)
        if m:
            cur_sec = int(m.group(1))
            sections.setdefault(cur_sec, {})
            xrefs.setdefault(cur_sec, {})
            continue

        m = xref_re.match(line)
        if m and cur_sec is not None:
            flag = int(m.group(1), 16)
            line_idx = int(m.group(2))
            xrefs.setdefault(cur_sec, {})[line_idx] = flag
            continue

        if line.startswith("XREF:"):
            # Other XREF forms are comments/diagnostics.
            continue

        m = toc_re.match(line)
        if m:
            toc[int(m.group(1))] = normalize_input_text(m.group(2))
            continue

        m = line_re.match(line)
        if m and cur_sec is not None:
            sections.setdefault(cur_sec, {})[int(m.group(1))] = normalize_input_text(m.group(2))
            continue

        # Unknown metadata/comment lines are ignored on purpose.

    return toc, sections, xrefs


def build_xhf(template: Xhf, toc_text: Dict[int, str], sec_text: Dict[int, Dict[int, str]],
              c2b: Dict[str, bytes], keep_template_missing: bool = True,
              xref_text: Optional[Dict[int, Dict[int, int]]] = None,
              preserve_first_section_base: bool = True) -> bytes:
    out = bytearray()

    # ---- TOC ----
    toc_count = len(template.toc)
    out.append(toc_count)
    toc_table_pos = len(out)
    out += b"\x00" * (toc_count * 4)

    toc_records: List[Tuple[int, int, int]] = []
    for i, old in enumerate(template.toc):
        text = toc_text.get(i, old.text if keep_template_missing else "")
        enc = encode_text(text, c2b)
        offset = len(out)
        out += enc + b"\x00\x00"
        toc_records.append((old.section_id, offset, len(enc)))

    for i, (section_id, offset, length) in enumerate(toc_records):
        if offset > 0xFFFF:
            raise ValueError(f"TOC offset exceeds 16-bit range: 0x{offset:X}")
        p = toc_table_pos + i * 4
        out[p] = section_id & 0xFF
        out[p + 1] = (offset >> 8) & 0xFF
        out[p + 2] = offset & 0xFF
        out[p + 3] = length & 0xFF

    # Some game code appears to assume that the first section block starts at
    # the same absolute address as the original file, even though the TOC text
    # entries themselves have absolute offsets.  Keep that boundary stable by
    # padding after the rebuilt TOC strings when possible.  This does NOT impose
    # original-length limits on section text; it only protects the header/TOC area.
    if preserve_first_section_base and template.sections:
        target = template.sections[0].base
        if len(out) > target:
            raise ValueError(
                f"TOC area became too large: rebuilt first section would start at 0x{len(out):X}, "
                f"but original starts at 0x{target:X}. Shorten TOC titles or use --no-preserve-first-section-base."
            )
        out += b"\x00" * (target - len(out))

    # ---- Sections ----
    xref_text = xref_text or {}
    for old_sec in template.sections:
        base = len(out)

        user_lines = sec_text.get(old_sec.number, {})
        if user_lines:
            max_idx = max(user_lines.keys())
            count = max(max_idx + 1, len(old_sec.entries))
        else:
            count = len(old_sec.entries)

        if count > 0xFF:
            raise ValueError(f"SEC:{old_sec.number} line count exceeds 255: {count}")

        out.append(count)
        table_pos = len(out)
        out += b"\x00" * (count * 4)

        # If the TXT contains XREF:..:line=N lines for this section, trust those
        # translated line positions and rebuild clickable flags there.  This is
        # important when translators insert blank visual spacing lines; preserving
        # old flag indexes would make the game jump/read the wrong row.
        explicit_xrefs = xref_text.get(old_sec.number, {})
        old_flags = {i: e.flag for i, e in enumerate(old_sec.entries) if e.flag != 0xFF}

        records: List[Tuple[int, int, int]] = []
        for idx in range(count):
            if idx < len(old_sec.entries):
                old_ent = old_sec.entries[idx]
                fallback = old_ent.text
            else:
                fallback = ""

            if explicit_xrefs:
                flag = explicit_xrefs.get(idx, 0xFF)
            else:
                flag = old_flags.get(idx, 0xFF)

            text = user_lines.get(idx, fallback if keep_template_missing else "")
            enc = encode_text(text, c2b)
            rel = len(out) - base
            if rel > 0xFFFF:
                raise ValueError(f"SEC:{old_sec.number} relative offset exceeds 16-bit range: 0x{rel:X}")

            out += enc + b"\x00\x00"
            records.append((flag, rel, len(enc)))

        for idx, (flag, rel, length) in enumerate(records):
            p = table_pos + idx * 4
            out[p] = flag & 0xFF
            out[p + 1] = (rel >> 8) & 0xFF
            out[p + 2] = rel & 0xFF
            out[p + 3] = length & 0xFF

    return bytes(out)




def export_offsets(path: str, offsets: List[int], fmt: str) -> None:
    """Export rebuilt HelpInit section offsets for external patch tools."""
    if fmt == "json":
        Path(path).write_text(
            json.dumps({"sections": offsets}, ensure_ascii=False, indent=2) + "\n",
            encoding="utf-8",
            newline="\n",
        )
        return

    if fmt == "cs":
        lines = ["new int[]", "{"]
        for i, off in enumerate(offsets):
            comma = "," if i != len(offsets) - 1 else ""
            lines.append(f"    {off}{comma}")
        lines.append("};")
        Path(path).write_text("\n".join(lines) + "\n", encoding="utf-8", newline="\n")
        return

    raise ValueError(f"unknown offset format: {fmt}")

def patch_csharp_help_offsets(input_cs: str, output_cs: str, offsets: List[int]) -> None:
    text = Path(input_cs).read_text(encoding="utf-8-sig")
    arr_lines = ["new int[]", "\t\t{"]
    for i in range(0, len(offsets), 10):
        suffix = "," if i + 10 < len(offsets) else ""
        arr_lines.append("\t\t\t" + ", ".join(str(v) for v in offsets[i:i + 10]) + suffix)
    arr_lines.append("\t\t}")
    arr = "\n".join(arr_lines)

    pattern = re.compile(
        r"(public\s+virtual\s+void\s+HelpInit\s*\(\)\s*\{.*?int\s+num\s*=\s*\()"
        r"new\s+int\[\]\s*\{.*?\}"
        r"(\)\[this\.helpno\];)",
        re.DOTALL,
    )

    def repl(m: re.Match) -> str:
        return m.group(1) + arr + m.group(2)

    new_text, n = pattern.subn(repl, text, count=1)
    if n != 1:
        raise ValueError("HelpInit offset table not found or ambiguous in C# file")
    Path(output_cs).write_text(new_text, encoding="utf-8", newline="\n")

def cmd_extract(args: argparse.Namespace) -> None:
    b2c, _ = load_charmap(args.charmap)
    data = Path(args.input).read_bytes()
    xhf = parse_xhf(data, b2c)
    write_txt(xhf, args.output)
    print(f"extracted: {len(xhf.toc)} TOC entries, {len(xhf.sections)} sections -> {args.output}")


def cmd_repack(args: argparse.Namespace) -> None:
    b2c, c2b = load_charmap(args.charmap)
    template_data = Path(args.template).read_bytes()
    template = parse_xhf(template_data, b2c)
    toc_text, sec_text, xref_text = parse_txt(args.text)
    rebuilt = build_xhf(template, toc_text, sec_text, c2b, keep_template_missing=not args.blank_missing, xref_text=xref_text, preserve_first_section_base=not args.no_preserve_first_section_base)
    Path(args.output).write_bytes(rebuilt)

    # Self-parse once to catch offset/table errors before the user tests in-game.
    rebuilt_xhf = parse_xhf(rebuilt, b2c)
    print(f"rebuilt: {args.output} ({len(template_data)} -> {len(rebuilt)} bytes)")

    # The Unity C# HelpInit() does not discover section blocks dynamically.
    # It has a hard-coded absolute offset table. If section starts move,
    # patch that table too or the game will freeze when entering a help item.
    help_offsets = [0] + [sec.base for sec in rebuilt_xhf.sections]
    print("C# HelpInit offset table:")
    print("new int[]")
    print("{")
    for i in range(0, len(help_offsets), 10):
        print("    " + ", ".join(str(v) for v in help_offsets[i:i+10]) + ("," if i + 10 < len(help_offsets) else ""))
    print("}")

    if getattr(args, "export_offsets", None):
        export_offsets(args.export_offsets, help_offsets, args.offset_format)
        print(f"exported offsets: {args.export_offsets}")

    if getattr(args, "patch_cs", None):
        patch_csharp_help_offsets(args.patch_cs, args.patched_cs or args.patch_cs, help_offsets)
        print(f"patched C# offsets: {args.patched_cs or args.patch_cs}")


def cmd_check(args: argparse.Namespace) -> None:
    b2c, c2b = load_charmap(args.charmap)
    template = parse_xhf(Path(args.template).read_bytes(), b2c)
    toc_text, sec_text, xref_text = parse_txt(args.text)

    errors = 0

    def check_one(label: str, text: str) -> None:
        nonlocal errors
        try:
            enc = encode_text(text, c2b)
        except Exception as e:
            errors += 1
            print(f"[ERR] {label}: {e}")
            return
        if len(enc) > 0xFF:
            errors += 1
            print(f"[ERR] {label}: {len(enc)} bytes > 255")

    for i, old in enumerate(template.toc):
        check_one(f"TOC:{i}", toc_text.get(i, old.text))

    for sec in template.sections:
        user_lines = sec_text.get(sec.number, {})
        max_count = max((max(user_lines.keys()) + 1) if user_lines else 0, len(sec.entries))
        if max_count > 0xFF:
            errors += 1
            print(f"[ERR] SEC:{sec.number}: line count {max_count} > 255")
        for idx in range(max_count):
            fallback = sec.entries[idx].text if idx < len(sec.entries) else ""
            check_one(f"SEC:{sec.number}:{idx}", user_lines.get(idx, fallback))

    if errors:
        print(f"check failed: {errors} error(s)")
        sys.exit(1)
    print("check ok")


def main() -> None:
    ap = argparse.ArgumentParser(description="Extract/rebuild Xenosaga Pied Piper .xhf help files.")
    sub = ap.add_subparsers(dest="cmd", required=True)

    p = sub.add_parser("extract", help="extract .xhf to translator-friendly .txt")
    p.add_argument("input")
    p.add_argument("output")
    p.add_argument("--charmap", default=None, help="xenosaga_charmap.json")
    p.set_defaults(func=cmd_extract)

    p = sub.add_parser("repack", help="rebuild .xhf from .txt; all offsets are recalculated")
    p.add_argument("template", help="original .xhf used as structure template")
    p.add_argument("text", help="translated txt")
    p.add_argument("output")
    p.add_argument("--charmap", required=True, help="xenosaga_charmap.json")
    p.add_argument("--blank-missing", action="store_true",
                   help="blank entries missing from txt instead of copying template text")
    p.add_argument("--no-preserve-first-section-base", action="store_true",
                   help="do not pad the TOC area to keep the original first section offset")
    p.add_argument("--patch-cs", help="patch the hard-coded HelpInit offset table in a decompiled XenoPPxxCanvas.cs file")
    p.add_argument("--patched-cs", help="output path for patched C#; defaults to overwriting --patch-cs")
    p.add_argument("--export-offsets", help="write rebuilt HelpInit section offsets to a separate file")
    p.add_argument("--offset-format", choices=["json", "cs"], default="json",
                   help="format for --export-offsets; default: json")
    p.set_defaults(func=cmd_repack)

    p = sub.add_parser("check", help="validate txt against charmap and format limits")
    p.add_argument("template")
    p.add_argument("text")
    p.add_argument("--charmap", required=True, help="xenosaga_charmap.json")
    p.set_defaults(func=cmd_check)

    args = ap.parse_args()
    args.func(args)


if __name__ == "__main__":
    main()
