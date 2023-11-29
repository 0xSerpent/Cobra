@echo off
echo.
echo  ██████ ▓█████  ██▀███   ██▓███  ▓█████  ███▄    █ ▄▄▄█████▓
echo ▒██    ▒ ▓█   ▀ ▓██ ▒ ██▒▓██░  ██▒▓█   ▀  ██ ▀█   █ ▓  ██▒ ▓▒
echo ░ ▓██▄   ▒███   ▓██ ░▄█ ▒▓██░ ██▓▒▒███   ▓██  ▀█ ██▒▒ ▓██░ ▒░
echo   ▒   ██▒▒▓█  ▄ ▒██▀▀█▄  ▒██▄█▓▒ ▒▒▓█  ▄ ▓██▒  ▐▌██▒░ ▓██▓ ░ 
echo ▒██████▒▒░▒████▒░██▓ ▒██▒▒██▒ ░  ░░▒████▒▒██░   ▓██░  ▒██▒ ░ 
echo ▒ ▒▓▒ ▒ ░░░ ▒░ ░░ ▒▓ ░▒▓░▒▓▒░ ░  ░░░ ▒░ ░░ ▒░   ▒ ▒   ▒ ░░   
echo ░ ░▒  ░ ░ ░ ░  ░  ░▒ ░ ▒░░▒ ░      ░ ░  ░░ ░░   ░ ▒░    ░    
echo ░  ░  ░     ░     ░░   ░ ░░          ░      ░   ░ ░   ░      
echo       ░     ░  ░   ░                 ░  ░         ░          
echo.
color 0A

if exist token.txt (
    echo token.txt already exists. Skipping token input.
) else (
    set /p token=Enter Discord Bot Token: 
    echo %token% > token.txt
)

echo.
echo What would you like to do?
echo 1. Compile to a single executable
echo 2. Compile normally
set /p action=Enter your choice: 

if "%action%"=="1" (
    dotnet publish -r win10-x64 -c Release /p:PublishSingleFile=true /p:PublishTrimmed=true
) else if "%action%"=="2" (
    dotnet build
) else (
    echo Invalid choice. Exiting...
    exit /b 1
)
