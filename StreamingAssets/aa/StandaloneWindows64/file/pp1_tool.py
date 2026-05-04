#!/usr/bin/env python3
"""
pp1_tool.py  -  Xenosaga Pied Piper .dat (PP archive) 추출/리패킹 툴

포맷 계층:
  .dat  = 서브-ZIP 직렬 연결 (각 파일이 독립 미니-ZIP)
  내부  = ARC\x00 아카이브 (entry 당 6바이트 헤더)
  블록  = 스크립트(entry idx=0) + GIF 이미지들(entry idx=1+)

사용법:
  extract  xenosagapp1.dat  ./out/
  repack   xenosagapp1.dat  ./out/  xenosagapp1_new.dat
  verify   xenosagapp1.dat

repack 동작:
  - 리패킹 완료 후, 출력 .dat과 같은 경로에서
    Assembly-CSharp.dll 또는 Assembly-CSharp.dll.new 를 자동 탐색
  - 발견 시 XenoPP01Canvas의 downfilechk 배열을 자동 패치

script.json 구조:
  [
    {
      "scene": 0,
      "marker": "0x1ba9",        <- 씬 마커 (수정 금지)
      "marker_pos": 46,           <- 마커 위치 (수정 금지)
      "ptr_positions": [76, 84],  <- 포인터 위치들 (수정 금지)
      "lines": ["ホアキン", ...], <- 원문 (수정 금지)
      "trans": ["호아킨", ...]    <- 번역 입력란
    },
    ...
  ]
"""

import sys, os, struct, zlib, json
from pathlib import Path

EXTRA_FIELD = b'\xfe\xca\x00\x00'
SCRIPT_ENC  = 'cp932'
TRANS_ENC   = 'utf-8'

LINE_SEPS = [
    bytes([0x1B, 0xB5, 0x00]),
    bytes([0x07, 0xB6, 0x00]),
    bytes([0x07, 0xC3, 0x00]),
    bytes([0x07, 0xD0, 0x00]),
    bytes([0x07, 0xDD, 0x00]),
]

DOWNFILECHK_ORIG = [
    (66614,18069),(24252,22126),(6824,6967),(7754,7854),(4951,4936),
    (10391,10230),(9729,9642),(13571,12275),(12377,6231),(1376,1037),
    (2291,1463),(1632,1168),(1847,1266),(480,303),(230,373),
    (12725,7254),(30210,24764),(15171,12280),(17318,13690),(10550,5972),
    (616,512),(975,713),(944,776),(2258,1453),(1777,1161),
    (750,452),(60284,59319),(14375,12764),(9524,9521),(2690,1661),
    (2472,1336),(6194,3580),(5801,3563),(9479,5278),(1850,1278),
    (3186,2063),(1410,847),(1302,654),(1332,598),(2516,1539),
    (11292,5636),(9497,9431),(1157,697),(1813,722),(2353,978),
    (4341,1330),(3953,1059),(705,572),(1525,920),(1653,850),
    (613,500),(1841,763),(1121,546),(813,622),(2593,695),
    (1629,877),(5600,2324),
]


# === 서브-ZIP 계층 ============================================================

def parse_subzips(data):
    entries, pos = [], 0
    while pos < len(data):
        p = data.find(b'PK\x03\x04', pos)
        if p == -1: break
        mod_time   = struct.unpack_from('<H', data, p+10)[0]
        mod_date   = struct.unpack_from('<H', data, p+12)[0]
        fname_len  = struct.unpack_from('<H', data, p+26)[0]
        extra_len  = struct.unpack_from('<H', data, p+28)[0]
        fname      = data[p+30:p+30+fname_len].decode('utf-8', errors='replace')
        extra_lfh  = data[p+30+fname_len:p+30+fname_len+extra_len]
        data_start = p+30+fname_len+extra_len
        dd_pos     = data.find(b'PK\x07\x08', data_start)
        crc        = struct.unpack_from('<I', data, dd_pos+4)[0]
        comp_size  = struct.unpack_from('<I', data, dd_pos+8)[0]
        uncomp_size= struct.unpack_from('<I', data, dd_pos+12)[0]
        eocd_pos   = data.find(b'PK\x05\x06', dd_pos)
        entries.append({
            'name': fname, 'start': p, 'end': eocd_pos+22,
            'mod_time': mod_time, 'mod_date': mod_date, 'extra_lfh': extra_lfh,
            'data_start': data_start, 'crc': crc,
            'comp_size': comp_size, 'uncomp_size': uncomp_size,
        })
        pos = eocd_pos + 22
    return entries

