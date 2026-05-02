#!/usr/bin/env python3
"""
UnityFS AssetBundle 추출/리팩 툴킷 v2
대상: G-MODE Archives+ (Xenosaga Pied Piper) Addressables 번들

extract:
  bundle.bundle  →  out/CAB-xxx/
                      ├─ _meta.json          (리팩 시 필요한 모든 메타)
                      ├─ titleimage.png      (Texture2D → PNG)
                      ├─ some_sprite.json    (Sprite 정보)
                      ├─ other.bin           (미지원 타입 → raw)
                      └─ CAB-xxx.resS        (원본 resS, 직접 수정 가능)

rebuild:
  out/CAB-xxx/  →  bundle_new.bundle
  _meta.json + 수정된 파일들 참조해서 올바른 블록 구조로 재패킹

사용법:
  python unityfs_toolkit.py extract  bundle.bundle ./out/
  python unityfs_toolkit.py rebuild  bundle.bundle ./out/ bundle_new.bundle
"""

import os, sys, json, struct, zlib
from pathlib import Path

try:
    import UnityPy
    from UnityPy.enums import ClassIDType
    UNITYPY = True
except ImportError:
    UNITYPY = False

BLOCK_SIZE = 131072  # 128KB


# ═══════════════════════════════════════════════════════════════════════
#  UnityFS 번들 레이어 (block_info, dir)
# ═══════════════════════════════════════════════════════════════════════

def _read_cstring(data, pos):
    s = b''
    while data[pos] != 0: s += bytes([data[pos]]); pos += 1
    return s.decode(), pos + 1

def _parse_bundle_header(data):
    pos = 0
    sig, pos      = _read_cstring(data, pos)
    fmt_ver       = struct.unpack_from('>I', data, pos)[0]; pos += 4
    unity_ver, pos = _read_cstring(data, pos)
    gen_ver, pos   = _read_cstring(data, pos)
    bundle_size   = struct.unpack_from('>Q', data, pos)[0]; pos += 8
    comp_bi_sz    = struct.unpack_from('>I', data, pos)[0]; pos += 4
    uncomp_bi_sz  = struct.unpack_from('>I', data, pos)[0]; pos += 4
    flags         = struct.unpack_from('>I', data, pos)[0]; pos += 4
    return dict(sig=sig, fmt_ver=fmt_ver, unity_ver=unity_ver, gen_ver=gen_ver,
                bundle_size=bundle_size, comp_bi_sz=comp_bi_sz,
                uncomp_bi_sz=uncomp_bi_sz, flags=flags, header_end=pos)

def _parse_block_info(data, start):
    pos = start + 16  # skip data_hash
    block_count = struct.unpack_from('>I', data, pos)[0]; pos += 4
    blocks = []
    for _ in range(block_count):
        u = struct.unpack_from('>I', data, pos)[0]; pos += 4
        c = struct.unpack_from('>I', data, pos)[0]; pos += 4
        f = struct.unpack_from('>H', data, pos)[0]; pos += 2
        blocks.append(dict(uncomp=u, comp=c, flags=f))
    dir_count = struct.unpack_from('>I', data, pos)[0]; pos += 4
    dirs = []
    for _ in range(dir_count):
        offset = struct.unpack_from('>Q', data, pos)[0]; pos += 8
        size   = struct.unpack_from('>Q', data, pos)[0]; pos += 8
        status = struct.unpack_from('>I', data, pos)[0]; pos += 4
        name, pos = _read_cstring(data, pos)
        dirs.append(dict(offset=offset, size=size, status=status, name=name))
    return blocks, dirs, pos

def _parse_bundle(data):
    hdr = _parse_bundle_header(data)
    bi_start = hdr['header_end']
    if bi_start % 16 != 0:
        bi_start += 16 - bi_start % 16
    blocks, dirs, data_start = _parse_block_info(data, bi_start)
    return hdr, blocks, dirs, data_start, bi_start

def _build_block_info(dirs, blocks):
    out  = b'\x00' * 16
    out += struct.pack('>I', len(blocks))
    for b in blocks:
        out += struct.pack('>I', b['uncomp'])
        out += struct.pack('>I', b['comp'])
        out += struct.pack('>H', b['flags'])
    out += struct.pack('>I', len(dirs))
    for d in dirs:
        out += struct.pack('>Q', d['offset'])
        out += struct.pack('>Q', d['size'])
        out += struct.pack('>I', d['status'])
        out += d['name'].encode() + b'\x00'
    return out

