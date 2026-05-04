#!/usr/bin/env python3
"""
pp1_tool.py  -  Xenosaga Pied Piper .dat (PP archive) 추출/리패킹 툴

포맷 계층:
  .dat  = 서브-ZIP 직렬 연결 (각 파일이 독립 미니-ZIP)
  내부  = ARC\x00 아카이브 (entry 당 6바이트 헤더)
  블록  = 스크립트(entry idx=0) + GIF 이미지들(entry idx=1+)

사용법:
  extract  xenosagapp1.dat  ./out/
  repack   xenosagapp1.dat  ./out/  xenosagapp1_new.dat  [xenosaga_charmap.json]
  verify   xenosagapp1.dat

  charmap 경로는 선택사항. 지정하면 한글 인코딩 + dll ToUnicode 패치 자동 적용.

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

EXTRA_FIELD  = b'\xfe\xca\x00\x00'
SCRIPT_ENC   = 'cp932'
TRANS_ENC    = 'utf-8'
CHARMAP_PATH = "xenosaga_charmap.json"  # xenosaga_charmap.json 경로. None이면 CP932 사용

LINE_SEPS = [
    bytes([0x1B, 0xB5, 0x00]),
    bytes([0x07, 0xB6, 0x00]),
    bytes([0x07, 0xC3, 0x00]),
    bytes([0x07, 0xD0, 0x00]),
    bytes([0x07, 0xDD, 0x00]),
    # 5403 타입 (행성 이름/챕터 제목 등 인라인 텍스트)
    bytes([0x1B, 0x76, 0x00]),
    bytes([0x1B, 0x82, 0x00]),
    bytes([0x1B, 0x8E, 0x00]),
    bytes([0x1B, 0xA8, 0x00]),
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

def _is_5403_marker(s, i):
    """5403 타입 씬 마커: 54 03 ... FF 다음에 1B XX 00 ptr 패턴"""
    if i + 1 >= len(s): return False
    return s[i] == 0x54 and s[i+1] == 0x03

def _collect_5403_ptrs(s, i):
    """5403 마커 이후 1B XX 00 ptr 패턴 수집. [(ptr_pos, ptr_val), ...]"""
    # FF 찾기 (파라미터 끝)
    pos = i + 2
    while pos < len(s) and s[pos] != 0xFF:
        pos += 1
    pos += 1  # FF 다음
    # 1B XX 00 ptr 패턴 연속 수집
    result = []
    while pos + 4 < len(s):
        if s[pos] == 0x1B and s[pos+2] == 0x00:
            ptr_pos = pos + 3
            ptr_val = s[ptr_pos] | (s[ptr_pos+1] << 8)
            result.append((ptr_pos, ptr_val))
            pos += 5
        else:
            break
    return result

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
        elif _is_5403_marker(script, i):
            for ptr_pos, ptr_val in _collect_5403_ptrs(script, i):
                if ptr_val > 0: ptrs.append(ptr_val)
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
        elif _is_5403_marker(script, i):
            ptrs_5403 = _collect_5403_ptrs(script, i)
            if ptrs_5403:
                scene = {'marker': '0x5403', 'marker_pos': i,
                         'ptr_positions': [], 'lines': []}
                for ptr_pos, ptr_val in ptrs_5403:
                    if valid(ptr_val):
                        scene['ptr_positions'].append(ptr_pos)
                        scene['lines'].append(_read_str(script, ptr_val))
                if scene['ptr_positions']:
                    scenes.append(scene)
    # text_start 이전의 인라인 텍스트 블록 수집 (포인터 없이 바이트코드에 직접 박힌 것)
    i = 0
    while i < text_start - 1:
        if script[i] == 0x00 and i+1 < text_start:
            b = script[i+1]
            if (0x81 <= b <= 0x9F) or (0xE0 <= b <= 0xEA):
                start = i + 1
                nul = script.find(b'\x00\x00', start)
                if nul != -1 and nul < text_start:
                    chunk = script[start:nul]
                    try:
                        txt2 = chunk.decode(SCRIPT_ENC)
                        if len(txt2) >= 2:
                            scenes.append({
                                'marker':        'inline',
                                'marker_pos':    start,
                                'ptr_positions': [],
                                'lines':         [txt2],
                                '_inline_start': start,
                                '_inline_end':   nul + 2,
                                '_inline_size':  nul - start,
                            })
                        i = nul + 1
                        continue
                    except: pass
        i += 1

    return scenes, text_start

def scenes_to_json(scenes):
    result = []
    for idx, s in enumerate(scenes):
        entry = {
            'scene':         idx,
            'marker':        s['marker'],
            'marker_pos':    s['marker_pos'],
            'ptr_positions': s['ptr_positions'],
            'lines':         s['lines'],
            'trans':         [''] * len(s['lines']),
        }
        if s['marker'] == 'inline':
            entry['_inline_start'] = s['_inline_start']
            entry['_inline_size']  = s['_inline_size']
        result.append(entry)
    return result


# === charmap 인코딩 ==========================================================

_CHARMAP = None  # {char: (b1, b2)}

def _load_charmap(charmap_path):
    """xenosaga12dsk.txt 기반 charmap JSON 로드."""
    global _CHARMAP
    if _CHARMAP is not None:
        return
    import json
    data = json.load(open(charmap_path, encoding='utf-8'))
    _CHARMAP = {ch: tuple(bs) for ch, bs in data['char_to_sjis'].items()}

def encode_text(text, charmap_path=None):
    """
    번역문을 스크립트 바이트로 인코딩.
    - charmap_path 지정 시: charmap 기반 인코딩 (한글 → SJIS 한자 슬롯)
    - 없으면: CP932 인코딩
    텍스트 끝에\x00\x00 종료자 포함.

    인코딩 우선순위:
      1. ASCII 문자(0x20~0x7E): 1바이트 그대로 (\x00 충돌 방지)
      2. charmap에 있는 문자: charmap SJIS 2바이트
      3. 그 외: CP932 인코딩
    """
    if charmap_path:
        _load_charmap(charmap_path)
        result = bytearray()
        for ch in text:
            code = ord(ch)
            if 0x20 <= code <= 0x7E:
                # ASCII: 1바이트 직접 (\x00 prefix 없음)
                result.append(code)
            elif ch in _CHARMAP:
                b1, b2 = _CHARMAP[ch]
                result.append(b1)
                result.append(b2)
            else:
                # charmap에 없는 문자는 CP932로 폴백
                try:
                    result.extend(ch.encode('cp932'))
                except:
                    pass  # 인코딩 불가 문자는 스킵
        return bytes(result) + b'\x00\x00'
    else:
        try:    return text.encode(SCRIPT_ENC) + b'\x00\x00'
        except: return text.encode(TRANS_ENC)  + b'\x00\x00'

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
            ptr_val  = orig_script[ptr_pos] | (orig_script[ptr_pos+1] << 8)
            has_trans = trans_line.strip(' \t\n\r') != ''
            # 이미 번역이 있는 ptr_val은 덮어쓰지 않음
            # (같은 ptr을 여러 씬이 공유할 때 번역 있는 쪽 우선)
            if ptr_val in ptr_to_new and not has_trans:
                continue
            text    = trans_line.strip(' \t\n\r') if has_trans else orig_line
            encoded = encode_text(text, CHARMAP_PATH)
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

        # inline 타입: 원본 위치에 in-place 패치 (크기 고정)
        if entry.get('marker') == 'inline' and entry.get('trans') and entry['trans'][0].strip('\n\r\t '):
            inline_start = entry['_inline_start']
            inline_size  = entry['_inline_size']
            encoded = encode_text(entry['trans'][0], CHARMAP_PATH)[:-2]  # null-null 제외
            # 크기 맞춤: 반드시 inline_size 바이트가 되어야 함
            PAD = b'\x81\x40'  # 전각공백 (2바이트)
            if len(encoded) < inline_size:
                # 앞에 전각공백 패딩 (2바이트 단위)
                needed = inline_size - len(encoded)
                pad_count = needed // 2  # 전각공백 개수
                encoded = PAD * pad_count + encoded
            if len(encoded) < inline_size:
                # 홀수 부족분: 뒤에 0x00 패딩
                encoded = encoded + b'\x00' * (inline_size - len(encoded))
            encoded = encoded[:inline_size]  # 길면 자르기
            assert len(encoded) == inline_size, f'inline 크기 오류: {len(encoded)} != {inline_size}'
            # bytearray 직접 인덱스 대입 (슬라이스 대입 금지 - 크기 변경 방지)
            for bi, bv in enumerate(encoded):
                new_script[inline_start + bi] = bv

    return bytes(new_script)


# === 헬퍼 ====================================================================

def dat_to_dir(fname):
    return fname.rsplit('.', 1)[0].replace('.', '_')

def _is_image(data):
    return (data[:6] in (b'GIF89a', b'GIF87a') or data[:4] == b'\x89PNG')


# === dll 패치 =================================================================

def _find_dll_pairs(dll_bytes):
    """
    XenoPP01Canvas의 downfilechk 57쌍 오프셋 탐색.
    앵커: fid=0의 unc/cmp가 원본값이면 빠르게 찾고,
    이미 패치된 경우 stfld downfilechk 직전 패턴으로 탐색.
    실패 시 None 반환.
    """
    # 앵커 1: 원본 fid=0 값으로 빠르게 찾기
    anchor = (struct.pack('<i', 66614) + b'\x9E\x25\x17\x20' +
              struct.pack('<i', 18069) + b'\x9E')
    base = dll_bytes.find(anchor)

    # 앵커 2: 원본값이 바뀐 경우 - stfld downfilechk(0x7D 필드토큰) 이전
    # 패턴만으로 57개 연속 블록 탐색
    if base == -1:
        # 25 16 20 [4B] 9E 25 17 20 [4B] 9E 패턴이 연속 57개 나타나는 위치
        p = 0
        while p < len(dll_bytes):
            p = dll_bytes.find(b'\x25\x16\x20', p)
            if p == -1: break
            # 여기서 시작해서 57쌍 패턴 확인
            cnt = 0
            pp = p
            while cnt < 57:
                unc_off = pp + 3
                cmp_off = pp + 11
                if cmp_off + 4 > len(dll_bytes): break
                mid = dll_bytes[unc_off+4:cmp_off]
                if mid != b'\x9e\x25\x17\x20': break
                end_b = dll_bytes[cmp_off+4]
                if end_b != 0x9E: break
                cnt += 1
                # 다음 쌍
                npp = dll_bytes.find(b'\x25\x16\x20', pp+13, pp+50)
                if npp == -1: break
                pp = npp
            if cnt == 57:
                base = p - 3  # 25 16 20 앞 (실제론 필요없고 p를 시작점으로)
                base = p
                break
            p += 1
        if base == -1:
            return None

    pairs = []
    p = base if dll_bytes[base:base+3] == b'\x25\x16\x20' else base - 0x10
    search_end = p + 0x1000
    while len(pairs) < 57:
        p = dll_bytes.find(b'\x25\x16\x20', p, search_end)
        if p == -1: break
        unc_off = p + 3
        cmp_off = p + 11
        if cmp_off + 4 > len(dll_bytes): break
        mid = dll_bytes[unc_off+4:cmp_off]
        # 값 검증 없이 패턴 구조만으로 수락
        if mid == b'\x9e\x25\x17\x20':
            pairs.append({'fid': len(pairs), 'unc_off': unc_off, 'cmp_off': cmp_off})
        p += 1

    return pairs if len(pairs) == 57 else None

# ToUnicode.table 앵커: table[1]=1, table[2]=2, ... table[19]=19
_TOUNICODE_TABLE_ANCHOR = b''.join(__import__('struct').pack('<H', i) for i in range(1, 20))
_TOUNICODE_TABLE_BASE   = None

def _find_tounicode_table(dll_bytes):
    global _TOUNICODE_TABLE_BASE
    if _TOUNICODE_TABLE_BASE is not None:
        return _TOUNICODE_TABLE_BASE
    p = 0
    while True:
        p = dll_bytes.find(_TOUNICODE_TABLE_ANCHOR, p)
        if p == -1: return None
        base = p - 2  # table[0]=0 앞에
        if dll_bytes[base:base+2] == b'\x00\x00':
            # 검증: table[0xA1]=65377(반각카나)
            va1 = struct.unpack_from('<H', dll_bytes, base + 0xA1*2)[0]
            if va1 == 65377:
                _TOUNICODE_TABLE_BASE = base
                return base
        p += 1

def _patch_tounicode(dll, charmap_path):
    """
    ToUnicode.table에 charmap 매핑 적용.
    단, 실제 게임 스크립트에서 사용 중인 SJIS 코드는 건드리지 않음.
    """
    import json
    base = _find_tounicode_table(bytes(dll))
    if base is None:
        print('  [dll] ToUnicode.table 위치를 찾을 수 없음')
        return False
    data = json.load(open(charmap_path, encoding='utf-8'))

    # 한글 매핑만 패치 (SJIS→Unicode 중 한글 Unicode 범위인 것만)
    patched = 0
    skipped = 0
    for sjis_hex, unicode_val in data['sjis_to_unicode'].items():
        sjis = int(sjis_hex, 16)
        # 한글 완성형(AC00~D7A3)만 패치, 나머지는 원본 유지
        if not (0xAC00 <= unicode_val <= 0xD7A3):
            skipped += 1
            continue
        offset = base + sjis * 2
        if offset + 2 > len(dll): continue
        struct.pack_into('<H', dll, offset, unicode_val)
        patched += 1
    print(f'  [dll] ToUnicode.table 패치: {patched}개 슬롯 (한글만, {skipped}개 스킵)')
    return True

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
        act_unc = s['uncomp_size']
        act_blk = s['end'] - s['start']
        p = pairs[i]
        # dll 현재값과 dat 실제값 비교 (원본값 기준 X -> 이미 패치된 dll도 OK)
        dll_unc = struct.unpack_from('<i', dll, p['unc_off'])[0]
        dll_blk = struct.unpack_from('<i', dll, p['cmp_off'])[0]
        if dll_unc != act_unc or dll_blk != act_blk:
            changed.append((i, dll_unc, dll_blk, act_unc, act_blk))

    if not changed:
        print(f'  [dll] downfilechk 변경 없음')
    else:
        for fid, dll_unc, dll_blk, act_unc, act_blk in changed:
            p = pairs[fid]
            struct.pack_into('<i', dll, p['unc_off'], act_unc)
            struct.pack_into('<i', dll, p['cmp_off'], act_blk)
            print(f'  [dll] fid={fid:2d} uncomp {dll_unc}->{act_unc}  블록 {dll_blk}->{act_blk}')

    # charmap 패치
    if CHARMAP_PATH and os.path.exists(CHARMAP_PATH):
        _patch_tounicode(dll, CHARMAP_PATH)
    else:
        print(f'  [dll] CHARMAP_PATH 미설정 - ToUnicode 패치 건너뜀')

    open(dll_path, 'wb').write(dll)
    print(f'  [dll] 패치 완료: {os.path.basename(dll_path)}')

def find_and_patch_dll(dat_out_path):
    """
    출력 dat과 같은 경로에서 dll을 찾아 패치.
    우선순위:
      1. Assembly-CSharp.dll.new  -> 그대로 패치
      2. Assembly-CSharp.dll      -> .new 복사본 생성 후 패치 (원본 보존)
    """
    out_dir = os.path.dirname(os.path.abspath(dat_out_path))
    new_path  = os.path.join(out_dir, 'Assembly-CSharp.dll.new')
    orig_path = os.path.join(out_dir, 'Assembly-CSharp.dll')

    if os.path.exists(new_path):
        print(f'\ndll 발견: {new_path}')
        patch_dll(dat_out_path, new_path)
    elif os.path.exists(orig_path):
        import shutil
        shutil.copy2(orig_path, new_path)
        print(f'\ndll 발견: {orig_path}')
        print(f'  원본 보존 -> {os.path.basename(new_path)} 으로 복사 후 패치')
        patch_dll(dat_out_path, new_path)
    else:
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
    if cmd == 'extract' and len(sys.argv) == 4:
        cmd_extract(sys.argv[2], sys.argv[3])
    elif cmd == 'repack' and len(sys.argv) in (5, 6):
        if len(sys.argv) == 6:
            CHARMAP_PATH = sys.argv[5]
            print(f'charmap: {CHARMAP_PATH}')
        cmd_repack(sys.argv[2], sys.argv[3], sys.argv[4])
    elif cmd == 'verify' and len(sys.argv) == 3:
        cmd_verify(sys.argv[2])
    else:
        usage()