def decomp_entry(data, e):
    return zlib.decompress(data[e['data_start']:e['data_start']+e['comp_size']], -15)

def build_subzip(fname, raw_data, mod_time, mod_date, extra=EXTRA_FIELD):
    fname_b    = fname.encode('utf-8')
    crc        = zlib.crc32(raw_data) & 0xFFFFFFFF
    compressed = zlib.compress(raw_data, 6)[2:-4]
    comp_size  = len(compressed)
    uncomp_size= len(raw_data)

    lfh = struct.pack('<4sHHHHHIIIHH',
        b'PK\x03\x04', 0x0014, 0x0008, 8,
        mod_time, mod_date, 0, 0, 0,
        len(fname_b), len(extra),
    ) + fname_b + extra

    dd = struct.pack('<4sIII', b'PK\x07\x08', crc, comp_size, uncomp_size)

    cd_offset = len(lfh) + comp_size + len(dd)
    cd = struct.pack('<4sHHHHHHIIIHHHHHII',
        b'PK\x01\x02', 0x0014, 0x0014, 0x0008, 8,
        mod_time, mod_date, crc, comp_size, uncomp_size,
        len(fname_b), len(extra), 0, 0, 0, 0, 0,
    ) + fname_b + extra

    eocd = struct.pack('<4sHHHHIIH',
        b'PK\x05\x06', 0, 0, 1, 1, len(cd), cd_offset, 0,
    )
    return lfh + compressed + dd + cd + eocd


# === ARC 계층 =================================================================

def parse_arc(raw):
    if raw[:4] != b'ARC\x00': return None
    fc  = (raw[6] << 8) | raw[7]
    db  = 8 + fc * 6
    files = []
    for i in range(fc):
        b   = 8 + i * 6
        idx = (raw[b]   << 8) | raw[b+1]
        rel = (raw[b+2] << 8) | raw[b+3]
        sz  = (raw[b+4] << 8) | raw[b+5]
        files.append({'index': idx, 'offset': db+rel, 'size': sz,
                      'data': raw[db+rel:db+rel+sz]})
    return files

def build_arc(files_data, indices):
    fc = len(files_data)
    db = 8 + fc * 6
    offsets, cur = [], 0
    for d in files_data:
        offsets.append(cur)
        cur += len(d)
    filesize = db + cur
    arc = b'ARC\x00' + struct.pack('>H', filesize) + struct.pack('>H', fc)
    for i in range(fc):
        arc += struct.pack('>H', indices[i])
        arc += struct.pack('>H', offsets[i])
        arc += struct.pack('>H', len(files_data[i]))
    for d in files_data:
        arc += d
    return arc


# === 스크립트 파싱/리빌드 =====================================================

def _is_scene_marker(s, i):
    if i + 3 >= len(s): return False
    return s[i+1] == 0x1b and s[i+2] == 0xa9 and s[i+3] == 0x00

def _read_str(script, ptr):
    nul = script.find(b'\x00\x00', ptr)
    chunk = script[ptr:nul] if nul != -1 else script[ptr:]
    try:    return chunk.decode(SCRIPT_ENC)
    except: return chunk.decode(SCRIPT_ENC, errors='replace')