def _build_header(hdr_orig, bundle_size, comp_bi_sz, uncomp_bi_sz):
    out  = hdr_orig['sig'].encode() + b'\x00'
    out += struct.pack('>I', hdr_orig['fmt_ver'])
    out += hdr_orig['unity_ver'].encode() + b'\x00'
    out += hdr_orig['gen_ver'].encode() + b'\x00'
    out += struct.pack('>Q', bundle_size)
    out += struct.pack('>I', comp_bi_sz)
    out += struct.pack('>I', uncomp_bi_sz)
    out += struct.pack('>I', hdr_orig['flags'])
    return out


# ═══════════════════════════════════════════════════════════════════════
#  에셋 추출 (UnityPy 활용)
# ═══════════════════════════════════════════════════════════════════════

def _extract_assets(bundle_path, cab_name, out_dir):
    """번들에서 특정 CAB의 에셋을 추출. _meta.json에 메타 기록."""
    if not UNITYPY:
        print('  [!] UnityPy 없음 - 에셋 추출 생략 (pip install UnityPy)')
        return {}

    meta_assets = {}

    # 번들 전체 로드 (resS 자동 연결)
    env = UnityPy.load(bundle_path)

    for obj in env.objects:
        try:
            d   = obj.read()
            typ = obj.type.name
            name = getattr(d, 'm_Name', f'pid_{obj.path_id}')

            if typ == 'Texture2D':
                img = d.image
                sd  = d.m_StreamData
                fmt_id   = int(d.m_TextureFormat)
                fmt_name = _TEX_FORMATS.get(fmt_id, f'fmt_{fmt_id}')
                if img:
                    fname = f'{name}.png'
                    img.save(os.path.join(out_dir, fname))
                    import hashlib
                    png_hash = hashlib.md5(open(os.path.join(out_dir, fname), 'rb').read()).hexdigest()
                    meta_assets[name] = dict(
                        type='Texture2D', file=fname,
                        path_id=obj.path_id,
                        width=d.m_Width, height=d.m_Height,
                        format_id=fmt_id, format_name=fmt_name,
                        complete_image_size=d.m_CompleteImageSize,
                        stream_offset=sd.offset if sd else 0,
                        stream_size=sd.size     if sd else 0,
                        stream_path=sd.path     if sd else '',
                        png_hash=png_hash,
                    )
                    print(f'  PNG : {fname}  ({d.m_Width}x{d.m_Height} {fmt_name})')
                else:
                    meta_assets[name] = dict(type='Texture2D', file=None,
                                             path_id=obj.path_id, note='no image')
                    print(f'  TX? : {name}  (이미지 없음)')

            elif typ == 'Sprite':
                fname = f'{name}.sprite.json'
                info  = dict(type='Sprite', path_id=obj.path_id, name=name,
                             rect=dict(x=d.m_Rect.x, y=d.m_Rect.y,
                                       w=d.m_Rect.width, h=d.m_Rect.height))
                json.dump(info, open(os.path.join(out_dir, fname), 'w'), indent=2)
                meta_assets[f'{name}__sprite'] = dict(type='Sprite', file=fname,
                                                       path_id=obj.path_id)
                print(f'  SPR : {name}')

            elif typ == 'TextAsset':
                fname = f'{name}.txt'
                open(os.path.join(out_dir, fname), 'wb').write(d.m_Script if hasattr(d,'m_Script') else d.script)
                meta_assets[name] = dict(type='TextAsset', file=fname, path_id=obj.path_id)
                print(f'  TXT : {fname}')

            else:
                print(f'  --- : {typ} / {name}')

        except Exception as e:
            print(f'  ERR : {obj.type.name} pid={obj.path_id}: {e}')

    return meta_assets


_TEX_FORMATS = {
    1:'Alpha8', 2:'ARGB4444', 3:'RGB24', 4:'RGBA32', 5:'ARGB32',
    7:'RGB565', 9:'R16', 10:'DXT1', 12:'DXT5', 13:'RGBA4444',
    14:'BGRA32', 28:'DXT1Crunched', 29:'DXT5Crunched',
    34:'PVRTC_RGB2', 45:'ETC_RGB4', 47:'ETC2_RGB', 62:'ETC2_RGBA8',
    63:'ETC2_RGBA8Crunched',
}


# ═══════════════════════════════════════════════════════════════════════
#  extract
# ═══════════════════════════════════════════════════════════════════════

