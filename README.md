<img width="782" height="360" alt="Image" src="https://github.com/user-attachments/assets/2b323fa7-f54a-4423-ac1d-eb9fa7026c70" />

# Xenosaga Pied Piper 한국어화

> **프로젝트 상태: 완료** — 6개 장의 본편 대사와 도움말, 메뉴·전투 UI, 글꼴, 타이틀과 안내 이미지를 포함한 한국어화 결과물이 `PatchPack/PatchedFiles`에 정리되어 있습니다.

> **대상 버전:** [Steam판 G-MODE 아카이브스+ 제노사가 Pied Piper](https://store.steampowered.com/app/4532150/GMODE/?l=koreana) (App ID `4532150`)

이 저장소는 Xenosaga Pied Piper의 한국어화 결과와 그 결과를 다시 만들고 점검하는 데 사용한 자료를 함께 보관합니다. 완성 파일만 모아 둔 배포 폴더 외에도, 6개 장의 편집 가능한 스크립트, 도움말 원문과 번역문, 문자표, 이미지 작업 자료, 관리 코드 참고 소스, 추출·재구성·검증 도구가 남아 있습니다. 번역을 고치거나 파일 구조를 확인하려는 사람이 같은 과정을 다시 따라갈 수 있도록 실제 작업 단위를 기준으로 구성했습니다.

오랜 기간 실제 플레이와 반복 재구성을 거쳐 마무리한 독립 커뮤니티 프로젝트입니다. 원작과 제작진의 작업을 존중하며, 이 저장소는 원작을 대신하지 않습니다. 적용과 재구성에는 사용자가 소유한 정식 설치본이 필요합니다.

## English summary

This repository targets the [Steam release of G-MODE Archives+ Xenosaga Pied Piper](https://store.steampowered.com/app/4532150/GMODE/?l=koreana), App ID `4532150`. It contains the completed Korean localization together with its reproducible working data: six chapters of editable dialogue scripts, help-text sources, a custom character map, localized image sources, reference managed-code sources, final replacement files, and Python tools for extracting, rebuilding, and validating the relevant containers.

It is intended for players applying the completed files, translators revising text, and developers or technical researchers auditing the formats. The documented working directory is `StreamingAssets/aa/StandaloneWindows64/file`. Commands below are written for PowerShell on Windows and use repository-relative paths so the checkout can be moved without editing commands.

## Project status and scope

| Area | Status | Repository evidence |
| --- | --- | --- |
| Final replacement set | Complete | 15 files under [`PatchPack/PatchedFiles`](PatchPack/PatchedFiles) |
| Chapter scripts | Complete | Editable `script.json` data for PP01–PP06 under [`WorkSpace`](StreamingAssets/aa/StandaloneWindows64/file/WorkSpace) |
| Help text | Complete | Per-chapter `help0.txt`, rebuilt `help0.xhf`, offset tables, and rebuild scripts |
| UI and font integration | Complete in the shipped files | Managed assembly, UI bundles, font bundles, and shared assets are included in the replacement set |
| Title and guide images | Complete in the shipped files | Localized sources and extraction metadata are retained under [`StandaloneWindows64`](StreamingAssets/aa/StandaloneWindows64) |
| Rebuild validation | Available | DAT round-trip verification and help-text format checks are implemented by the repository tools |

The repository records a finished localization, not a general-purpose localization framework. The tools are format-specific and assume the file layouts and managed-code patterns documented here.

## What is implemented

- Extraction and rebuilding of the six `xenosagapp1.dat` through `xenosagapp6.dat` chapter archives.
- JSON editing for ordinary script pools and VM-based `block_0.bin` dialogue, with speaker and message pointers kept separately.
- A conservative raw-string rescue path for plausible CP932 text not reached by VM disassembly.
- GIF/PNG replacement inside chapter archives while retaining unchanged archive members byte-for-byte.
- Automatic recalculation of chapter archive sizes and the corresponding managed-code size tables.
- Custom Korean character-map integration and managed decoding-table updates.
- Reference managed-code sources for system messages, menu text, text layout, and chapter-specific UI behavior.
- Extraction, validation, and rebuilding of `.xhf` help text with recalculated TOC/section offsets and exported offset tables.
- UnityFS extraction and rebuilding for selected uncompressed streamed `Texture2D` formats, with PNG change detection and exact raw-size checks.
- A final replacement tree that mirrors only the paths required by the installed game.

## End-to-end workflow

```text
Owned installation
  ├─ chapter DAT files ──> extract/verify ──> edit WorkSpace/pp01..pp06
  │                                              └─ repack_all
  │                                                   ├─ xenosagapp1_new.dat .. xenosagapp6_new.dat
  │                                                   └─ Assembly-CSharp.dll.new
  │                                                        ▲
  │                         system/UI text ──> dnSpy edits ─┘
  │
  ├─ original file_assets bundle + six _new.dat files ──> UABEA
  │                                                        └─ rebuilt file_assets bundle
  │
  ├─ image bundles ──────> unityfs_toolkit extract ──> edit supported PNGs
  │                                                    └─ unityfs_toolkit rebuild
  │
  └─ clean installed files <──────────────────────── final replacement files
                                                       in PatchPack/PatchedFiles
```

The six `_new.dat` files are intermediate members of the rebuilt file bundle. Do **not** copy them into the game directory as six loose files. For installation, use only the final tree under `PatchPack/PatchedFiles`, preserving its relative paths.

## Working directory layout

The primary command examples start here:

```powershell
Set-Location .\StreamingAssets\aa\StandaloneWindows64\file
```

```text
file/
├─ pp_tool_xscript_vm_v5.py       # chapter DAT extract/repack/verify CLI
├─ xscript_vm_parser_core_v5.py   # VM parser and conservative raw-string rescue
├─ xenosaga_charmap.json          # character encode/decode mapping
├─ ppfiles/                        # baseline xenosagapp1.dat ... xenosagapp6.dat
├─ WorkSpace/
│  ├─ pp01/ ... pp06/              # translated script/image working trees
│  └─ ppXX/help0/
│     ├─ help0.xhf.ori             # structural template
│     ├─ help0.txt                 # translated editable text
│     ├─ help0.xhf                 # rebuilt help file
│     ├─ help_offsets.json         # rebuilt managed-code section offsets
│     └─ RepackHelp0.bat           # CMD wrapper for the chapter
└─ output/                         # generated DATs and managed assembly
```

Other top-level areas have different roles:

| Path | Purpose |
| --- | --- |
| [`PatchPack/PatchedFiles`](PatchPack/PatchedFiles) | Finished files laid out for installation |
| [`StreamingAssets/aa/StandaloneWindows64`](StreamingAssets/aa/StandaloneWindows64) | Bundle tooling, image sources, fonts, localization data, and chapter work area |
| [`Managed/Assembly-CSharp`](Managed/Assembly-CSharp) | Reference managed-code source used to study UI, text decoding, and file tables |
| [`기타 자료`](기타%20자료) | Design sources and supplementary project records; not part of the automated build |

## Requirements

- Windows PowerShell or Command Prompt.
- Python 3.10 or newer. The repository was checked with Python 3.12.
- For `unityfs_toolkit.py`: `UnityPy` and Pillow.
- Enough free space for extracted chapter data and rebuilt bundles.
- A clean, user-owned installation for both input files and recovery.
- dnSpy for manual managed-assembly edits that are outside the Python patcher's scope.
- UABEA for importing rebuilt chapter DAT payloads into the final `file_assets` bundle and for inspecting other serialized assets.

Install the optional bundle dependencies:

```powershell
python -m pip install UnityPy Pillow
```

Use `python -X utf8` in commands below. It keeps Korean paths and the tool's Unicode status characters reliable on Windows consoles whose default code page is not UTF-8.

No package lock or automated dependency installer is included. The reference solution under `Managed` also depends on engine/runtime assemblies from an owned installation and is not the supported way to produce the final managed DLL.

dnSpy and UABEA are separate tools and are not part of the tracked reproducible source set. Obtain them from their respective maintained distributions. Work on copies of the original files and save to new output paths until the rebuilt files have been tested.

## Quick start: install the completed localization

Start with a clean installed copy and keep a backup or use the platform's file verification feature for recovery. From the repository root, copy the **contents** of `PatchPack/PatchedFiles` into the game's data directory—the directory that already contains `Managed`, `StreamingAssets`, and `sharedassets0.assets`—and allow these 15 destination files to be replaced.

```powershell
$Source = '.\PatchPack\PatchedFiles'
$GameData = '.\GameData' # example: the installed directory containing Managed and StreamingAssets

$Files = @(
  'sharedassets0.assets',
  'Managed\Assembly-CSharp.dll',
  'StreamingAssets\aa\catalog.bin',
  'StreamingAssets\aa\StandaloneWindows64\achiveui-font_assets_all_05a456489c03e97b882dfe9ffc1291f0.bundle',
  'StreamingAssets\aa\StandaloneWindows64\achiveui-guide_assets_all_bb93d33cea1ea1de8b47b6a27bd20818.bundle',
  'StreamingAssets\aa\StandaloneWindows64\achiveui-title_assets_all_f0c5401fcb7f0d787b09389edc9189dd.bundle',
  'StreamingAssets\aa\StandaloneWindows64\achiveui_assets_all_18efe090550ed488f0f98f43bf397d66.bundle',
  'StreamingAssets\aa\StandaloneWindows64\data_assets_all_aa46b5304ea45513b3cef285083a229e.bundle',
  'StreamingAssets\aa\StandaloneWindows64\file_assets_all_aaa3385ba5ba8c4b94a5be3e41463df9.bundle',
  'StreamingAssets\aa\StandaloneWindows64\font_assets_all_06016770435369903a158c5976a7ac43.bundle',
  'StreamingAssets\aa\StandaloneWindows64\prefab-characterinput.prefab_assets_all_1a2e4590eae1eb254c0f600b20fb740d.bundle',
  'StreamingAssets\aa\StandaloneWindows64\prefab-dialogcommon.prefab_assets_all_a00fb7a26f38f581445639d2dad001ce.bundle',
  'StreamingAssets\aa\StandaloneWindows64\prefab-setting.prefab_assets_all_830b04fdc91bfdf17819c29b540463bc.bundle',
  'StreamingAssets\aa\StandaloneWindows64\prefab-title.prefab_assets_all_31b8a6316a7bf454f8d6ef4c5e1791cd.bundle',
  'StreamingAssets\aa\StandaloneWindows64\prefab-window.prefab_assets_all_21020f24ff688ed33cff4e54d4ddca2c.bundle'
)

foreach ($File in $Files) {
  Copy-Item -LiteralPath (Join-Path $Source $File) -Destination (Join-Path $GameData $File) -Force
}
```

`GameData` is an example local folder name. Replace it with the installed data directory on your machine. The loop copies only the 15 literal relative paths listed above; it does not create missing destination directories. A clean installation already has those parent directories. Do not copy the repository's entire `StreamingAssets`, `Managed`, or `file` working directories into the installation.

### Exact final-file mapping

Every source below is under `PatchPack/PatchedFiles`; the destination path is identical relative to the installed data directory.

| Final relative path | Role |
| --- | --- |
| `sharedassets0.assets` | Shared asset data |
| `Managed/Assembly-CSharp.dll` | Managed localization and runtime tables |
| `StreamingAssets/aa/catalog.bin` | Addressable content catalog |
| `StreamingAssets/aa/StandaloneWindows64/achiveui-font_assets_all_05a456489c03e97b882dfe9ffc1291f0.bundle` | Archive UI fonts |
| `StreamingAssets/aa/StandaloneWindows64/achiveui-guide_assets_all_bb93d33cea1ea1de8b47b6a27bd20818.bundle` | Guide images |
| `StreamingAssets/aa/StandaloneWindows64/achiveui-title_assets_all_f0c5401fcb7f0d787b09389edc9189dd.bundle` | Title images |
| `StreamingAssets/aa/StandaloneWindows64/achiveui_assets_all_18efe090550ed488f0f98f43bf397d66.bundle` | Archive UI localization |
| `StreamingAssets/aa/StandaloneWindows64/data_assets_all_aa46b5304ea45513b3cef285083a229e.bundle` | Localization data |
| `StreamingAssets/aa/StandaloneWindows64/file_assets_all_aaa3385ba5ba8c4b94a5be3e41463df9.bundle` | Six rebuilt chapter archives and help data |
| `StreamingAssets/aa/StandaloneWindows64/font_assets_all_06016770435369903a158c5976a7ac43.bundle` | In-game fonts |
| `StreamingAssets/aa/StandaloneWindows64/prefab-characterinput.prefab_assets_all_1a2e4590eae1eb254c0f600b20fb740d.bundle` | Character-input UI |
| `StreamingAssets/aa/StandaloneWindows64/prefab-dialogcommon.prefab_assets_all_a00fb7a26f38f581445639d2dad001ce.bundle` | Common dialogs |
| `StreamingAssets/aa/StandaloneWindows64/prefab-setting.prefab_assets_all_830b04fdc91bfdf17819c29b540463bc.bundle` | Settings UI |
| `StreamingAssets/aa/StandaloneWindows64/prefab-title.prefab_assets_all_31b8a6316a7bf454f8d6ef4c5e1791cd.bundle` | Title UI |
| `StreamingAssets/aa/StandaloneWindows64/prefab-window.prefab_assets_all_21020f24ff688ed33cff4e54d4ddca2c.bundle` | Window UI |

## Rebuild the chapter data

### 1. Preserve the translated workspace

`extract` and `extract_all` create directories with `exist_ok=True` and write files using normal write mode. Running either command directly against the tracked `WorkSpace` can overwrite translated `script.json` and extracted images. Extract clean inputs to a separate directory when auditing or starting a new translation pass.

```powershell
Set-Location .\StreamingAssets\aa\StandaloneWindows64\file
python -X utf8 .\pp_tool_xscript_vm_v5.py extract_all .\ppfiles .\FreshExtract
```

Input filenames must be exactly `xenosagapp1.dat` through `xenosagapp6.dat`. Missing chapters are reported and skipped. Output directories are `FreshExtract/pp01` through `FreshExtract/pp06`.

### 2. Edit scripts

Most editable scene files are named `script.json`. Ordinary entries use the following fields:

```json
{
  "scene": 0,
  "marker": "0x1b00",
  "ptr_positions": [50, 55],
  "lines": ["ホアキン", "ママ！"],
  "trans": ["호아킨", "엄마!"]
}
```

Edit `trans`; retain the structural fields and array alignment. A blank or whitespace-only translation falls back to the original text. VM-parsed scenes may instead expose `speaker`, `speaker_trans`, `msg_positions`, and `msg_ptrs`. Their pointer fields are rebuild metadata and should not be hand-edited unless performing a documented rescue.

For unresolved VM strings, read [`manual_rescue_guide.md`](StreamingAssets/aa/StandaloneWindows64/file/manual_rescue_guide.md). When a pointer operand is known, rebuilt text is appended and the 16-bit little-endian pointer is relocated. Without a pointer position, the tool attempts an in-place replacement and refuses translations that exceed the original byte allocation.

The parser core also has a diagnostic CLI for a raw VM `block_0.bin` obtained during archive analysis:

```powershell
python -X utf8 .\xscript_vm_parser_core_v5.py .\raw\block_0.bin .\raw\block_0.scenes.json
```

The first path is the raw block; the optional second path receives UTF-8 JSON and is overwritten if it exists. Without the second path, JSON is printed to standard output. This parser intentionally stops at conservative VM boundaries, keeps name and dialogue operands distinct, and appends plausible unreferenced CP932 strings as `raw_rescue` entries instead of treating them as confirmed dialogue. It is used internally by the main chapter tool; most translation work should use the generated `script.json` rather than invoke the parser directly.

### 3. Verify clean round trips

`verify` extracts one DAT to a temporary directory, rebuilds it without edits, and compares each inner file's CRC and uncompressed size.

```powershell
python -X utf8 .\pp_tool_xscript_vm_v5.py verify 1 .\ppfiles\xenosagapp1.dat
```

The chapter number is required and must be `1`–`6`. A successful run ends with `모든 파일 일치 ✓`. This checks a no-edit round trip; it does not validate translation wording or rendering.

### 4. Rebuild all six chapters and managed tables

Use a clean output directory. Place the baseline `Assembly-CSharp.dll` in it before running the command; the tool copies it to `Assembly-CSharp.dll.new` and patches the copy.

```powershell
New-Item -ItemType Directory -Force .\rebuild | Out-Null
Copy-Item -LiteralPath .\Assembly-CSharp.dll -Destination .\rebuild\Assembly-CSharp.dll
python -X utf8 .\pp_tool_xscript_vm_v5.py repack_all .\ppfiles .\WorkSpace .\rebuild .\rebuild\Assembly-CSharp.dll
```

Outputs:

| Generated file | Meaning | Final name/location |
| --- | --- | --- |
| `rebuild/xenosagapp1_new.dat` … `xenosagapp6_new.dat` | Rebuilt chapter members | Keep as intermediates; package them into the final `file_assets…bundle` |
| `rebuild/Assembly-CSharp.dll.new` | Managed assembly with rebuilt sizes, help offsets, and Korean decode mappings | Rename to `Assembly-CSharp.dll` only when placing it at `Managed/Assembly-CSharp.dll` |

If an input DAT or matching `WorkSpace/ppXX` directory is missing, that chapter is skipped. If the managed DLL cannot be found, DAT rebuilding still completes and managed-table patching is skipped. Existing output files are overwritten; no automatic backup is made.

`RepackAllPP.bat` is the CMD wrapper for the repository's fixed layout. It runs `repack_all ppfiles WorkSpace output` and then pauses. Use the explicit PowerShell command above when you need a clean output directory or an explicit managed-DLL input.

### Single-chapter commands

```powershell
python -X utf8 .\pp_tool_xscript_vm_v5.py extract 1 .\ppfiles\xenosagapp1.dat .\FreshExtract\pp01
python -X utf8 .\pp_tool_xscript_vm_v5.py repack 1 .\ppfiles\xenosagapp1.dat .\WorkSpace\pp01 .\rebuild\xenosagapp1_new.dat
```

For a single `repack`, managed-code patching is attempted in the DAT output directory. If `Assembly-CSharp.dll.new` exists there, it is patched in place. Otherwise `Assembly-CSharp.dll` is copied to `.new` first. Keep output separate from baseline inputs to avoid accidentally continuing from a previously patched `.new` file.

### DAT rebuild safeguards

- Unchanged subarchives and raw members are copied from the original byte stream.
- Images are replaced only when the extracted GIF/PNG differs from the original member.
- Scripts are rebuilt only when at least one `trans` or `speaker_trans` value is nonblank.
- The output DAT is padded to the original size when smaller; the command prints a size mismatch if rebuilt content exceeds it.
- Ordinary script text pools are rebuilt and their pointers are recalculated.
- VM script translations are appended and known pointer operands are updated; new offsets above `0xFFFF` are reported and not written.
- Rescue translations without a known pointer position are never truncated to fit; insufficient in-place space produces a warning and preserves the original bytes.
- Managed help-offset arrays are changed only when the expected original array occurs exactly once and the new section count matches.
- Character-map integration patches Korean entries in the located decode table; a missing anchor is reported instead of guessed.

## Manual integration not covered by the Python tools

The Python tools automate the chapter containers and a narrow set of managed tables. They do **not** complete every localization edit by themselves. A localization in another language must also account for managed system/UI strings and must import the rebuilt DAT payloads into the serialized file bundle.

### System and UI messages: edit `Assembly-CSharp.dll` with dnSpy

System messages, menu labels, battle messages, save/load prompts, transfer prompts, and many screen coordinates are embedded in the managed assembly. The relevant chapter implementations are primarily `XenoPP01Canvas` through `XenoPP06Canvas`; readable reference sources are retained under [`Managed/Assembly-CSharp`](Managed/Assembly-CSharp).

Recommended order:

1. Copy the matching Steam build's clean `Managed/Assembly-CSharp.dll` to a separate work directory.
2. Open the copy in dnSpy and edit the required strings and layout constants. Use the reference sources to locate methods, and use `PatchPack/PatchedFiles/Managed/Assembly-CSharp.dll` as the completed Korean reference when comparing behavior.
3. Preserve method signatures, branches, field layout, and unrelated instructions. Text expansion often also requires coordinate or spacing changes; do not translate strings without reviewing their `DrawString` call sites.
4. Save the edited module as a new DLL.
5. Pass that DLL as the explicit final argument to `repack_all`. The Python tool then applies the rebuilt DAT size table, help-section offsets, and character decoding table to a copied `Assembly-CSharp.dll.new`.
6. Install the result as `Managed/Assembly-CSharp.dll` only after reviewing and testing it.

The automated DLL patcher does not translate these system messages. Its scope is limited to chapter archive size metadata, help offsets when the required files are present, and the configured character decoding table. The reference C# project is useful for inspection but is not a drop-in rebuild: it depends on runtime assemblies from the owned installation.

### Chapter payloads: import `_new.dat` files with UABEA

`repack_all` produces six complete DAT payloads, but the Steam build stores them as `TextAsset` payloads inside `file_assets_all_aaa3385ba5ba8c4b94a5be3e41463df9.bundle`. They are not installed as loose files.

Open a copy of the matching original bundle in UABEA, locate each `TextAsset`, and use the TextAsset data-import function to replace its `m_Script` payload according to this exact mapping:

| Generated payload | `TextAsset` name inside the bundle |
| --- | --- |
| `xenosagapp1_new.dat` | `xenosagapp1_SH900i0.scr` |
| `xenosagapp2_new.dat` | `xenosagapp2_SH900i0.scr` |
| `xenosagapp3_new.dat` | `xenosagapp3_SH900i0.scr` |
| `xenosagapp4_new.dat` | `xenosagapp4_SH900i0.scr` |
| `xenosagapp5_new.dat` | `xenosagapp5_SH900i0.scr` |
| `xenosagapp6_new.dat` | `xenosagapp6_SH900i0.scr` |

#### UABEA GUI sequence

Repeat the import step for all six mappings above:

1. Open `file_assets_all_aaa3385ba5ba8c4b94a5be3e41463df9.bundle` in UABEA.
2. Select **Info** to open the asset list.
3. Select the `TextAsset` to replace, matching its name exactly against the table above.
4. Choose **Plugins → Import .txt**, then select the corresponding `xenosagappN_new.dat` payload. The menu item is named `Import .txt`, but the imported bytes are the rebuilt DAT payload; do not convert or edit them as text.
5. In the **Info** window, choose **File → Save** to commit the imported asset data.
6. Close the **Info** window.
7. Back in the main UABEA window, choose **Save** and write the rebuilt bundle to a new output file.
8. Exit UABEA completely, start it again, and reopen the saved bundle. Recheck the six `TextAsset` names and imported sizes before installation.
9. Compression is optional. If desired, save the reopened bundle once more with compression enabled; the original bundle was compressed. Keep the uncompressed intermediate until the compressed output has been reopened and verified.

There are two distinct save operations: **File → Save** inside the **Info** window applies the selected asset changes, while **Save** in the main window writes the bundle itself. Skipping either one can leave the replacement unapplied.

Save the rebuilt container under a new name first, then give the tested result the original filename and place it at:

```text
StreamingAssets/aa/StandaloneWindows64/file_assets_all_aaa3385ba5ba8c4b94a5be3e41463df9.bundle
```

Do not import a DAT into an arbitrary `TextAsset` selected only by order or path ID. Match the names above, confirm all six imported byte sizes, reopen the saved bundle, and export or inspect the payloads again before installation. PP05 and PP06 can grow beyond their baseline DAT sizes; the managed size table must therefore come from the same `repack_all` run.

### Localizing the G-MODE Archives menu shell

The six chapter DATs and `Assembly-CSharp.dll` cover the game content and managed UI, but they are not the complete G-MODE Archives menu layer. For another-language localization, compare the matching original files with the finished files under [`PatchPack/PatchedFiles`](PatchPack/PatchedFiles) and inspect at least these groups:

| Final-file group | What to inspect |
| --- | --- |
| `achiveui_assets…bundle`, `data_assets…bundle` | Archive menu strings and localization data |
| `achiveui-title…bundle`, `achiveui-guide…bundle` | Title and control-guide images |
| `achiveui-font…bundle`, `font_assets…bundle` | Archive-menu and in-game fonts/glyph coverage |
| `prefab-characterinput…`, `prefab-dialogcommon…`, `prefab-setting…`, `prefab-title…`, `prefab-window…` | Serialized menu/dialog layouts and font assignments |
| `sharedassets0.assets` | Shared serialized resources used by the localized presentation |
| `catalog.bin` | The content catalog shipped with the completed replacement set |

Treat the `PatchPack` files as a completed reference, not as universal source files for every language or game revision. Start from the matching files in your owned Steam installation, reproduce only the required text, image, font, and layout changes with an appropriate serialized-asset editor, preserve unrelated objects, and validate the resulting menu flow in the target runtime. Copying only the chapter bundle will leave the outer archive menu untranslated.

## Help-text tool

Each chapter carries an identical CLI in `WorkSpace/ppXX/help0`. Run it from the main `file` directory with explicit paths.

### Check the tracked translation

```powershell
python -X utf8 .\WorkSpace\pp01\help0\xhf_text_tool_offsets_full.py check `
  .\WorkSpace\pp01\help0\help0.xhf.ori `
  .\WorkSpace\pp01\help0\help0.txt `
  --charmap .\WorkSpace\pp01\help0\xenosaga_charmap.json
```

`check` validates encodability, the 255-byte maximum for every text line, and the 255-line maximum for every section. It exits nonzero on errors.

### Extract and rebuild

```powershell
$Help = '.\WorkSpace\pp01\help0'
python -X utf8 "$Help\xhf_text_tool_offsets_full.py" extract "$Help\help0.xhf.ori" "$Help\help0_jpn.txt" --charmap "$Help\xenosaga_charmap.json"
python -X utf8 "$Help\xhf_text_tool_offsets_full.py" repack "$Help\help0.xhf.ori" "$Help\help0.txt" "$Help\help0.xhf" --charmap "$Help\xenosaga_charmap.json" --no-preserve-first-section-base --export-offsets "$Help\help_offsets.json"
```

The tracked `RepackHelp0.bat` files run the second command from their own directory and pause afterward; they are CMD wrappers, not PowerShell scripts.

Rebuilding recalculates all TOC and section offsets, self-parses the result, and exports `[0, section…]` to `help_offsets.json`. Missing TXT entries preserve template text by default. `--blank-missing` blanks them instead. Without `--no-preserve-first-section-base`, the tool pads the TOC region to retain the original first-section address and fails if translated TOC titles no longer fit.

Relevant optional arguments:

- `extract --charmap FILE` uses the custom mapping; without it, decoding falls back to standard Shift-JIS behavior.
- `repack --offset-format json|cs` selects the format written by `--export-offsets` (`json` is the default).
- `repack --patch-cs FILE` updates the first unambiguous `HelpInit` offset array in a reference C# file. Add `--patched-cs OUTPUT` to preserve the input; without it, `--patch-cs` is overwritten.

The rebuilt `help0.xhf`, its original template (`help0.xhf.ori` or the accepted fallback name `help.xhf.ori`), and `help_offsets.json` must remain together under `WorkSpace/ppXX/help0` when `repack_all` runs. The DAT receives the rebuilt `.xhf`; the managed DLL receives the matching hard-coded section offsets.

## UnityFS image-bundle tool

Entry point: [`unityfs_toolkit.py`](StreamingAssets/aa/StandaloneWindows64/unityfs_toolkit.py). Run it from `StreamingAssets/aa/StandaloneWindows64` or pass paths explicitly.

```powershell
Set-Location .\StreamingAssets\aa\StandaloneWindows64
python -X utf8 .\unityfs_toolkit.py extract .\title.bundle.dec .\title_work
# edit supported PNG files under title_work\CAB-...\
python -X utf8 .\unityfs_toolkit.py rebuild .\title.bundle.dec .\title_work .\title.bundle.new
```

Replace `title.bundle.dec` with an actual decompressed source bundle from your owned installation. `extract` defaults to `bundle_out` if no output directory is supplied. `rebuild` defaults to `<input>.new` if no output path is supplied. Explicit output paths are recommended because both commands overwrite files of the same name without prompting.

Extraction writes raw CAB/resS files, editable assets, sprite metadata, and a top-level `_meta.json`. Rebuild requires that `_meta.json` and the extracted directory layout remain intact.

### Supported automatic texture replacement

| Texture format | Automatic PNG import |
| --- | --- |
| `RGB24`, `RGBA32`, `ARGB32`, `BGRA32`, `Alpha8` | Yes, when stored in the streamed `.resS` data |
| DXT, ETC, PVRTC, crunched formats | No; reported and skipped |
| Inline texture data | No; reported and skipped |

The tool compares each PNG's MD5 against the extraction-time hash and patches only changed images. A changed image is resized to the original dimensions, converted to the original supported raw format, and written only if its byte count exactly matches the recorded stream size. CAB bytes remain untouched for this path. Missing extracted raw members fall back to original bundle bytes. The original trailing bytes are restored, while the rebuilt payload is emitted as 128 KiB uncompressed blocks; therefore a rebuilt bundle is not expected to be byte-identical or the same size as its source.

`Drag4ExtractBundle.bat` is a CMD drag-and-drop wrapper for extraction. It expects `unityfs_toolkit.py` beside it and Python on `PATH`; the direct commands above are easier to audit and reproduce.

## Inputs and outputs

| Tool | Required input | Editable material | Output | Source preservation |
| --- | --- | --- | --- | --- |
| `pp_tool… extract` | One `xenosagappN.dat` | None during extraction | One `ppNN` work tree | DAT is read-only; target work files may be overwritten |
| `pp_tool… extract_all` | `xenosagapp1.dat` … `xenosagapp6.dat` | None during extraction | `pp01` … `pp06` | Missing chapters skipped; target work files may be overwritten |
| `pp_tool… repack` | Baseline DAT + matching work tree | `script.json`, extracted GIF/PNG/raw members, help file | Chosen output DAT; optional `.dll.new` beside it | Baseline DAT retained; chosen outputs overwritten |
| `pp_tool… repack_all` | DAT folder + `WorkSpace` + optional managed DLL | Six work trees | Six `_new.dat` files + `Assembly-CSharp.dll.new` | Baselines retained when inputs and output are separate |
| VM parser core | Raw `block_0.bin` | None | JSON file or standard output | Input retained; chosen JSON output overwritten |
| Help `extract` | `.xhf` file + optional charmap | None | UTF-8 translator TXT | Input retained; chosen TXT output overwritten |
| Help `repack` | `.xhf` template + UTF-8 TXT + charmap | `help0.txt` | `help0.xhf`, optional offsets JSON | Template retained unless output path equals it |
| `unityfs_toolkit extract` | Decompressed UnityFS bundle | None during extraction | CAB/resS, PNG/TXT/JSON, `_meta.json` | Bundle read-only; extraction folder may be overwritten |
| `unityfs_toolkit rebuild` | Source bundle + extracted folder | Supported streamed PNGs or extracted raw members | Chosen bundle or `<input>.new` | Source retained unless output path equals source |

## Naming and placement rules

- Chapter inputs are exactly `xenosagapp1.dat` … `xenosagapp6.dat`; chapter work directories are `pp01` … `pp06`.
- `xenosagappN_new.dat` means “rebuilt member,” not a final loose installation filename.
- `Assembly-CSharp.dll.new` must become `Managed/Assembly-CSharp.dll` in a final package. Do not leave the `.new` suffix in the installed tree.
- `<bundle>.new` is a rebuilt bundle. Rename it to the exact original `.bundle` filename only when assembling the final replacement tree.
- `help0.xhf.ori` is the immutable help template; `help0.xhf` is the rebuilt member. Keep `help_offsets.json` synchronized with it.
- Preserve final relative paths exactly. Do not flatten `Managed` or `StreamingAssets/aa/StandaloneWindows64`.
- Do not run extraction into the tracked translated `WorkSpace`; use a separate audit directory.
- Do not treat reference sources, design files, `.dec` intermediates, or the repository's whole folder trees as installation payloads.

## Validation

Run from `StreamingAssets/aa/StandaloneWindows64/file`:

```powershell
# No-edit DAT round trips
1..6 | ForEach-Object {
  python -X utf8 .\pp_tool_xscript_vm_v5.py verify $_ ".\ppfiles\xenosagapp$_.dat"
}

# Help-text structural and encoding checks
1..6 | ForEach-Object {
  $Help = ".\WorkSpace\pp0$_\help0"
  python -X utf8 "$Help\xhf_text_tool_offsets_full.py" check `
    "$Help\help0.xhf.ori" "$Help\help0.txt" `
    --charmap "$Help\xenosaga_charmap.json"
}

# Python syntax checks for the core tracked tools
python -m py_compile `
  .\pp_tool_xscript_vm_v5.py `
  .\xscript_vm_parser_core_v5.py `
  ..\unityfs_toolkit.py `
  .\WorkSpace\pp01\help0\xhf_text_tool_offsets_full.py
```

There is no repository-wide automated gameplay or screenshot test suite. After rebuilding, test all six chapters, help navigation, title/guide images, menus, battle text, save/load screens, and any edited scene in the target runtime. A successful structural check cannot prove line wrapping, visual alignment, terminology, or pointer reachability for every runtime branch.

## Known limitations

- The tooling targets the specific archive, VM, help-file, bundle, and managed-code layouts represented by this repository. It does not probe arbitrary versions for compatibility.
- `verify` checks unchanged DAT round trips by inner CRC and uncompressed size; it does not compare a translated build against a golden release or launch the game.
- Unknown characters in `pp_tool_xscript_vm_v5.py` that are absent from the configured map and CP932 are currently skipped during encoding. Review the character map and in-game output when introducing new glyphs.
- Ordinary inline script fields are fixed-width and rebuilt text is padded or truncated to that field's byte size. Keep inline translations within the extracted allocation.
- VM text pointers are 16-bit. Appended pools exceeding `0xFFFF` are reported and their affected pointers are not updated.
- The help format limits individual encoded lines and section line counts to 255; managed section offsets must match the rebuilt file.
- Automatic bundle texture import supports only the uncompressed streamed formats listed above. It does not preserve palette or compressed-texture encoding because those formats are not rebuilt automatically.
- Bundle rebuilds use uncompressed 128 KiB blocks and can be larger than the original bundle.
- Batch wrappers assume Python is available on `PATH` and overwrite their named outputs without confirmation.
- The full final package build requires owned source data and the target runtime. This repository does not expose a single command that regenerates all 15 `PatchPack` files from an empty checkout.

## Repository map

```text
.
├─ README.md
├─ PatchPack/
│  └─ PatchedFiles/                 # completed 15-file replacement tree
├─ StreamingAssets/aa/
│  ├─ catalog.bin                   # catalog research/output copy
│  └─ StandaloneWindows64/
│     ├─ unityfs_toolkit.py         # image-bundle tool
│     ├─ achiveui-title/            # localized title image sources + metadata
│     ├─ achiveui-guide/            # localized guide image sources + metadata
│     ├─ font/ and archive-font/    # Korean font assets
│     ├─ data/                      # localization table material
│     └─ file/                      # chapter tools, sources, workspace, outputs
├─ Managed/
│  ├─ Assembly-CSharp.dll           # managed binary reference
│  └─ Assembly-CSharp/              # managed-code reference source
├─ 기타 자료/                         # image/design and supplementary records
└─ pied_piper_tree.txt              # installed-file layout reference
```

## Acknowledgements

Xenosaga Pied Piper and its original presentation, writing, art, music, and engineering belong to the work of their respective creators. This independent community localization exists because of that foundation. Thanks also go to the translators, testers, tool authors, font makers, and technical researchers whose work made the Korean release and its reproducible record possible.