def parse_script(script):
    ptrs = []
    for i in range(len(script) - 4):
        if _is_scene_marker(script, i):
            pos = i + 4
            if pos + 2 <= len(script):
                v = script[pos] | (script[pos+1] << 8)
                if v > 0: ptrs.append(v)
                pos += 2
            while pos + 3 <= len(script):
                if any(script[pos:pos+3] == s for s in LINE_SEPS):
                    pos += 3
                    if pos + 2 <= len(script):
                        v = script[pos] | (script[pos+1] << 8)
                        if v > 0: ptrs.append(v)
                        pos += 2
                else: break
    if not ptrs: return [], 0
    text_start = min(ptrs)

    def valid(v): return text_start <= v < len(script)

    scenes = []
    for i in range(min(text_start, len(script)) - 4):
        if _is_scene_marker(script, i):
            marker_word = script[i] | (script[i+1] << 8)
            scene = {'marker': f'0x{marker_word:04x}', 'marker_pos': i,
                     'ptr_positions': [], 'lines': []}
            pos = i + 4
            if pos + 2 <= len(script):
                v = script[pos] | (script[pos+1] << 8)
                if valid(v):
                    scene['ptr_positions'].append(pos)
                    scene['lines'].append(_read_str(script, v))
                pos += 2
            while pos + 3 <= len(script):
                if any(script[pos:pos+3] == s for s in LINE_SEPS):
                    pos += 3
                    if pos + 2 <= len(script):
                        v = script[pos] | (script[pos+1] << 8)
                        if valid(v):
                            scene['ptr_positions'].append(pos)
                            scene['lines'].append(_read_str(script, v))
                        pos += 2
                else: break
            if scene['ptr_positions']:
                scenes.append(scene)
    return scenes, text_start

def scenes_to_json(scenes):
    return [
        {
            'scene':         idx,
            'marker':        s['marker'],
            'marker_pos':    s['marker_pos'],
            'ptr_positions': s['ptr_positions'],
            'lines':         s['lines'],
            'trans':         [''] * len(s['lines']),
        }
        for idx, s in enumerate(scenes)
    ]

def rebuild_script(orig_script, json_entries):
    _, text_start = parse_script(orig_script)
    if text_start == 0: return bytes(orig_script)

    orig_pool = {}
    pos = text_start
    while pos < len(orig_script) - 1:
        nul = orig_script.find(b'\x00\x00', pos)
        if nul == -1:
            orig_pool[pos] = orig_script[pos:] + b'\x00\x00'
            break
        orig_pool[pos] = orig_script[pos:nul+2]
        pos = nul + 2

    ptr_to_new = {}
    for entry in json_entries:
        for ptr_pos, orig_line, trans_line in zip(
                entry['ptr_positions'], entry['lines'],
                entry.get('trans', [''] * len(entry['lines']))):
            ptr_val = orig_script[ptr_pos] | (orig_script[ptr_pos+1] << 8)
            text    = trans_line.strip() if trans_line.strip() else orig_line
            try:    encoded = text.encode(SCRIPT_ENC) + b'\x00\x00'
            except: encoded = text.encode(TRANS_ENC)  + b'\x00\x00'
            ptr_to_new[ptr_val] = encoded

    new_pool    = bytearray()
    new_ptr_map = {}
    for old_ptr in sorted(orig_pool.keys()):
        new_ptr_map[old_ptr] = text_start + len(new_pool)
        new_pool += ptr_to_new.get(old_ptr, orig_pool[old_ptr])

    new_script = bytearray(orig_script[:text_start]) + new_pool

    for entry in json_entries:
        for ptr_pos in entry['ptr_positions']:
            old_ptr = orig_script[ptr_pos] | (orig_script[ptr_pos+1] << 8)
            if old_ptr in new_ptr_map:
                new_ptr = new_ptr_map[old_ptr]
                new_script[ptr_pos]   = new_ptr & 0xFF
                new_script[ptr_pos+1] = (new_ptr >> 8) & 0xFF

    return bytes(new_script)


# === 헬퍼 ====================================================================

def dat_to_dir(fname):
    return fname.rsplit('.', 1)[0].replace('.', '_')

def _is_image(data):
    return (data[:6] in (b'GIF89a', b'GIF87a') or data[:4] == b'\x89PNG')


# === dll 패치 =================================================================

def _find_dll_pairs(dll_bytes):
    """XenoPP01Canvas의 downfilechk 57쌍 오프셋 탐색. 실패 시 None 반환."""
    anchor = (struct.pack('<i', 66614) + b'\x9E\x25\x17\x20' +
              struct.pack('<i', 18069) + b'\x9E')
    base = dll_bytes.find(anchor)
    if base == -1:
        return None

    pairs = []
    p = base - 0x10
    search_end = base + 0x1000
    while len(pairs) < 57:
        p = dll_bytes.find(b'\x25\x16\x20', p, search_end)
        if p == -1: break
        unc_off = p + 3
        cmp_off = p + 11
        if cmp_off + 4 > len(dll_bytes): break
        unc_val = struct.unpack_from('<i', dll_bytes, unc_off)[0]
        cmp_val = struct.unpack_from('<i', dll_bytes, cmp_off)[0]
        mid     = dll_bytes[unc_off+4:cmp_off]
        fid     = len(pairs)
        if (mid == b'\x9e\x25\x17\x20' and
                unc_val == DOWNFILECHK_ORIG[fid][0] and
                cmp_val == DOWNFILECHK_ORIG[fid][1]):
            pairs.append({'fid': fid, 'unc_off': unc_off, 'cmp_off': cmp_off})
        p += 1

    return pairs if len(pairs) == 57 else None