def extract(bundle_path, out_base):
    data = open(bundle_path, 'rb').read()
    hdr, blocks, dirs, data_start, bi_start = _parse_bundle(data)
    total_data = data[data_start : data_start + sum(b['comp'] for b in blocks)]

    print(f'번들 : {bundle_path}')
    print(f'Unity {hdr["unity_ver"]} / {hdr["gen_ver"]}')
    print(f'블록  : {len(blocks)}개  파일: {len(dirs)}개')
    print()

    for d in dirs:
        file_data  = total_data[d['offset'] : d['offset'] + d['size']]
        cab_name   = d['name']
        is_ress    = cab_name.endswith('.resS')

        # CAB는 폴더로 분리, resS는 CAB 폴더 안에 함께
        if is_ress:
            # 대응하는 CAB 폴더 찾기
            cab_folder = cab_name[:-5]  # '.resS' 제거 (없으면 base)
            cab_dir = os.path.join(out_base, cab_folder)
        else:
            cab_dir = os.path.join(out_base, cab_name)

        os.makedirs(cab_dir, exist_ok=True)
        raw_path = os.path.join(cab_dir, cab_name)
        open(raw_path, 'wb').write(file_data)
        print(f'[{"resS" if is_ress else "CAB "}] {cab_name}  ({d["size"]:,} bytes)')

    # 에셋 추출 (CAB 파일들에 대해)
    all_asset_meta = {}
    for d in dirs:
        if d['name'].endswith('.resS'):
            continue
        cab_name = d['name']
        cab_dir  = os.path.join(out_base, cab_name)
        cab_path2 = os.path.join(cab_dir, cab_name)
        ress_name = cab_name + '.resS'
        ress_path2 = os.path.join(cab_dir, ress_name) if any(
            dd['name'] == ress_name for dd in dirs) else None

        print(f'\n  [{cab_name}] 에셋 추출:')
        asset_meta = _extract_assets(bundle_path, cab_name, cab_dir)
        all_asset_meta[cab_name] = asset_meta

    # _meta.json 저장
    tail_start = data_start + sum(b['comp'] for b in blocks)
    meta = dict(
        bundle_path=str(bundle_path),
        header=dict(
            sig=hdr['sig'], fmt_ver=hdr['fmt_ver'],
            unity_ver=hdr['unity_ver'], gen_ver=hdr['gen_ver'],
            flags=hdr['flags'],
            comp_bi_sz=hdr['comp_bi_sz'], uncomp_bi_sz=hdr['uncomp_bi_sz'],
        ),
        bi_start=bi_start,
        data_start=data_start,
        original_tail=data[tail_start:].hex(),  # 파일 끝 더미 데이터
        dirs=dirs,
        blocks_original=blocks,
        assets=all_asset_meta,
    )
    meta_path = os.path.join(out_base, '_meta.json')
    json.dump(meta, open(meta_path, 'w', encoding='utf-8'), ensure_ascii=False, indent=2)
    print(f'\n메타 → {meta_path}')
    return meta


# ═══════════════════════════════════════════════════════════════════════
#  에셋 임포트 (PNG → Texture2D raw 변환)
# ═══════════════════════════════════════════════════════════════════════

def _png_to_raw(png_path, target_format_name, width, height):
    """PNG를 Unity 텍스처 포맷의 raw pixel로 변환."""
    from PIL import Image
    img = Image.open(png_path)

    fmt = target_format_name
    if fmt in ('RGBA32', 'ARGB32'):
        img = img.convert('RGBA')
        if fmt == 'ARGB32':
            r, g, b, a = img.split()
            img = Image.merge('RGBA', (a, r, g, b))
        return img.tobytes()
    elif fmt == 'RGB24':
        img = img.convert('RGB')
        return img.tobytes()
    elif fmt == 'Alpha8':
        img = img.convert('L')
        return img.tobytes()
    elif fmt == 'BGRA32':
        img = img.convert('RGBA')
        r, g, b, a = img.split()
        img = Image.merge('RGBA', (b, g, r, a))
        return img.tobytes()
    else:
        raise ValueError(f'미지원 포맷: {fmt} — DXT/ETC 등 압축 포맷은 수동 변환 필요')


