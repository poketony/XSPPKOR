# manual_rescue 사용법: 누락 스크립트 수동 추가 보험 장치

`pp_tool_xscript_vm_v5.py`는 파서가 놓친 문자열도 `script.json`에 직접 추가하면 repack 때 반영할 수 있게 만든 버전입니다.

## 1. 가장 중요한 개념

block_0.bin에서 문자열을 발견했을 때 확인해야 하는 값은 두 종류입니다.

| 이름 | 의미 | 예시 |
|---|---|---:|
| `manual_ptrs` | 원문 문자열이 실제로 시작되는 오프셋 | `7444` |
| `manual_ptr_positions` | 스크립트 명령 안에 적힌 2바이트 포인터의 위치 | `1836` |

대부분은 `manual_ptrs`만 있어도 짧은 번역은 in-place로 반영됩니다. 하지만 번역문이 원문보다 길면 반드시 `manual_ptr_positions`가 필요합니다. 그래야 번역문을 파일 끝에 새로 붙인 뒤, 스크립트 명령의 포인터를 새 위치로 바꿀 수 있습니다.

## 2. 추천 형식

`script.json` 맨 끝에 아래 항목을 추가합니다.

```json
{
  "scene": 999999,
  "marker": "manual_rescue",
  "speaker_pos": -1,
  "speaker_ptr": -1,
  "msg_positions": [1836],
  "msg_ptrs": [7444],
  "manual_ptrs": [7444],
  "manual_ptr_positions": [[1836]],
  "speaker": "",
  "speaker_trans": "",
  "lines": [
    "ダイビングデバイスだ。"
  ],
  "trans": [
    "다이빙 디바이스다."
  ],
  "line_notes": [
    "수동 추가: block_0.bin offset 7444"
  ]
}
```

`manual_ptr_positions`는 줄마다 여러 후보를 넣을 수 있으므로 이중 배열을 권장합니다.

```json
"manual_ptr_positions": [[1836, 1920]]
```

## 3. 포인터 위치를 모를 때

문자열 시작 오프셋만 아는 경우에는 이렇게 넣습니다.

```json
{
  "scene": 999999,
  "marker": "manual_rescue",
  "speaker_pos": -1,
  "speaker_ptr": -1,
  "msg_positions": [-1],
  "msg_ptrs": [7444],
  "manual_ptrs": [7444],
  "speaker": "",
  "speaker_trans": "",
  "lines": [
    "ダイビングデバイスだ。"
  ],
  "trans": [
    "다이빙 디바이스다."
  ],
  "line_notes": [
    "수동 추가: 포인터 위치 미확인, in-place 패치"
  ]
}
```

이 경우 repack은 원문 문자열 자리에서 직접 바꿉니다. 단, 번역문의 인코딩 바이트 길이가 원문 공간보다 길면 반영하지 않고 경고를 출력합니다.

## 4. 여러 줄을 한 번에 추가하기

```json
{
  "scene": 999999,
  "marker": "manual_rescue",
  "speaker_pos": -1,
  "speaker_ptr": -1,
  "msg_positions": [1836, 1839, 1842],
  "msg_ptrs": [7444, 7468, 7498],
  "manual_ptrs": [7444, 7468, 7498],
  "manual_ptr_positions": [[1836], [1839], [1842]],
  "speaker": "",
  "speaker_trans": "",
  "lines": [
    "ダイビングデバイスだ。",
    "既に仮想空間へのダイブ準備が",
    "整っている。"
  ],
  "trans": [
    "다이빙 디바이스다.",
    "이미 가상 공간으로의",
    "다이브 준비가 끝나 있다."
  ],
  "line_notes": [
    "수동 추가",
    "수동 추가",
    "수동 추가"
  ]
}
```

## 5. block_0.bin에서 포인터 위치 찾는 법

예를 들어 누락 문자열 시작 오프셋이 `7444`라면, 16진수로는 `0x1D14`입니다. 이 게임의 포인터는 little-endian 2바이트이므로 바이트 패턴은 다음입니다.

```text
14 1D
```

헥스 에디터에서 `14 1D`를 검색합니다. 검색된 위치가 `manual_ptr_positions` 후보입니다. 단, 문자열 내부나 다른 데이터일 수도 있으므로 주변 바이트가 메시지 opcode인지 확인하면 좋습니다.

주요 opcode 기준:

| opcode | 의미 | 포인터 위치 |
|---:|---|---|
| `04` | ScrMessage | opcode 바로 다음 2바이트 |
| `14` / decimal 20 | ScrSetName | opcode 바로 다음 2바이트 |
| `24` / decimal 36 | ScrMessageNW | opcode 바로 다음 2바이트 |
| `07`, `1A`, `1B` | ScrMessageY 계열 | opcode + 3 위치의 2바이트 |

예시:

```text
04 14 1D
```

이 경우 `04`가 opcode이고, `14 1D`가 포인터입니다. 따라서 `manual_ptr_positions`는 `14`가 있는 오프셋입니다. 즉 opcode 위치가 `1835`라면 포인터 위치는 `1836`입니다.

## 6. repack 때의 동작

- `manual_ptr_positions`가 있으면 번역문을 block_0.bin 끝에 추가하고, 해당 포인터 위치를 새 주소로 바꿉니다.
- `manual_ptr_positions`가 없으면 원문 문자열 위치에 직접 덮어씁니다.
- 직접 덮어쓰기에 공간이 부족하면 원문을 보존하고 경고를 출력합니다.

따라서 가장 안전한 방식은 항상 `manual_ptrs`와 `manual_ptr_positions`를 함께 적는 것입니다.

## 7. 권장 작업 흐름

1. 검증 보고서에서 누락 문자열과 오프셋 확인
2. block_0.bin에서 해당 오프셋을 16진수 little-endian으로 검색
3. 주변 opcode를 확인해 포인터 위치 확정
4. `script.json` 끝에 `manual_rescue` 항목 추가
5. `trans` 입력
6. repack 실행
7. 다시 검증 보고서 실행