def patch_dll(dat_path, dll_path):
    """dat의 실제 크기로 dll의 downfilechk를 패치. 변경 없으면 아무것도 안 함."""
    dat   = open(dat_path,  'rb').read()
    dll   = bytearray(open(dll_path, 'rb').read())
    subs  = parse_subzips(dat)
    pairs = _find_dll_pairs(bytes(dll))

    if pairs is None:
        print(f'  [dll] downfilechk 위치를 찾을 수 없음 (PP01 전용 dll이 아님?): {dll_path}')
        return

    changed = []
    for i, s in enumerate(subs[:57]):  # se_SH.dat(fid=57)는 별도 테이블
        orig_unc, orig_blk = DOWNFILECHK_ORIG[i]
        act_unc  = s['uncomp_size']
        act_blk  = s['end'] - s['start']
        if act_unc != orig_unc or act_blk != orig_blk:
            changed.append((i, orig_unc, orig_blk, act_unc, act_blk))

    if not changed:
        print(f'  [dll] 변경 없음: {os.path.basename(dll_path)}')
        return

    for fid, orig_unc, orig_blk, act_unc, act_blk in changed:
        p = pairs[fid]
        struct.pack_into('<i', dll, p['unc_off'], act_unc)
        struct.pack_into('<i', dll, p['cmp_off'], act_blk)
        print(f'  [dll] fid={fid:2d} uncomp {orig_unc}->{act_unc}  블록 {orig_blk}->{act_blk}')

    open(dll_path, 'wb').write(dll)
    print(f'  [dll] 패치 완료: {os.path.basename(dll_path)}')

def find_and_patch_dll(dat_out_path):
    """출력 dat과 같은 경로에서 dll을 찾아 패치."""
    out_dir = os.path.dirname(os.path.abspath(dat_out_path))
    candidates = ['Assembly-CSharp.dll.new', 'Assembly-CSharp.dll']
    for name in candidates:
        dll_path = os.path.join(out_dir, name)
        if os.path.exists(dll_path):
            print(f'\ndll 발견: {dll_path}')
            patch_dll(dat_out_path, dll_path)
            return
    print('\n[dll] 같은 경로에 Assembly-CSharp.dll(.new) 없음 - dll 패치 건너뜀')


# === extract =================================================================

def cmd_extract(dat_path, out_dir):
    data    = open(dat_path, 'rb').read()
    subzips = parse_subzips(data)
    os.makedirs(out_dir, exist_ok=True)

    for sub in subzips:
        raw      = decomp_entry(data, sub)
        arc_name = dat_to_dir(sub['name'])
        arc_dir  = os.path.join(out_dir, arc_name)
        os.makedirs(arc_dir, exist_ok=True)

        arc_files = parse_arc(raw)
        if arc_files is None:
            out_path = os.path.join(arc_dir, sub['name'])
            open(out_path, 'wb').write(raw)
            print(f"  {sub['name']:25s} -> {arc_name}/{sub['name']} (raw)")
            continue

        has_script = False
        img_count  = 0
        for af in arc_files:
            if _is_image(af['data']):
                ext = 'png' if af['data'][:4] == b'\x89PNG' else 'gif'
                open(os.path.join(arc_dir, f"img_{af['index']}.{ext}"), 'wb').write(af['data'])
                img_count += 1
            else:
                scenes, text_start = parse_script(af['data'])
                if scenes:
                    json_path = os.path.join(arc_dir, 'script.json')
                    json.dump(scenes_to_json(scenes), open(json_path,'w',encoding='utf-8'),
                              ensure_ascii=False, indent=2)
                    has_script = True
                else:
                    open(os.path.join(arc_dir, f"block_{af['index']}.bin"), 'wb').write(af['data'])

        marker = (' + script.json' if has_script else '')
        print(f"  {sub['name']:25s} -> {arc_name}/  ({img_count} img{marker})")

    print(f"\n총 {len(subzips)}개 파일 -> {out_dir}/")