def _rebuild_textures_direct(out_dir, modified_by_cab, dirs_orig, total_data_orig):
    """
    UnityPy save() 없이 직접 바이너리 패치.
    PNG를 raw pixel로 변환해서 resS 해당 오프셋에 덮어씀.
    CAB는 건드리지 않음 (같은 해상도/포맷일 때만 동작).
    반환: {dir_name: new_bytes}  변경된 것만
    """
    import json
    from PIL import Image

    meta = json.load(open(os.path.join(out_dir, '_meta.json'), encoding='utf-8'))

    # dir별 데이터를 bytearray로 준비
    dir_data = {}
    for d in dirs_orig:
        dir_data[d['name']] = bytearray(
            total_data_orig[d['offset'] : d['offset'] + d['size']])

    changed = set()

    for cab_name, tex_list in modified_by_cab.items():
        ress_name  = cab_name + '.resS'
        asset_meta = meta['assets'].get(cab_name, {})

        for path_id, png_path in tex_list:
            ainfo = next((v for v in asset_meta.values()
                          if v.get('path_id') == path_id and v.get('type') == 'Texture2D'), None)
            if not ainfo:
                print(f'    [!] path_id={path_id} 메타 없음, 건너뜀')
                continue

            fmt_name      = ainfo['format_name']
            orig_w        = ainfo['width']
            orig_h        = ainfo['height']
            stream_offset = ainfo['stream_offset']
            stream_size   = ainfo['stream_size']
            stream_path   = ainfo.get('stream_path', '')

            img = Image.open(png_path)

            # 크기 불일치 시 리사이즈
            if img.size != (orig_w, orig_h):
                print(f'    [!] {Path(png_path).name}: {img.size} → ({orig_w},{orig_h}) 리사이즈')
                img = img.resize((orig_w, orig_h), Image.LANCZOS)

            # 포맷별 raw 변환
            fmt_map = {
                'RGB24':  lambda i: i.convert('RGB').tobytes(),
                'RGBA32': lambda i: i.convert('RGBA').tobytes(),
                'ARGB32': lambda i: Image.merge('RGBA', (*i.convert('RGBA').split()[1:], i.convert('RGBA').split()[0])).tobytes(),
                'BGRA32': lambda i: (lambda r,g,b,a: Image.merge('RGBA',(b,g,r,a)).tobytes())(*i.convert('RGBA').split()),
                'Alpha8': lambda i: i.convert('L').tobytes(),
            }
            if fmt_name not in fmt_map:
                print(f'    [!] {fmt_name}: 압축 포맷 직접 변환 불가, 건너뜀')
                continue

            raw = fmt_map[fmt_name](img)

            if len(raw) != stream_size:
                print(f'    [!] raw 크기 불일치: {len(raw)} ≠ {stream_size} (포맷/해상도 확인)')
                continue

            # resS에 직접 패치
            if ress_name in dir_data and stream_path.endswith('.resS'):
                ress = dir_data[ress_name]
                ress[stream_offset : stream_offset + stream_size] = raw
                changed.add(ress_name)
                print(f'    ← {ainfo.get("file","?")}  resS[{stream_offset}:{stream_offset+stream_size}] 패치')
            else:
                print(f'    [!] inline texture 미지원')

    return {k: bytes(v) for k, v in dir_data.items() if k in changed}


def _rebuild_texture2d_in_bundle(bundle_path, modified_textures_by_cab):
    # 하위호환 유지용 - 직접 패치 방식으로 위임하지 않음
    pass


# ═══════════════════════════════════════════════════════════════════════
#  rebuild
# ═══════════════════════════════════════════════════════════════════════

