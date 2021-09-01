@echo off
:start
cd > %USERPROFILE%\AppData\Local\Temp\direc
set /p direc= < direc
set /p currver= 0.5
del direc
cd %USERPROFILE%\AppData\Local\Temp\
echo Downloading dependencies...
set verlink=https://raw.githubusercontent.com/SteveYT77/winutil/main/newver.txt 
set verfile=newver.txt
echo.
echo %VERLINK%
echo.
echo %VERFILE%
certutil -urlcache -split -f %verlink% %verfile%
set /p latest= < newver.txt
if %CURRVER%==%LATEST% (goto ignore) else (goto needupdate)


:needupdate
echo Do you want to update your version of WinUtil? Current version is v0.5 but the latest version is %LATEST%. [Y/N]
set /p update=""
if /i %UPDATE%==y (goto update)
if /i %UPDATE%==n (goto ignore)
if /i %UPDATE%==d (goto debug) else (goto failsafe)

:debug
@echo on
goto start


:update
echo Downloading needed files... (Don't worry, this is NOT a virus!)
cd %DIREC%
set url=https://raw.githubusercontent.com/SteveYT77/winutil/main/winutil-en.txt
set file=winutil-en.bat
certutil -urlcache -split -f %url% %file%
rename winutil-en.txt winutil-en.bat
echo Done! Press any key to run.
pause >nul
call %USERPROFILE%\AppData\Local\Temp\winutil-en.bat
exit

:ignore
call %USERPROFILE%\AppData\Local\Temp\winutil-en.bat

:failsafe
echo Whoops. That's not a valid option. Press any key to try again.
pause >nul
goto start