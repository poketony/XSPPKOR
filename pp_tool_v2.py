#!/usr/bin/env python3
"""
pl_ 스크립트 파서 개선 버전
- 텍스트 누락 해결
- 중복 문자열 주석 표시
"""

import struct

SCRIPT_ENC = 'cp932'

# pl_ block_0 opcode
_PL_OP_NAME = 20   # ScrSetName  - 화자 이름
_PL_OP_MSG  = {4, 7, 26, 27}  # ScrMessage 계열 - 대사

_PL_OP_SIZE = {
    0:  8,   2:  1,   3:  1,   4:  2,   5:  5,
    6:  5,   7:  4,   11: 8,   12: 8,   13: 2,
    14: 0,   15: 2,   16: 2,   17: 4,   18: 2,
    19: 0,   20: 2,   21: 0,   22: 2,   23: 2,
    24: 4,   25: 4,   26: 4,   27: 4,   28: 0,
    29: 2,   30: 2,   31: 2,   32: 2,   33: 2,
    34: 2,   35: 2,   36: 2,   37: 2,   38: 2,
    39: 2,   40: 2,   41: 2,   42: 2,   43: 2,
    44: 4,   45: 4,   46: 4,   47: 4,   48: 4,
    49: 2,   50: 2,   51: 2,   52: 2,   53: 2,
    54: 2,   55: 2,   56: 2,   57: 2,   58: 2,
    59: 2,   60: 2,   61: 2,   95: 2,   102: 2,
    104: 2,  105: 2,
}

def _find_text_start(b0):
    """
    opcode를 정확히 따라가면서 텍스트 영역의 시작점 찾기
    """
    ptrs = []
    i = 0
    
    while i < len(b0) - 2:
        op = b0[i]
        size = _PL_OP_SIZE.get(op, -1)
        
        if size < 0:
            i += 1
            continue
        
        # opcode별 포인터 추출
        if op == 4 or op == 20:
            if i + 2 < len(b0):
                ptr = b0[i+1] | (b0[i+2] << 8)
                if ptr > 0:
                    ptrs.append(ptr)
            i += 1 + size
        elif op in (7, 26, 27):
            if i + 4 < len(b0):
                ptr = b0[i+3] | (b0[i+4] << 8)
                if ptr > 0:
                    ptrs.append(ptr)
            i += 1 + size
        else:
            i += 1 + size
    
    return min(ptrs) if ptrs else len(b0)

def _is_valid_text(b0, ptr, text_start):
    """
    포인터가 유효한 텍스트를 가리키는지 확인
    """
    # 범위 검증
    if ptr < text_start or ptr >= len(b0) - 1:
        return False
    
    # null-null 종료 찾기
    nul = b0.find(b'\x00\x00', ptr)
    if nul == -1 or nul == ptr:
        return False
    
    chunk = b0[ptr:nul]
    
    # CP932 디코딩 가능성 확인
    try:
        txt = chunk.decode(SCRIPT_ENC)
    except:
        return False
    
    # 제어문자 확인 (0x00~0x1F)
    if any(ord(c) < 0x20 for c in txt):
        return False
    
    # 최소 길이 확인
    if len(txt) < 1:
        return False
    
    return True

def _read_str(b0, ptr):
    """ptr 위치의 null-null 종료 CP932 문자열 읽기"""
    nul = b0.find(b'\x00\x00', ptr)
    chunk = b0[ptr:nul] if nul != -1 else b0[ptr:]
    try:
        return chunk.decode(SCRIPT_ENC)
    except:
        return chunk.decode(SCRIPT_ENC, errors='replace')