def rebuild(bundle_path, out_dir, out_path):
    """
    out_dir/_meta.json + 수정된 파일들로 번들 재패킹.
    PNG가 교체된 경우 Texture2D raw 변환 후 CAB/resS 재구성.
    """
    meta = json.load(open(os.path.join(out_dir, '_meta.json'), encoding='utf-8'))
    hdr_orig = meta['header']
    dirs_orig = meta['dirs']
    orig_data = open(bundle_path, 'rb').read()
    _, blocks_orig, _, data_start, _ = _parse_bundle(orig_data)
    total_data_orig = orig_data[data_start : data_start + sum(b['comp'] for b in blocks_orig)]

    new_dir_data = {}  # dir name → bytes

    # PNG 교체 대상 수집 - 원본 해시와 비교해서 실제 변경된 것만
    import hashlib

    def md5(path):
        return hashlib.md5(open(path, 'rb').read()).hexdigest()

    modified_by_cab = {}  # cab_name → [(path_id, png_path)]
    for d in dirs_orig:
        if d['name'].endswith('.resS'): continue
        cab_name   = d['name']
        cab_dir    = os.path.join(out_dir, cab_name)
        asset_meta = meta['assets'].get(cab_name, {})
        for aname, ainfo in asset_meta.items():
            if ainfo.get('type') != 'Texture2D': continue
            png_fname = ainfo.get('file')
            if not png_fname: continue
            png_path = os.path.join(cab_dir, png_fname)
            if not os.path.exists(png_path): continue
            # 원본 해시와 비교
            orig_hash = ainfo.get('png_hash', '')
            curr_hash = md5(png_path)
            if curr_hash != orig_hash:
                modified_by_cab.setdefault(cab_name, []).append(
                    (ainfo['path_id'], png_path))
                print(f'  변경 감지: {png_fname}')

    if not modified_by_cab:
        print('  변경된 PNG 없음 — 원본 파일 그대로 사용')

    # 직접 바이너리 패치 (CAB 건드리지 않고 resS만 수정)
    rebuilt = {}
    if modified_by_cab:
        print('  텍스처 패치 중...')
        rebuilt = _rebuild_textures_direct(out_dir, modified_by_cab, dirs_orig, total_data_orig)

    # 각 dir 파일 결정
    new_dir_data = {}
    for d in dirs_orig:
        dname   = d['name']
        is_ress = dname.endswith('.resS')
        cab_dir = os.path.join(out_dir, dname[:-5] if is_ress else dname)
        raw_path = os.path.join(cab_dir, dname)

        if dname in rebuilt:
            new_dir_data[dname] = rebuilt[dname]
            print(f'  교체: {dname}  ({len(rebuilt[dname]):,} bytes)')
        elif os.path.exists(raw_path):
            file_bytes = open(raw_path, 'rb').read()
            orig_bytes = total_data_orig[d['offset']:d['offset']+d['size']]
            new_dir_data[dname] = file_bytes
            action = '변경' if file_bytes != orig_bytes else '유지'
            print(f'  {action}: {dname}')
        else:
            orig_bytes = total_data_orig[d['offset']:d['offset']+d['size']]
            new_dir_data[dname] = orig_bytes
            print(f'  유지: {dname} (원본)')

    # 새 데이터 영역 조립
    new_total = b''
    dirs_updated = []
    offset = 0
    for d in dirs_orig:
        chunk = new_dir_data[d['name']]
        dirs_updated.append(dict(offset=offset, size=len(chunk),
                                  status=d['status'], name=d['name']))
        new_total += chunk
        offset += len(chunk)

    # 128KB 블록 분할 (비압축)
    blocks_new = []
    for i in range(0, len(new_total), BLOCK_SIZE):
        sz = min(BLOCK_SIZE, len(new_total) - i)
        blocks_new.append(dict(uncomp=sz, comp=sz, flags=0x0000))

    bi_data  = _build_block_info(dirs_updated, blocks_new)
    hdr_end  = len(_build_header(hdr_orig, 0, 0, 0))
    pad_sz   = (16 - hdr_end % 16) % 16
    d_start  = hdr_end + pad_sz + len(bi_data)
    file_tail = bytes.fromhex(meta['original_tail'])
    bundle_sz = d_start + len(new_total) + len(file_tail)

    result  = _build_header(hdr_orig, bundle_sz,
                             hdr_orig['comp_bi_sz'], hdr_orig['uncomp_bi_sz'])
    result += b'\x00' * pad_sz
    result += bi_data
    result += new_total
    result += file_tail

    open(out_path, 'wb').write(result)
    print(f'\n재패킹 완료: {out_path}')
    print(f'  원본: {len(orig_data):,} bytes  →  결과: {len(result):,} bytes')


# ═══════════════════════════════════════════════════════════════════════
#  CLI
# ═══════════════════════════════════════════════════════════════════════

def main():
    if len(sys.argv) < 3:
        print(__doc__)
        sys.exit(1)

    cmd = sys.argv[1]
    if cmd == 'extract':
        bundle_path = sys.argv[2]
        out_dir     = sys.argv[3] if len(sys.argv) > 3 else 'bundle_out'
        extract(bundle_path, out_dir)

    elif cmd == 'rebuild':
        bundle_path = sys.argv[2]
        out_dir     = sys.argv[3]
        out_path    = sys.argv[4] if len(sys.argv) > 4 else bundle_path + '.new'
        print(f'리팩: {bundle_path}  +  {out_dir}  →  {out_path}\n')
        rebuild(bundle_path, out_dir, out_path)

    else:
        print(f'알 수 없는 명령: {cmd}'); sys.exit(1)

if __name__ == '__main__':
    main()
