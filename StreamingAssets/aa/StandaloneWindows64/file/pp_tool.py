#!/usr/bin/env python3
"""
pp_tool.py  -  Xenosaga Pied Piper PP01~06 통합 툴

사용법:
  단일:
    extract      <pp번호> <dat파일>  <출력폴더>
    repack       <pp번호> <원본dat> <작업폴더> <출력dat>
    verify       <pp번호> <dat파일>

  전체 (PP01~06):
    extract_all  <dat폴더>  <출력폴더>
    repack_all   <원본dat폴더> <작업폴더> <출력폴더>

pp번호: 1~6

예시:
  python pp_tool.py extract 1 xenosagapp1.dat ./work/pp01/
  python pp_tool.py repack  1 xenosagapp1.dat ./work/pp01/ ./out/xenosagapp1_new.dat

  python pp_tool.py extract_all ./dats/ ./work/
  python pp_tool.py repack_all  ./dats/ ./work/ ./out/
    -> ./out/xenosagapp1_new.dat ~ xenosagapp6_new.dat 생성
    -> ./out/Assembly-CSharp.dll.new 한 번에 패치

CHARMAP_PATH: 파일 상단에서 설정. None이면 CP932 사용.
"""

import sys, os, struct, zlib, json
from pathlib import Path

CHARMAP_PATH        = "xenosaga_charmap.json"   # 예) 'xenosaga_charmap.json'
EXTRA_FIELD         = b'\xfe\xca\x00\x00'
SCRIPT_ENC          = 'cp932'
TRANS_ENC           = 'utf-8'
_patch_dll_on_repack = True   # repack_all 사용 시 False로 설정

# ─── downfilechk 원본값 (PP별) ────────────────────────────────────────────────

DOWNFILECHK = {
1: [
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
],
2: [
    (66506,8861),(24473,22349),(8336,8451),(6726,6805),(1872,1311),
    (3070,1906),(3740,1176),(22126,21085),(5765,5283),(10194,10098),
    (13006,11928),(12400,6257),(1330,992),(489,311),(11664,10910),
    (607,442),(230,373),(18147,10448),(31578,25497),(8999,6874),
    (6357,5034),(22278,20461),(6569,6048),(13432,12861),(9435,9411),
    (4580,2620),(2730,1896),(2791,1887),(2401,1738),(5717,3606),
    (1979,1256),(4798,2943),(5043,3139),(2761,1826),(6410,2830),
    (60,199),(120,235),(11274,11020),(11381,11064),(11292,5636),
    (9497,9431),(1157,697),(1813,722),(2353,978),(4341,1330),
    (3953,1059),(705,572),(1525,920),(1653,850),(613,500),
    (1841,763),(1121,546),(813,622),(2593,695),(1629,877),
    (5600,2324),
],
3: [
    (66554,20423),(24258,22193),(11475,11335),(10268,10339),(824,587),
    (1008,682),(1044,703),(1294,721),(1249,808),(1041,717),
    (1062,723),(1211,830),(1020,638),(2709,1806),(5799,5781),
    (16580,15145),(12400,6257),(10797,10343),(230,373),(11236,11302),
    (12488,12228),(11720,11340),(17081,9720),(19425,15206),(23468,16503),
    (5024,4844),(3123,2860),(11251,10662),(2430,1385),(900,679),
    (1459,945),(122,238),(10496,10271),(1390,805),(9463,5353),
    (2522,1585),(21830,21149),(780,567),(4810,3074),(3844,2290),
    (3791,2301),(3083,2088),(11292,5636),(9497,9431),(1110,910),
    (2746,1493),(4940,2824),(2671,1840),(14489,14029),(1157,697),
    (1813,722),(2353,978),(4341,1330),(3953,1059),(705,572),
    (1525,920),(1653,850),(613,500),(1841,763),(1121,546),
    (813,622),(2593,695),(1629,877),(5600,2324),
],
4: [
    (66538,19857),(24508,22336),(11475,11335),(10479,10389),(9919,9867),
    (11120,10821),(13740,13317),(14253,13573),(6873,6693),(19094,17531),
    (13408,6709),(1149,831),(4872,3139),(2385,1276),(838,657),
    (9151,4614),(496,410),(1451,541),(8031,4869),(2665,1691),
    (230,373),(21244,12112),(19552,16441),(3806,3831),(8,148),
    (18569,15743),(10496,7010),(10486,9881),(10661,10232),(13012,12276),
    (3089,1828),(2077,1323),(1263,791),(123,238),(11669,11128),
    (12737,12628),(11292,5636),(9497,9431),(15147,14023),(14426,13932),
    (1157,697),(1813,722),(2353,978),(4341,1330),(3953,1059),
    (705,572),(1525,920),(1653,850),(613,500),(1841,763),
    (1121,546),(813,622),(2593,695),(1629,877),(5600,2324),
],
5: [
    (66582,16365),(3170,1872),(2817,1615),(1760,1265),(7019,4329),
    (21467,19569),(10699,10711),(11165,11192),(11578,11233),(4581,4611),
    (9644,9709),(2771,1902),(1206,729),(3049,2117),(4785,2844),
    (2965,1618),(16341,15065),(13408,6709),(3565,2376),(12773,12260),
    (6203,6190),(11700,11145),(230,373),(21476,12668),(21951,18773),
    (10371,8408),(6901,6038),(6037,3934),(5739,5069),(11645,11604),
    (7110,6979),(16194,15965),(11062,10660),(11646,11717),(10666,6332),
    (3282,2240),(5009,3135),(3137,2056),(16931,16213),(10143,9769),
    (11292,5636),(9497,9431),(12780,7305),(12574,11961),(7884,4333),
    (13521,13433),(6530,6695),(1157,697),(1813,722),(2353,978),
    (4341,1330),(705,572),(1525,920),(1653,850),(613,500),
    (1841,763),(1121,546),(2593,695),(4816,2226),
],
6: [
    (66394,23950),(25518,23164),(8899,8992),(10071,10021),(12223,12260),
    (9241,9226),(157,284),(2151,1304),(7252,4275),(1711,1812),
    (8313,8269),(5284,5347),(15213,13186),(11628,10947),(9392,9475),
    (18558,18380),(1499,1368),(14428,13846),(19851,18241),(12872,6468),
    (1234,919),(11611,11513),(10940,10875),(8302,8326),(9261,9293),
    (230,373),(15842,9505),(2808,2131),(18268,14628),(5350,5186),
    (8637,6696),(504,531),(11479,11329),(123,238),(85,231),
    (11292,5636),(9497,9431),(950,642),(10282,9608),(8163,8316),
    (4413,2368),(3753,1498),(3979,2311),(508,434),(1357,1046),
    (555,434),(443,383),(555,435),(443,382),(555,435),
    (443,382),(555,436),(443,384),(580,447),(443,384),
    (557,436),(443,385),(967,799),(2756,1888),(4043,1309),
    (3823,1118),(5481,3264),(5602,3292),(9430,9458),(8506,8503),
    (9711,5518),(1157,697),(1813,722),(2353,978),(4341,1330),
    (3953,1059),(705,572),(1525,920),(1653,850),(613,500),
    (1841,763),(1121,546),(813,622),(2593,695),(1629,877),
    (4816,2226),
],
}