# === repack ==================================================================

def cmd_repack(orig_dat_path, mod_dir, out_dat_path):
    orig    = open(orig_dat_path, 'rb').read()
    orig_sz = len(orig)
    subzips = parse_subzips(orig)
    payload = bytearray()

    for sub in subzips:
        raw_orig = decomp_entry(orig, sub)
        arc_name = dat_to_dir(sub['name'])
        arc_dir  = os.path.join(mod_dir, arc_name)

        arc_files = parse_arc(raw_orig)
        if arc_files is None or not os.path.isdir(arc_dir):
            payload.extend(orig[sub['start']:sub['end']])
            print(f"  kept (no arc): {sub['name']}")
            continue

        new_blocks  = []
        new_indices = []
        changed     = False

        for af in arc_files:
            new_data = None
            if _is_image(af['data']):
                for ext in ('gif', 'png', 'GIF', 'PNG'):
                    p = os.path.join(arc_dir, f"img_{af['index']}.{ext}")
                    if os.path.exists(p):
                        new_data = open(p, 'rb').read()
                        break
            else:
                json_path = os.path.join(arc_dir, 'script.json')
                bin_path  = os.path.join(arc_dir, f"block_{af['index']}.bin")
                if os.path.exists(json_path):
                    entries  = json.load(open(json_path, encoding='utf-8'))
                    new_data = rebuild_script(af['data'], entries)
                elif os.path.exists(bin_path):
                    new_data = open(bin_path, 'rb').read()

            if new_data is None:
                new_data = af['data']
            changed = changed or (new_data != af['data'])
            new_blocks.append(new_data)
            new_indices.append(af['index'])

        if changed:
            new_arc = build_arc(new_blocks, new_indices)
            subzip  = build_subzip(sub['name'], new_arc,
                                   sub['mod_time'], sub['mod_date'], sub['extra_lfh'])
            print(f"  modified: {sub['name']}")
        else:
            subzip = orig[sub['start']:sub['end']]
            print(f"  kept    : {sub['name']}")

        payload.extend(subzip)

    result = bytes(payload) + b'\x00' * max(0, orig_sz - len(payload))
    open(out_dat_path, 'wb').write(result)
    print(f"\n출력: {out_dat_path}  ({len(result)} bytes)")
    print("크기 일치 ✓" if len(result) == orig_sz else f"크기 불일치 ✗  diff={len(result)-orig_sz}")

    # dll 자동 패치
    find_and_patch_dll(out_dat_path)


# === verify ==================================================================

def cmd_verify(orig_dat_path):
    import tempfile
    orig = open(orig_dat_path, 'rb').read()
    with tempfile.TemporaryDirectory() as tmpdir:
        cmd_extract(orig_dat_path, tmpdir)
        out = os.path.join(tmpdir, 'repacked.dat')
        cmd_repack(orig_dat_path, tmpdir, out)
        repacked = open(out, 'rb').read()

    subs_o = parse_subzips(orig)
    subs_n = parse_subzips(repacked)
    ok = True
    print("\n=== 검증 ===")
    for eo, en in zip(subs_o, subs_n):
        if eo['crc'] != en['crc'] or eo['uncomp_size'] != en['uncomp_size']:
            print(f"  FAIL {eo['name']}: crc {eo['crc']:08X}->{en['crc']:08X}  sz {eo['uncomp_size']}->{en['uncomp_size']}")
            ok = False
        else:
            print(f"  OK   {eo['name']}")
    print("모든 파일 일치 ✓" if ok else "일부 불일치 ✗")


# === main ====================================================================

def usage():
    print(__doc__)
    sys.exit(1)

if __name__ == '__main__':
    if len(sys.argv) < 2: usage()
    cmd = sys.argv[1]
    if   cmd == 'extract' and len(sys.argv) == 4: cmd_extract(sys.argv[2], sys.argv[3])
    elif cmd == 'repack'  and len(sys.argv) == 5: cmd_repack(sys.argv[2], sys.argv[3], sys.argv[4])
    elif cmd == 'verify'  and len(sys.argv) == 3: cmd_verify(sys.argv[2])
    else: usage()
