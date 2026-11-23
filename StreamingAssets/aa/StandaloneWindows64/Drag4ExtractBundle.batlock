@echo off
@chcp 65001
setlocal
pushd "%~dp0"

:: 1. 파이썬 설치 확인
python --version >nul 2>&1
if %errorlevel% neq 0 (
    echo [오류] 파이썬이 설치되어 있지 않거나 PATH에 등록되지 않았습니다.
    pause
    exit /b
)

:: 2. 인자 확인 (드래그 앤 드롭 여부)
if "%~1"=="" (
    echo [안내] 추출할 .bundle.dec 파일을 이 배치 파일 위로 드래그 앤 드롭하세요.
    pause
    exit /b
)

:: 3. 파일 경로 설정
set "INPUT_FILE=%~1"
set "OUT_DIR=%~dpn1_extracted"

echo [*] 입력 파일: %INPUT_FILE%
echo [*] 추출 폴더: %OUT_DIR%
echo [*] 추출 작업을 시작합니다...
echo.

:: 4. 파이썬 스크립트 실행 (기존 unityfs_toolkit.py 호출)
:: -- 주의: unityfs_toolkit.py 파일이 이 배치 파일과 같은 폴더에 있어야 합니다.
python unityfs_toolkit.py extract "%INPUT_FILE%" "%OUT_DIR%"

echo.
echo [*] 작업이 완료되었습니다.
pause
popd