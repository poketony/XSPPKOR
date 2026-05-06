#!/usr/bin/env python3
"""Xenosaga Pied Piper block_0.bin script parser core v4.

Design goals:
- Use XScript.cs VM opcodes for normal extraction.
- Keep speaker/name pointers separate from dialogue pointers.
- Never silently drop plausible raw CP932 strings: unresolved strings are appended as
  raw_rescue scenes and marked for manual review.
"""
from __future__ import annotations
from collections import Counter
import json, sys, pathlib

SCRIPT_ENC = 'cp932'

# opcode -> bytes after opcode. Based on Assembly-CSharp/XScript.cs Scr* GetScrByte/GetScrShort usage.
X_OP_ARG_SIZE = {
    0:7, 1:4, 2:1, 3:1, 4:2, 5:1, 6:1, 7:4,
    11:8, 12:8, 13:2, 14:0, 15:1, 16:1, 17:2, 18:2, 19:0, 20:2, 21:0,
    23:1, 24:1, 25:0, 26:4, 27:4, 28:0, 29:2, 30:2, 31:0, 32:1, 33:2,
    34:2, 35:2, 36:2, 37:2, 38:0, 39:2, 40:2, 41:2, 42:2, 43:0, 44:2,
    45:0, 46:4, 47:4, 48:2, 49:2, 50:2, 51:5, 52:1, 53:6, 54:5, 55:5,
    56:4, 57:0, 58:10, 59:4, 60:0, 61:2, 62:5, 63:1, 64:1, 65:0, 66:1,
    67:1, 68:1, 69:2, 70:7, 71:0, 72:8, 73:1, 74:2, 75:5, 76:0, 77:0,
    78:4, 79:0, 80:0, 81:0, 82:2, 83:0, 84:0, 85:4, 86:3, 87:3, 88:1,
    89:1, 90:0, 91:0, 92:0, 93:0, 94:0, 95:1, 96:1, 102:2, 104:1, 105:1,
    108:0, 109:0, 112:1, 119:7, 120:2,
}
OP_NAME = 20
OP_MSG = {4, 7, 26, 27, 36}
OP_MSG_END = {21, 31, 34, 84, 95, 102, 104, 105}
OP_CLEAR = {28}
# Conservative hard scene boundary. Do not over-split on message-end opcodes.
OP_STOP = {2, 15, 16, 29, 37, 38, 40, 41, 43, 44, 45, 46, 47, 49, 50, 52, 54, 55, 59, 71, 72, 73, 75, 84}


def u16le(b: bytes, p: int) -> int:
    return b[p] | (b[p+1] << 8)


def read_sjis_zstr(data: bytes, ptr: int) -> str | None:
    if ptr is None or ptr <= 0 or ptr >= len(data):
        return None
    nul = data.find(b'\x00\x00', ptr)
    if nul < 0 or nul <= ptr:
        return None
    chunk = data[ptr:nul]
    try:
        s = chunk.decode(SCRIPT_ENC)
    except Exception:
        return None
    if any(ord(c) < 0x20 for c in s):
        return None
    return s


def looks_like_game_text(s: str | None) -> bool:
    if not s:
        return False
    t = s.strip('\x00 \t\r\n')
    if not t:
        return False
    if len(t) == 1 and ord(t) < 0x80:
        return False
    # Half-width kana or replacement chars usually mean a pointer into the middle of SJIS bytes.
    if any('ﾀ' <= ch <= 'ﾟ' for ch in t) or '�' in t:
        return False
    allowed_punct = 'ー！？。、・「」『』【】（）〈〉《》　…―－─—↑←→↓％％／／：；,.!?()[]<>+-= '
    return any(
        ('ぁ' <= ch <= 'ん') or ('ァ' <= ch <= 'ヶ') or ('一' <= ch <= '龠') or
        ch in allowed_punct or ch.isdigit() or ('Ａ' <= ch <= 'Ｚ') or ('ａ' <= ch <= 'ｚ') or
        ('A' <= ch <= 'Z') or ('a' <= ch <= 'z')
        for ch in t
    )


def valid_text_ptr(data: bytes, ptr: int) -> bool:
    return looks_like_game_text(read_sjis_zstr(data, ptr))


def ptr_for_message_op(data: bytes, pos: int, op: int) -> tuple[int, int] | None:
    if op in (4, 20, 36):
        if pos + 2 >= len(data): return None
        return pos + 1, u16le(data, pos + 1)
    if op in (7, 26, 27):
        if pos + 4 >= len(data): return None
        return pos + 3, u16le(data, pos + 3)
    return None


def raw_strings(data: bytes) -> list[dict]:
    """Parser-free baseline: plausible CP932 strings that start at a null-null boundary."""
    out=[]; i=0
    while i < len(data)-1:
        if i == 0 or data[i-2:i] == b'\x00\x00':
            s = read_sjis_zstr(data, i)
            if looks_like_game_text(s):
                nul = data.find(b'\x00\x00', i)
                out.append({'ptr': i, 'text': s, 'end': nul + 2 if nul >= 0 else len(data)})
                i = (nul + 2) if nul >= 0 else i + 1
                continue
        i += 1
    return out


def first_text_pointer_by_vm(data: bytes) -> int | None:
    ptrs=[]; pos=0; bad_run=0
    while pos < len(data):
        op=data[pos]; size=X_OP_ARG_SIZE.get(op)
        if size is None or pos + 1 + size > len(data):
            bad_run += 1
            if ptrs and bad_run >= 12:
                break
            pos += 1; continue
        bad_run = 0
        pv = ptr_for_message_op(data, pos, op)
        if pv:
            _, ptr = pv
            if ptr > pos and valid_text_ptr(data, ptr):
                ptrs.append(ptr)
        pos += 1 + size
    return min(ptrs) if ptrs else None