LINE_SEPS = [
    bytes([0x1B, 0xB5, 0x00]),
    bytes([0x07, 0xB6, 0x00]),
    bytes([0x07, 0xC3, 0x00]),
    bytes([0x07, 0xD0, 0x00]),
    bytes([0x07, 0xDD, 0x00]),
    bytes([0x1B, 0x76, 0x00]),
    bytes([0x1B, 0x82, 0x00]),
    bytes([0x1B, 0x8E, 0x00]),
    bytes([0x1B, 0xA8, 0x00]),
]


# ─── 서브-ZIP 계층 ────────────────────────────────────────────────────────────

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


# ─── ARC 계층 ─────────────────────────────────────────────────────────────────

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
        offsets.append(cur); cur += len(d)
    arc = b'ARC\x00' + struct.pack('>H', db+cur) + struct.pack('>H', fc)
    for i in range(fc):
        arc += struct.pack('>H', indices[i])
        arc += struct.pack('>H', offsets[i])
        arc += struct.pack('>H', len(files_data[i]))
    for d in files_data: arc += d
    return arc


# ─── 스크립트 파싱/리빌드 ─────────────────────────────────────────────────────

def _is_scene_marker(s, i):
    if i + 3 >= len(s): return False
    return s[i+1] == 0x1b and s[i+2] == 0xa9 and s[i+3] == 0x00

def _is_5403_marker(s, i):
    if i + 1 >= len(s): return False
    return s[i] == 0x54 and s[i+1] == 0x03

def _collect_5403_ptrs(s, i):
    pos = i + 2
    while pos < len(s) and s[pos] != 0xFF: pos += 1
    pos += 1
    result = []
    while pos + 4 < len(s):
        if s[pos] == 0x1B and s[pos+2] == 0x00:
            ptr_pos = pos + 3
            ptr_val = s[ptr_pos] | (s[ptr_pos+1] << 8)
            result.append((ptr_pos, ptr_val))
            pos += 5
        else: break
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
            for _, pv in _collect_5403_ptrs(script, i):
                if pv > 0: ptrs.append(pv)
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

    # text_start 이전 인라인 텍스트 블록
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


# ─── charmap 인코딩 ───────────────────────────────────────────────────────────

_CHARMAP = None

def _load_charmap(path):
    global _CHARMAP
    if _CHARMAP is not None: return
    data = json.load(open(path, encoding='utf-8'))
    _CHARMAP = {ch: tuple(bs) for ch, bs in data['char_to_sjis'].items()}