def parse_plscript_v2(b0):
    """
    개선된 pl_ 스크립트 파서
    """
    # 1단계: 텍스트 영역 시작점 정확히 파악
    text_start = _find_text_start(b0)
    
    # 2단계: 모든 유효한 포인터 수집
    ptr_to_texts = {}  # ptr -> text
    text_to_ptrs = {}  # text -> [ptr 리스트]
    
    i = 0
    while i < len(b0) - 2:
        op = b0[i]
        size = _PL_OP_SIZE.get(op, -1)
        
        if size < 0:
            i += 1
            continue
        
        if op == 4 or op == 20:
            if i + 2 < len(b0):
                ptr = b0[i+1] | (b0[i+2] << 8)
                if _is_valid_text(b0, ptr, text_start):
                    txt = _read_str(b0, ptr)
                    if txt:
                        if ptr not in ptr_to_texts:
                            ptr_to_texts[ptr] = txt
                        if txt not in text_to_ptrs:
                            text_to_ptrs[txt] = []
                        if ptr not in text_to_ptrs[txt]:
                            text_to_ptrs[txt].append(ptr)
            i += 1 + size
        
        elif op in (7, 26, 27):
            if i + 4 < len(b0):
                ptr = b0[i+3] | (b0[i+4] << 8)
                if _is_valid_text(b0, ptr, text_start):
                    txt = _read_str(b0, ptr)
                    if txt:
                        if ptr not in ptr_to_texts:
                            ptr_to_texts[ptr] = txt
                        if txt not in text_to_ptrs:
                            text_to_ptrs[txt] = []
                        if ptr not in text_to_ptrs[txt]:
                            text_to_ptrs[txt].append(ptr)
            i += 1 + size
        
        else:
            i += 1 + size
    
    # 3단계: 씬 구성
    scenes = []
    current = None
    
    i = 0
    while i < len(b0) - 2:
        op = b0[i]
        size = _PL_OP_SIZE.get(op, -1)
        
        if size < 0:
            i += 1
            continue
        
        if op == 4 or op == 20:
            if i + 2 < len(b0):
                ptr = b0[i+1] | (b0[i+2] << 8)
                if ptr in ptr_to_texts:
                    text = ptr_to_texts[ptr]
                    is_duplicate = len(text_to_ptrs.get(text, [])) > 1
                    
                    if op == 20:
                        # 화자 변경
                        if current and current['lines']:
                            scenes.append(current)
                        current = {
                            'speaker': text,
                            'speaker_trans': '',
                            'lines': [],
                            'trans': [],
                        }
                        if is_duplicate:
                            current['_speaker_note'] = '  // 중복'
                    else:
                        # 대사
                        if current is None:
                            current = {
                                'speaker': '',
                                'speaker_trans': '',
                                'lines': [],
                                'trans': [],
                            }
                        current['lines'].append(text)
                        current['trans'].append('')
                        if is_duplicate:
                            if '_lines_notes' not in current:
                                current['_lines_notes'] = [''] * (len(current['lines']) - 1)
                            current['_lines_notes'].append('  // 중복')
                        else:
                            if '_lines_notes' not in current:
                                current['_lines_notes'] = [''] * (len(current['lines']) - 1)
                            current['_lines_notes'].append('')
            
            i += 1 + size
        
        elif op in (7, 26, 27):
            if i + 4 < len(b0):
                ptr = b0[i+3] | (b0[i+4] << 8)
                if ptr in ptr_to_texts:
                    text = ptr_to_texts[ptr]
                    is_duplicate = len(text_to_ptrs.get(text, [])) > 1
                    
                    if current is None:
                        current = {
                            'speaker': '',
                            'speaker_trans': '',
                            'lines': [],
                            'trans': [],
                        }
                    
                    current['lines'].append(text)
                    current['trans'].append('')
                    
                    if is_duplicate:
                        if '_lines_notes' not in current:
                            current['_lines_notes'] = [''] * (len(current['lines']) - 1)
                        current['_lines_notes'].append('  // 중복')
                    else:
                        if '_lines_notes' not in current:
                            current['_lines_notes'] = [''] * (len(current['lines']) - 1)
                        current['_lines_notes'].append('')
            
            i += 1 + size
        
        else:
            i += 1 + size
    
    if current and current['lines']:
        scenes.append(current)
    
    return scenes


if __name__ == '__main__':
    import json
    
    # block_0.bin 테스트
    with open('block_0.bin', 'rb') as f:
        b0 = f.read()
    
    scenes = parse_plscript_v2(b0)
    
    print(f"총 {len(scenes)}개 씬 추출됨\n")
    
    for idx, scene in enumerate(scenes):
        print(f"=== Scene {idx} ===")
        speaker_note = scene.get('_speaker_note', '')
        print(f"Speaker: {scene['speaker']}{speaker_note}")
        print(f"Lines ({len(scene['lines'])}개):")
        
        notes = scene.get('_lines_notes', [''] * len(scene['lines']))
        for line_idx, (line, note) in enumerate(zip(scene['lines'], notes)):
            print(f"  [{line_idx}] {line}{note}")
        print()
    
    # JSON 출력
    output = []
    for scene in scenes:
        entry = {
            'speaker': scene['speaker'],
            'speaker_trans': scene['speaker_trans'],
            'lines': scene['lines'],
            'trans': scene['trans'],
        }
        if '_speaker_note' in scene:
            entry['_speaker_note'] = scene['_speaker_note']
        if '_lines_notes' in scene:
            entry['_lines_notes'] = scene['_lines_notes']
        output.append(entry)
    
    with open('script_v2.json', 'w', encoding='utf-8') as f:
        json.dump(output, f, ensure_ascii=False, indent=2)
    
    print(f"\nJSON 저장: script_v2.json")