def disassemble_vm_prefix(data: bytes):
    """Sequential VM disassembly of the first normal code prefix.

    Some files contain later trigger code after a string pool; those are covered by
    raw_rescue instead of guessing arbitrary code starts.
    """
    code_end = first_text_pointer_by_vm(data)
    if code_end is None:
        code_end = len(data)
    pos=0
    while pos < min(code_end, len(data)):
        op=data[pos]; size=X_OP_ARG_SIZE.get(op)
        if size is None or pos + 1 + size > len(data):
            pos += 1; continue
        yield pos, op, data[pos+1:pos+1+size]
        pos += 1 + size



def find_ptr_operand_positions(data: bytes, ptr: int) -> list[int]:
    """Find likely operand locations that contain this text pointer.

    This is used only for raw_rescue entries. It lets repack update a rescued
    string if the pointer operand can still be identified even though the code
    block was not reached by the conservative prefix disassembler.
    """
    target = bytes([ptr & 0xFF, (ptr >> 8) & 0xFF])
    out=[]
    p=0
    while True:
        p = data.find(target, p)
        if p < 0:
            break
        if p >= 1 and data[p-1] in (4, 20, 36):
            out.append(p)
        elif p >= 3 and data[p-3] in (7, 26, 27):
            out.append(p)
        p += 1
    return out

def parse_plscript_vm(data: bytes, *, rescue_raw: bool = True) -> list[dict]:
    events=[]
    for pos, op, args in disassemble_vm_prefix(data):
        if op in OP_CLEAR or op in OP_STOP:
            events.append({'kind':'boundary','pos':pos,'op':op}); continue
        if op == OP_NAME or op in OP_MSG:
            pp = ptr_for_message_op(data, pos, op)
            if not pp: continue
            ptr_pos, ptr = pp
            text = read_sjis_zstr(data, ptr)
            if not looks_like_game_text(text): continue
            events.append({'kind':'text','pos':pos,'op':op,'ptr_pos':ptr_pos,'ptr':ptr,'text':text})

    msg_counts = Counter(ev['ptr'] for ev in events if ev.get('kind')=='text' and ev['op'] in OP_MSG)
    scenes=[]; current=None

    def finish():
        nonlocal current
        if current and current['msg_positions']:
            notes=[]
            for p in current['msg_ptrs']:
                notes.append('중복 호출' if msg_counts[p] > 1 else '')
            if any(notes): current['line_notes']=notes
            scenes.append(current)
        current=None

    for ev in events:
        if ev['kind']=='boundary':
            finish(); continue
        op=ev['op']
        if op == OP_NAME:
            finish()
            current={'scene':len(scenes),'speaker_pos':ev['ptr_pos'],'speaker_ptr':ev['ptr'],
                     'msg_positions':[],'msg_ptrs':[],'speaker':ev['text'],'speaker_trans':'',
                     'lines':[],'trans':[]}
            continue
        if current is None:
            current={'scene':len(scenes),'speaker_pos':-1,'speaker_ptr':-1,
                     'msg_positions':[],'msg_ptrs':[],'speaker':'','speaker_trans':'',
                     'lines':[],'trans':[]}
        current['msg_positions'].append(ev['ptr_pos'])
        current['msg_ptrs'].append(ev['ptr'])
        current['lines'].append(ev['text'])
        current['trans'].append('')
        if op == 36:
            current.setdefault('line_notes', ['']*(len(current['lines'])-1))
            while len(current['line_notes']) < len(current['lines'])-1: current['line_notes'].append('')
            current['line_notes'].append('장소/시스템')
    finish()

    if rescue_raw:
        referenced = set()
        for sc in scenes:
            if sc.get('speaker_ptr', -1) >= 0:
                referenced.add(sc['speaker_ptr'])
            referenced.update(sc.get('msg_ptrs', []))
        missing_raw = [r for r in raw_strings(data) if r['ptr'] not in referenced]
        for r in missing_raw:
            cand_pos = find_ptr_operand_positions(data, r['ptr'])
            scenes.append({
                'scene': len(scenes),
                'speaker_pos': -1,
                'speaker_ptr': -1,
                'msg_positions': cand_pos[:1] if cand_pos else [-1],
                'msg_ptrs': [r['ptr']],
                'speaker': '',
                'speaker_trans': '',
                'lines': [r['text']],
                'trans': [''],
                'line_notes': ['원문 문자열 풀에 있으나 VM 포인터 미검출 - 확인 필요'],
                'raw_rescue': True,
                'ptr_pos_candidates': cand_pos,
            })

    for i, sc in enumerate(scenes): sc['scene']=i
    return scenes

# Backward-compatible names used by pp_tool variants.
parse_plscript = parse_plscript_vm
extract_raw_strings = raw_strings


def main(argv):
    if len(argv) < 2:
        print('usage: xscript_vm_parser_core_v4.py block_0.bin [out.json]')
        return 2
    data = pathlib.Path(argv[1]).read_bytes()
    scenes = parse_plscript_vm(data)
    if len(argv) >= 3:
        pathlib.Path(argv[2]).write_text(json.dumps(scenes, ensure_ascii=False, indent=2), encoding='utf-8')
    else:
        print(json.dumps(scenes, ensure_ascii=False, indent=2))
    return 0

if __name__ == '__main__':
    raise SystemExit(main(sys.argv))