def encode_text(text, charmap_path=None):
    if charmap_path:
        _load_charmap(charmap_path)
        result = bytearray()
        for ch in text:
            code = ord(ch)
            if 0x20 <= code <= 0x7E:
                result.append(code)
            elif ch in _CHARMAP:
                b1, b2 = _CHARMAP[ch]
                result.append(b1); result.append(b2)
            else:
                try:    result.extend(ch.encode('cp932'))
                except: pass
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
            orig_pool[pos] = orig_script[pos:] + b'\x00\x00'; break
        orig_pool[pos] = orig_script[pos:nul+2]
        pos = nul + 2

    ptr_to_new = {}
    for entry in json_entries:
        if entry.get('marker') == 'inline': continue
        for ptr_pos, orig_line, trans_line in zip(
                entry['ptr_positions'], entry['lines'],
                entry.get('trans', [''] * len(entry['lines']))):
            ptr_val  = orig_script[ptr_pos] | (orig_script[ptr_pos+1] << 8)
            has_trans = trans_line.strip(' \t\n\r') != ''
            if ptr_val in ptr_to_new and not has_trans: continue
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
        if entry.get('marker') == 'inline':
            if entry.get('trans') and entry['trans'][0].strip(' \t\n\r'):
                inline_start = entry['_inline_start']
                inline_size  = entry['_inline_size']
                encoded = encode_text(entry['trans'][0], CHARMAP_PATH)[:-2]
                PAD = b'\x81\x40'
                if len(encoded) < inline_size:
                    needed = inline_size - len(encoded)
                    encoded = PAD * (needed // 2) + encoded
                if len(encoded) < inline_size:
                    encoded = encoded + b'\x00' * (inline_size - len(encoded))
                encoded = encoded[:inline_size]
                for bi, bv in enumerate(encoded):
                    new_script[inline_start + bi] = bv
            continue
        for ptr_pos in entry['ptr_positions']:
            old_ptr = orig_script[ptr_pos] | (orig_script[ptr_pos+1] << 8)
            if old_ptr in new_ptr_map:
                new_ptr = new_ptr_map[old_ptr]
                new_script[ptr_pos]   = new_ptr & 0xFF
                new_script[ptr_pos+1] = (new_ptr >> 8) & 0xFF

    return bytes(new_script)


# ─── dll 패치 ─────────────────────────────────────────────────────────────────

_TOUNICODE_TABLE_BASE = None

def _find_tounicode_table(dll_bytes):
    global _TOUNICODE_TABLE_BASE
    if _TOUNICODE_TABLE_BASE is not None: return _TOUNICODE_TABLE_BASE
    anchor = b''.join(struct.pack('<H', i) for i in range(1, 20))
    p = 0
    while True:
        p = dll_bytes.find(anchor, p)
        if p == -1: return None
        base = p - 2
        if dll_bytes[base:base+2] == b'\x00\x00':
            if struct.unpack_from('<H', dll_bytes, base + 0xA1*2)[0] == 65377:
                _TOUNICODE_TABLE_BASE = base
                return base
        p += 1

def _patch_tounicode(dll, charmap_path):
    base = _find_tounicode_table(bytes(dll))
    if base is None:
        print('  [dll] ToUnicode.table 위치를 찾을 수 없음'); return False
    data = json.load(open(charmap_path, encoding='utf-8'))
    patched = 0
    for sjis_hex, unicode_val in data['sjis_to_unicode'].items():
        if not (0xAC00 <= unicode_val <= 0xD7A3): continue
        sjis = int(sjis_hex, 16)
        offset = base + sjis * 2
        if offset + 2 > len(dll): continue
        struct.pack_into('<H', dll, offset, unicode_val)
        patched += 1
    print(f'  [dll] ToUnicode.table 패치: {patched}개 슬롯 (한글만)')
    return True

# IL ldc.i4 단축 opcode: 16=0, 17=1, ..., 1E=8
_LDC_I4_INLINE = {0x16:0, 0x17:1, 0x18:2, 0x19:3, 0x1A:4,
                  0x1B:5, 0x1C:6, 0x1D:7, 0x1E:8}

def _parse_pair_at(dll_bytes, p):
    """
    p 위치(25 16 ...)에서 (unc_off, cmp_off, unc_size) 파싱.
    unc 저장 방식:
      16~1E        : ldc.i4.0~8 인라인 (0바이트, 값=opcode-0x16)
      1F [unc 1B]  : ldc.i4.s  (1바이트)
      20 [unc 4B]  : ldc.i4    (4바이트)
    cmp는 항상 25 17 20 [cmp 4B LE] 형식.
    반환: (unc_off, cmp_off, unc_size) 또는 None
      unc_size=0 이면 값은 opcode에서 직접 읽음 (unc_off에 opcode 위치 저장)
    """
    op = dll_bytes[p+2]
    if op == 0x20:
        unc_off  = p + 3
        unc_size = 4
        sep_start = unc_off + 4
    elif op == 0x1F:
        unc_off  = p + 3
        unc_size = 1
        sep_start = unc_off + 1
    elif op in _LDC_I4_INLINE:
        unc_off  = p + 2   # opcode 위치 자체
        unc_size = 0
        sep_start = p + 3
    else:
        return None

    if sep_start + 5 > len(dll_bytes): return None
    sep = dll_bytes[sep_start:sep_start+4]
    cmp_off = sep_start + 4
    end = dll_bytes[cmp_off+4] if cmp_off+4 < len(dll_bytes) else 0
    if sep == b'\x9e\x25\x17\x20' and end == 0x9E:
        return unc_off, cmp_off, unc_size
    return None

def _read_unc(dll_bytes, pair):
    """pair에서 unc 값 읽기."""
    usz = pair.get('unc_size', 4)
    if usz == 4:
        return struct.unpack_from('<i', dll_bytes, pair['unc_off'])[0]
    elif usz == 1:
        return dll_bytes[pair['unc_off']]
    else:  # 0: 인라인
        return _LDC_I4_INLINE[dll_bytes[pair['unc_off']]]

def _write_unc(dll, pair, val):
    """pair에 unc 값 쓰기."""
    usz = pair.get('unc_size', 4)
    if usz == 4:
        struct.pack_into('<i', dll, pair['unc_off'], val)
    elif usz == 1:
        dll[pair['unc_off']] = val & 0xFF
    # usz==0 (인라인): 값을 바꾸려면 opcode 자체를 바꿔야 함
    # 현재는 원본 값 그대로여야 하므로 write 불필요 (verify에서만 걸림)

def _find_dll_pairs(dll_bytes, pp_num):
    """PP번호에 맞는 downfilechk 쌍 오프셋 탐색."""
    chk = DOWNFILECHK[pp_num]
    n   = len(chk)

    # 앵커: fid=0 원본값으로 빠른 탐색
    anchor = (struct.pack('<i', chk[0][0]) + b'\x9E\x25\x17\x20' +
              struct.pack('<i', chk[0][1]) + b'\x9E')
    base = dll_bytes.find(anchor)
    if base != -1:
        # anchor 앞의 25 16 [20/1F] 위치 찾기
        base = base - 3  # 25 16 20 위치

    # 원본값 변경된 경우: 패턴으로 n개 연속 탐색
    if base == -1 or dll_bytes[base:base+2] != b'\x25\x16':
        p = 0
        while p < len(dll_bytes):
            p = dll_bytes.find(b'\x25\x16', p)
            if p == -1: break
            if dll_bytes[p+2] not in (0x20, 0x1F) and dll_bytes[p+2] not in _LDC_I4_INLINE:
                p += 1; continue
            cnt, pp2 = 0, p
            while cnt < n:
                r = _parse_pair_at(dll_bytes, pp2)
                if r is None: break
                cnt += 1
                # 다음 25 16 탐색
                npp = pp2 + 1
                found = False
                while npp < pp2 + 60:
                    npp = dll_bytes.find(b'\x25\x16', npp, pp2+60)
                    if npp == -1: break
                    if dll_bytes[npp+2] in (0x20, 0x1F) or dll_bytes[npp+2] in _LDC_I4_INLINE:
                        pp2 = npp; found = True; break
                    npp += 1
                if not found: break
            if cnt == n:
                base = p; break
            p += 1
        if base == -1: return None

    pairs = []
    p = base
    search_end = base + 0x3000
    while len(pairs) < n and p < search_end:
        if dll_bytes[p:p+2] != b'\x25\x16':
            p = dll_bytes.find(b'\x25\x16', p, search_end)
            if p is None or p == -1: break
        if dll_bytes[p+2] not in (0x20, 0x1F) and dll_bytes[p+2] not in _LDC_I4_INLINE:
            p += 1; continue
        r = _parse_pair_at(dll_bytes, p)
        if r is not None:
            unc_off, cmp_off, unc_size = r
            pairs.append({'fid': len(pairs), 'unc_off': unc_off, 'cmp_off': cmp_off,
                          'unc_size': unc_size})
        p += 1

    return pairs if len(pairs) == n else None

def patch_dll(pp_num, dat_path, dll_path):
    chk  = DOWNFILECHK[pp_num]
    dat  = open(dat_path,  'rb').read()
    dll  = bytearray(open(dll_path, 'rb').read())
    subs = parse_subzips(dat)
    pairs = _find_dll_pairs(bytes(dll), pp_num)

    if pairs is None:
        print(f'  [dll] downfilechk 위치를 찾을 수 없음: {dll_path}'); return

    changed = []
    for i, s in enumerate(subs[:len(chk)]):
        act_unc = s['uncomp_size']
        act_blk = s['end'] - s['start']
        p = pairs[i]
        dll_unc = struct.unpack_from('<i', dll, p['unc_off'])[0]
        dll_blk = struct.unpack_from('<i', dll, p['cmp_off'])[0]
        if dll_unc != act_unc or dll_blk != act_blk:
            changed.append((i, dll_unc, dll_blk, act_unc, act_blk))

    if not changed:
        print(f'  [dll] downfilechk 변경 없음')
    else:
        for fid, du, db, au, ab in changed:
            struct.pack_into('<i', dll, pairs[fid]['unc_off'], au)
            struct.pack_into('<i', dll, pairs[fid]['cmp_off'], ab)
            print(f'  [dll] fid={fid:2d} uncomp {du}->{au}  블록 {db}->{ab}')

    if CHARMAP_PATH and os.path.exists(CHARMAP_PATH):
        _patch_tounicode(dll, CHARMAP_PATH)
    else:
        print('  [dll] CHARMAP_PATH 미설정 - ToUnicode 패치 건너뜀')

    open(dll_path, 'wb').write(dll)
    print(f'  [dll] 패치 완료: {os.path.basename(dll_path)}')

def find_and_patch_dll(pp_num, dat_out_path):
    global _TOUNICODE_TABLE_BASE
    _TOUNICODE_TABLE_BASE = None  # 파일마다 초기화
    out_dir  = os.path.dirname(os.path.abspath(dat_out_path))
    new_path = os.path.join(out_dir, 'Assembly-CSharp.dll.new')
    orig_path= os.path.join(out_dir, 'Assembly-CSharp.dll')
    if os.path.exists(new_path):
        print(f'\ndll 발견: {new_path}')
        patch_dll(pp_num, dat_out_path, new_path)
    elif os.path.exists(orig_path):
        import shutil
        shutil.copy2(orig_path, new_path)
        print(f'\ndll 발견: {orig_path}')
        print(f'  원본 보존 -> {os.path.basename(new_path)} 으로 복사 후 패치')
        patch_dll(pp_num, dat_out_path, new_path)
    else:
        print('\n[dll] Assembly-CSharp.dll(.new) 없음 - dll 패치 건너뜀')



# ─── pl_ dat 파싱/리빌드 ────────────────────────────────────────────────────

def _pldat_entries(b0):
    """block_0에서 엔트리 테이블 파싱. 반환: [(i, id_, abs_off, size), ...]"""
    if len(b0) < 8: return [], 0, 8
    count     = (b0[6]<<8)|b0[7]
    data_base = 8 + count*6
    if data_base > len(b0): return [], 0, 8
    entries   = []
    for i in range(count):
        base = 8 + i*6
        if base + 6 > len(b0): break
        id_  = (b0[base]  <<8)|b0[base+1]
        off  = (b0[base+2]<<8)|b0[base+3]
        size = (b0[base+4]<<8)|b0[base+5]
        abs_off = data_base + off
        entries.append((i, id_, abs_off, size))
    return entries, count, data_base

def _is_text_chunk(chunk):
    """chunk가 CP932 텍스트(null-null 구분)인지 판별."""
    if not chunk: return False
    for p in chunk.split(b'\x00\x00'):
        if not p: continue
        try: p.decode(SCRIPT_ENC)
        except: return False
    return True

def parse_pldat_block0(b0):
    """
    block_0에서 텍스트 엔트리를 JSON 형식으로 추출.
    반환: [{'entry_idx': i, 'id': id_, 'abs_off': off, 'size': size,
             'lines': [...], 'trans': [...]}, ...]
    """
    entries, count, data_base = _pldat_entries(b0)
    result = []
    for i, id_, abs_off, size in entries:
        if abs_off + size > len(b0): continue
        chunk = b0[abs_off:abs_off+size]
        if not _is_text_chunk(chunk): continue
        lines = [p.decode(SCRIPT_ENC) for p in chunk.split(b'\x00\x00') if p]
        result.append({
            'entry_idx': i,
            'id':        id_,
            'abs_off':   abs_off,
            'size':      size,
            'lines':     lines,
            'trans':     [''] * len(lines),
        })
    return result

def rebuild_pldat_block0(orig_b0, json_entries):
    """
    JSON 번역을 block_0에 반영.
    텍스트 엔트리를 in-place 패치 (크기 고정).
    번역이 원본보다 길면 잘라내고, 짧으면 뒤에 0x00 패딩.
    """
    entries, count, data_base = _pldat_entries(orig_b0)
    b0 = bytearray(orig_b0)

    entry_map = {e['entry_idx']: e for e in json_entries}

    for i, id_, abs_off, size in entries:
        if i not in entry_map: continue
        je = entry_map[i]
        if not any(t.strip(' \t\n\r') for t in je.get('trans', [])): continue

        # 번역문 인코딩
        new_lines = []
        for orig_line, trans_line in zip(je['lines'], je.get('trans', [])):
            text = trans_line.strip(' \t\n\r') if trans_line.strip(' \t\n\r') else orig_line
            encoded = encode_text(text, CHARMAP_PATH)[:-2]  # null-null 제외
            new_lines.append(encoded)

        # null-null로 연결
        new_chunk = b'\x00\x00'.join(new_lines)

        # 크기 맞춤 (in-place, 크기 고정)
        if len(new_chunk) < size:
            new_chunk = new_chunk + b'\x00' * (size - len(new_chunk))
        new_chunk = new_chunk[:size]

        # 직접 인덱스 대입 (bytearray 크기 변경 방지)
        for bi, bv in enumerate(new_chunk):
            b0[abs_off + bi] = bv

    return bytes(b0)


# ─── pl_ 스크립트 파싱/리빌드 ───────────────────────────────────────────────

# pl_ block_0 opcode
_PL_OP_NAME = 20   # ScrSetName  - 화자 이름
_PL_OP_MSG  = {4, 7, 26, 27}  # ScrMessage 계열 - 대사

def _pl_read_str(data, ptr):
    """ptr 위치의 null-null 종료 CP932 문자열 읽기."""
    nul = data.find(b'\x00\x00', ptr)
    chunk = data[ptr:nul] if nul != -1 else data[ptr:]
    try:    return chunk.decode(SCRIPT_ENC)
    except: return chunk.decode(SCRIPT_ENC, errors='replace')

# opcode 인자 크기 테이블 (바이트 수, opcode 이후)
# -1 = 가변/복잡 (건너뜀)
_PL_OP_SIZE = {
    0:  8,   # ScrSetChar (복잡하지만 대략)
    1:  8,   # ScrSetObject
    2:  1,   # ScrExit
    3:  1,   # ScrSetFade
    4:  2,   # ScrMessage (short ptr)
    5:  5,   # ScrFlagOn
    6:  5,   # ScrFlagOff
    7:  4,   # ScrMessageY (short+short)
    11: 8,   # ScrIf (4B+short+short)
    12: 8,   # ScrElseIf
    13: 2,   # ScrElse (short)
    14: 0,   # ScrEndIf
    15: 2,   # ScrSetBattle
    16: 2,   # ScrSetVisual
    17: 4,   # ScrGoto (short+short)
    18: 2,   # ScrGosub (short)
    19: 0,   # ScrReturn
    20: 2,   # ScrSetName (short ptr)
    21: 0,   # ScrMessageEnd
    22: 2,
    23: 2,   # ScrSetPicture
    24: 4,   # ScrSetPicPos
    25: 4,
    26: 4,   # ScrMessageY
    27: 4,   # ScrMessageY
    28: 0,   # ScrMessageClear
    29: 2,
    30: 2,
    31: 2,
    32: 2,
    33: 2,
    34: 2,
    35: 2,
    36: 2,
    37: 2,
    38: 2,
    39: 2,
    40: 2,
    41: 2,
    42: 2,
    43: 2,
    44: 4,
    45: 4,
    46: 4,
    47: 4,
    48: 4,
    49: 2,
    50: 2,
    51: 2,
    52: 2,
    53: 2,
    54: 2,
    55: 2,
    56: 2,
    57: 2,
    58: 2,
    59: 2,
    60: 2,
    61: 2,
    95: 2,
    102: 2,
    104: 2,
    105: 2,
}

def _pl_scan_opcodes(b0):
    """
    block_0 바이트코드를 정확히 순서대로 파싱.
    반환: [(pos, opcode, arg_bytes), ...]
    텍스트 영역 시작 전까지만.
    """
    # 1패스: opcode 20/4/7/26/27의 포인터 수집 -> text_start 결정
    ops = []
    i = 0
    while i < len(b0) - 1:
        op = b0[i]
        size = _PL_OP_SIZE.get(op, -1)
        if size < 0:
            # 알 수 없는 opcode -> 1바이트씩 진행
            i += 1
            continue
        arg = b0[i+1:i+1+size]
        ops.append((i, op, arg))
        i += 1 + size

    # text_start = 텍스트 포인터 최솟값 (CP932 유효성 검증)
    def _is_valid_text_ptr(b0, ptr):
        """ptr이 실제 CP932 텍스트를 가리키는지 확인."""
        if ptr <= 0 or ptr >= len(b0) - 1: return False
        nul = b0.find(b'\x00\x00', ptr)
        if nul == -1 or nul == ptr: return False
        chunk = b0[ptr:nul]
        try: chunk.decode(SCRIPT_ENC); return True
        except: return False

    ptrs = []
    for pos, op, arg in ops:
        if (op == _PL_OP_NAME or op in _PL_OP_MSG) and len(arg) >= 2:
            ptr = arg[0] | (arg[1]<<8)
            if _is_valid_text_ptr(b0, ptr):
                ptrs.append(ptr)
    if not ptrs: return ops, len(b0)
    text_start = min(ptrs)
    # text_start 이전 opcode만 반환
    return [(pos, op, arg) for pos, op, arg in ops if pos < text_start], text_start

def parse_plscript(b0):
    """
    block_0에서 대사를 순서대로 추출.
    opcode 4/7/26/27(대사)와 20(화자)의 LE 포인터를 전체 구간에서 스캔.
    포인터가 유효한 CP932 텍스트를 가리키는지로 검증.
    """
    def _read(ptr):
        nul = b0.find(b'\x00\x00', ptr)
        chunk = b0[ptr:nul] if nul != -1 else b0[ptr:]
        try: return chunk.decode(SCRIPT_ENC)
        except: return None

    def _valid_ptr(ptr):
        if ptr <= 0 or ptr >= len(b0) - 1: return False
        nul = b0.find(b'\x00\x00', ptr)
        if nul <= ptr: return False
        chunk = b0[ptr:nul]
        # 전체가 CP932로 디코딩 가능하고 제어문자 없어야 함
        try:
            txt = chunk.decode(SCRIPT_ENC)
            # 제어문자(0x00~0x1F)가 포함된 건 바이트코드
            return not any(ord(c) < 0x20 for c in txt)
        except: return False

    # 전체 구간에서 opcode 순서대로 이벤트 수집
    events = []
    i = 0
    while i < len(b0) - 2:
        op = b0[i]
        if op == 4 or op == 20:
            ptr = b0[i+1] | (b0[i+2]<<8)
            ptr_pos = i + 1
            if _valid_ptr(ptr):
                txt = _read(ptr)
                if txt:
                    events.append((i, op, ptr_pos, ptr, txt))
            i += 3
        elif op in (7, 26, 27):
            if i + 4 < len(b0):
                ptr = b0[i+3] | (b0[i+4]<<8)
                ptr_pos = i + 3
                if _valid_ptr(ptr):
                    txt = _read(ptr)
                    if txt:
                        events.append((i, op, ptr_pos, ptr, txt))
            i += 5
        else:
            i += 1

    # 씬 구성
    scenes = []
    current = None
    for pos, op, ptr_pos, ptr_val, text in events:
        if op == 20:
            if current and current['msg_positions']:
                scenes.append(current)
            current = {
                'scene':         len(scenes),
                'speaker_pos':   ptr_pos,
                'msg_positions': [],
                'speaker':       text,
                'speaker_trans': '',
                'lines':         [],
                'trans':         [],
            }
        else:
            if current is None:
                current = {'scene': 0, 'speaker_pos': -1,
                           'msg_positions': [], 'speaker': '',
                           'speaker_trans': '',
                           'lines': [], 'trans': []}
            current['msg_positions'].append(ptr_pos)
            current['lines'].append(text)
            current['trans'].append('')

    if current and current['msg_positions']:
        scenes.append(current)
    return scenes

def rebuild_plscript(orig_b0, json_entries):
    """
    JSON 번역을 block_0에 반영.
    번역이 있는 포인터만 파일 끝에 append하고 해당 포인터만 새 주소로 교체.
    번역 없는 포인터는 원본 주소 그대로 유지.
    """
    # 번역 있는 항목만 수집: ptr_val -> 새 인코딩
    ptr_to_new = {}
    for entry in json_entries:
        items = []
        if entry.get('speaker_pos', -1) >= 0:
            items.append((entry['speaker_pos'],
                          entry.get('speaker', ''),
                          entry.get('speaker_trans', '')))
        for ptr_pos, line, tr in zip(
                entry['msg_positions'], entry['lines'],
                entry.get('trans', ['']*len(entry['lines']))):
            items.append((ptr_pos, line, tr))

        for ptr_pos, orig_line, trans_line in items:
            trans = trans_line.strip(' \t\n\r')
            if not trans: continue  # 번역 없으면 건드리지 않음
            ptr_val = orig_b0[ptr_pos] | (orig_b0[ptr_pos+1]<<8)
            if ptr_val in ptr_to_new: continue  # 이미 처리됨
            ptr_to_new[ptr_val] = encode_text(trans, CHARMAP_PATH)

    if not ptr_to_new: return bytes(orig_b0)

    # 번역된 텍스트를 파일 끝에 append
    new_pool_start = len(orig_b0)
    new_pool = bytearray()
    new_ptr_map = {}
    for old_ptr, encoded in sorted(ptr_to_new.items()):
        new_ptr_map[old_ptr] = new_pool_start + len(new_pool)
        new_pool += encoded

    new_b0 = bytearray(orig_b0) + new_pool

    # 번역된 포인터만 새 주소로 교체 (번역 없는 건 원본 유지)
    for entry in json_entries:
        items = []
        if entry.get('speaker_pos', -1) >= 0:
            items.append((entry['speaker_pos'],
                          entry.get('speaker_trans', '')))
        for ptr_pos, tr in zip(entry['msg_positions'],
                               entry.get('trans', ['']*len(entry['msg_positions']))):
            items.append((ptr_pos, tr))

        for ptr_pos, trans_line in items:
            if not trans_line.strip(' \t\n\r'): continue  # 번역 없으면 포인터 유지
            old_ptr = orig_b0[ptr_pos] | (orig_b0[ptr_pos+1]<<8)
            if old_ptr in new_ptr_map:
                new_ptr = new_ptr_map[old_ptr]
                new_b0[ptr_pos]   = new_ptr & 0xFF
                new_b0[ptr_pos+1] = (new_ptr >> 8) & 0xFF

    return bytes(new_b0)


# ─── 헬퍼 ────────────────────────────────────────────────────────────────────

def dat_to_dir(fname):
    return fname.rsplit('.', 1)[0].replace('.', '_')

def _is_image(data):
    return (data[:6] in (b'GIF89a', b'GIF87a') or data[:4] == b'\x89PNG')


# ─── extract ─────────────────────────────────────────────────────────────────

def cmd_extract(pp_num, dat_path, out_dir):
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
            open(os.path.join(arc_dir, sub['name']), 'wb').write(raw)
            print(f"  {sub['name']:25s} -> {arc_name}/{sub['name']} (raw)")
            continue

        has_script, img_count = False, 0
        for af in arc_files:
            if _is_image(af['data']):
                ext = 'png' if af['data'][:4] == b'\x89PNG' else 'gif'
                open(os.path.join(arc_dir, f"img_{af['index']}.{ext}"), 'wb').write(af['data'])
                img_count += 1
            else:
                # pl_ block_0: 전용 파서 사용
                if '_' in sub['name'] and af['index'] == 0:
                    pl_scenes = parse_plscript(af['data'])
                    if pl_scenes:
                        json.dump(pl_scenes,
                                  open(os.path.join(arc_dir,'script.json'),'w',encoding='utf-8'),
                                  ensure_ascii=False, indent=2)
                        has_script = True
                    else:
                        open(os.path.join(arc_dir, f"block_{af['index']}.bin"), 'wb').write(af['data'])
                else:
                    scenes, ts = parse_script(af['data'])
                    if scenes:
                        json.dump(scenes_to_json(scenes),
                                  open(os.path.join(arc_dir,'script.json'),'w',encoding='utf-8'),
                                  ensure_ascii=False, indent=2)
                        has_script = True
                    else:
                        open(os.path.join(arc_dir, f"block_{af['index']}.bin"), 'wb').write(af['data'])

        marker = ' + script.json' if has_script else ''
        print(f"  {sub['name']:25s} -> {arc_name}/  ({img_count} img{marker})")

    print(f"\n총 {len(subzips)}개 파일 -> {out_dir}/")


# ─── repack ───────────────────────────────────────────────────────────────────

def cmd_repack(pp_num, orig_dat_path, mod_dir, out_dat_path):
    orig    = open(orig_dat_path, 'rb').read()
    orig_sz = len(orig)
    subzips = parse_subzips(orig)
    payload = bytearray()

    for sub in subzips:
        raw_orig  = decomp_entry(orig, sub)
        arc_name  = dat_to_dir(sub['name'])
        arc_dir   = os.path.join(mod_dir, arc_name)
        arc_files = parse_arc(raw_orig)

        if arc_files is None:
            # ARC가 아닌 raw 파일 - 작업폴더에 같은 이름 파일이 있으면 교체
            raw_path = os.path.join(arc_dir, sub['name'])
            if os.path.exists(raw_path):
                new_raw = open(raw_path, 'rb').read()
                if new_raw != raw_orig:
                    subzip = build_subzip(sub['name'], new_raw,
                                         sub['mod_time'], sub['mod_date'], sub['extra_lfh'])
                    payload.extend(subzip)
                    print(f"  modified: {sub['name']} (raw)")
                    continue
            payload.extend(orig[sub['start']:sub['end']])
            print(f"  kept    : {sub['name']} (raw)")
            continue

        if not os.path.isdir(arc_dir):
            payload.extend(orig[sub['start']:sub['end']])
            print(f"  kept (no dir): {sub['name']}")
            continue

        new_blocks, new_indices, changed = [], [], False
        for af in arc_files:
            new_data = None
            if _is_image(af['data']):
                for ext in ('gif','png','GIF','PNG'):
                    p = os.path.join(arc_dir, f"img_{af['index']}.{ext}")
                    if os.path.exists(p):
                        candidate = open(p,'rb').read()
                        # 원본과 내용이 다를 때만 교체
                        if candidate != af['data']:
                            new_data = candidate
                        break
            else:
                json_path = os.path.join(arc_dir, 'script.json')
                bin_path  = os.path.join(arc_dir, f"block_{af['index']}.bin")
                if os.path.exists(json_path):
                    entries = json.load(open(json_path, encoding='utf-8'))
                    # trans에 실제 번역이 하나라도 있을 때만 rebuild
                    has_any_trans = (
                        any(t.strip(' \t\n\r') != '' for e in entries for t in e.get('trans', [])) or
                        any(e.get('speaker_trans','').strip(' \t\n\r') != '' for e in entries)
                    )
                    if has_any_trans:
                        if '_' in sub['name'] and af['index'] == 0:
                            new_data = rebuild_plscript(af['data'], entries)
                        else:
                            new_data = rebuild_script(af['data'], entries)
                        # rebuild 결과가 원본과 같으면 교체 불필요
                        if new_data == af['data']:
                            new_data = None
                elif os.path.exists(bin_path):
                    candidate = open(bin_path,'rb').read()
                    if candidate != af['data']:
                        new_data = candidate
            if new_data is None: new_data = af['data']
            changed = changed or (new_data != af['data'])
            new_blocks.append(new_data); new_indices.append(af['index'])

        if changed:
            subzip = build_subzip(sub['name'], build_arc(new_blocks, new_indices),
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

    # dll 패치는 repack_all에서 일괄 처리. 단독 repack 시에는 여기서 패치.
    if _patch_dll_on_repack:
        find_and_patch_dll(pp_num, out_dat_path)


# ─── verify ───────────────────────────────────────────────────────────────────

def cmd_verify(pp_num, dat_path):
    import tempfile
    orig = open(dat_path, 'rb').read()
    with tempfile.TemporaryDirectory() as tmpdir:
        cmd_extract(pp_num, dat_path, tmpdir)
        out = os.path.join(tmpdir, 'repacked.dat')
        cmd_repack(pp_num, dat_path, tmpdir, out)
        repacked = open(out, 'rb').read()
    subs_o = parse_subzips(orig)
    subs_n = parse_subzips(repacked)
    ok = True
    print("\n=== 검증 ===")
    for eo, en in zip(subs_o, subs_n):
        if eo['crc'] != en['crc'] or eo['uncomp_size'] != en['uncomp_size']:
            print(f"  FAIL {eo['name']}"); ok = False
        else:
            print(f"  OK   {eo['name']}")
    print("모든 파일 일치 ✓" if ok else "일부 불일치 ✗")


# ─── main ─────────────────────────────────────────────────────────────────────

def cmd_extract_all(base_dir, out_base_dir):
    """PP01~06 전체 extract. base_dir에 xenosagapp1.dat~xenosagapp6.dat 있어야 함."""
    for pp in range(1, 7):
        dat_path = os.path.join(base_dir, f'xenosagapp{pp}.dat')
        out_dir  = os.path.join(out_base_dir, f'pp{pp:02d}')
        if not os.path.exists(dat_path):
            print(f'[PP{pp:02d}] {dat_path} 없음 - 건너뜀')
            continue
        print(f'\n=== PP{pp:02d} extract ===')
        cmd_extract(pp, dat_path, out_dir)

def cmd_repack_all(orig_base_dir, mod_base_dir, out_base_dir, dll_path=None):
    """
    PP01~06 전체 repack 후 dll을 한 번에 패치.
    orig_base_dir: 원본 dat들이 있는 폴더
    mod_base_dir:  extract_all로 만든 작업 폴더 (pp01/, pp02/, ...)
    out_base_dir:  출력 폴더 (xenosagapp1_new.dat 등 생성)
    dll_path:      패치할 dll 경로. 없으면 out_base_dir에서 자동 탐색.
    """
    global _patch_dll_on_repack
    _patch_dll_on_repack = False  # 개별 repack에서 dll 패치 안 함
    global _TOUNICODE_TABLE_BASE
    os.makedirs(out_base_dir, exist_ok=True)

    out_dats = []
    for pp in range(1, 7):
        dat_path = os.path.join(orig_base_dir, f'xenosagapp{pp}.dat')
        mod_dir  = os.path.join(mod_base_dir,  f'pp{pp:02d}')
        out_dat  = os.path.join(out_base_dir,  f'xenosagapp{pp}_new.dat')
        if not os.path.exists(dat_path):
            print(f'[PP{pp:02d}] {dat_path} 없음 - 건너뜀')
            continue
        if not os.path.exists(mod_dir):
            print(f'[PP{pp:02d}] {mod_dir} 없음 - 건너뜀')
            continue
        print(f'\n=== PP{pp:02d} repack ===')
        cmd_repack(pp, dat_path, mod_dir, out_dat)
        out_dats.append((pp, out_dat))

    _patch_dll_on_repack = True

    # dll 찾기
    if dll_path is None:
        for name in ('Assembly-CSharp.dll.new', 'Assembly-CSharp.dll'):
            cand = os.path.join(out_base_dir, name)
            if os.path.exists(cand):
                dll_path = cand; break
    if dll_path is None:
        print('\n[dll] dll을 찾을 수 없음 - dll 패치 건너뜀')
        return

    # .new가 없으면 원본 복사
    new_dll = os.path.join(out_base_dir, 'Assembly-CSharp.dll.new')
    if dll_path != new_dll and not os.path.exists(new_dll):
        import shutil
        shutil.copy2(dll_path, new_dll)
        print(f'\n원본 dll 복사: {os.path.basename(dll_path)} -> Assembly-CSharp.dll.new')
        dll_path = new_dll

    print(f'\n=== dll 일괄 패치: {dll_path} ===')
    dll = bytearray(open(dll_path, 'rb').read())

    # PP별 downfilechk 패치 (모두 같은 dll에 순서대로)
    _TOUNICODE_TABLE_BASE = None
    for pp, out_dat in out_dats:
        chk   = DOWNFILECHK[pp]
        dat   = open(out_dat, 'rb').read()
        subs  = parse_subzips(dat)
        pairs = _find_dll_pairs(bytes(dll), pp)
        if pairs is None:
            print(f'  [PP{pp:02d}] downfilechk 위치 찾기 실패')
            continue
        changed = 0
        for i, s in enumerate(subs[:len(chk)]):
            act_unc = s['uncomp_size']
            act_blk = s['end'] - s['start']
            p = pairs[i]
            dll_unc = _read_unc(bytes(dll), p)
            dll_blk = struct.unpack_from('<i', dll, p['cmp_off'])[0]
            if dll_unc != act_unc or dll_blk != act_blk:
                _write_unc(dll, p, act_unc)
                struct.pack_into('<i', dll, p['cmp_off'], act_blk)
                changed += 1
        print(f'  [PP{pp:02d}] downfilechk {changed}개 수정')

    # ToUnicode 패치 (한 번만)
    if CHARMAP_PATH and os.path.exists(CHARMAP_PATH):
        _patch_tounicode(dll, CHARMAP_PATH)
    else:
        print('  [dll] CHARMAP_PATH 미설정 - ToUnicode 패치 건너뜀')

    open(dll_path, 'wb').write(dll)
    print(f'  [dll] 패치 완료: {os.path.basename(dll_path)}')


def usage():
    print(__doc__); sys.exit(1)

if __name__ == '__main__':
    if len(sys.argv) < 2: usage()
    cmd = sys.argv[1]

    if cmd == 'extract_all' and len(sys.argv) == 4:
        cmd_extract_all(sys.argv[2], sys.argv[3])
    elif cmd == 'repack_all' and len(sys.argv) in (5, 6):
        dll = sys.argv[5] if len(sys.argv) == 6 else None
        cmd_repack_all(sys.argv[2], sys.argv[3], sys.argv[4], dll)
    else:
        try:
            pp = int(sys.argv[2])
            assert 1 <= pp <= 6
        except:
            print('PP번호는 1~6이어야 합니다.'); usage()

        if   cmd == 'extract' and len(sys.argv) == 5:
            cmd_extract(pp, sys.argv[3], sys.argv[4])
        elif cmd == 'repack'  and len(sys.argv) == 6:
            cmd_repack(pp, sys.argv[3], sys.argv[4], sys.argv[5])
        elif cmd == 'verify'  and len(sys.argv) == 4:
            cmd_verify(pp, sys.argv[3])
        else:
            usage()
