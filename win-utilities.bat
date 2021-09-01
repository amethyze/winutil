@echo off
set currver=1.0a
echo BEFORE CONTINUING!! THE PROGRAM MIGHT BE REPORTED AS A 
echo VIRUS. KEEP IN MIND THIS IS A FALSE POSITIVE!! PLEASE DISABLE YOUR
echo AV BEFORE CONTINUING!! IF YOU FEEL UNEASY ABOUT THIS FILE YOU
echo CAN EASILY CHECK THE CODE BY RIGHT CLICKING THEN PRESSING EDIT.
echo.
echo THIS PROGRAM WILL NOT DELETE ANY OF YOUR FILES NOR INSTALL
echo MALWARE OR DANGEROUS PROGRAMS. PRESS ANY KEY TO CONTINUE.
pause >nul
:start
cd > %USERPROFILE%\AppData\Local\Temp\direc
set /p direc= < %USERPROFILE%\AppData\Local\Temp\direc
del %USERPROFILE%\AppData\Local\Temp\direc
cd %USERPROFILE%\AppData\Local\Temp\
echo Downloading dependencies...
del newver.txt
set verlink=https://raw.githubusercontent.com/SteveYT77/winutil/main/newver.txt 
set verfile=newver.txt
certutil -urlcache -split -f %verlink% %verfile%
set /p latest= < newver.txt
if exist %USERPROFILE%\AppData\Local\Temp\winutil-en.bat (goto checkupdate) else (goto download)

:download
echo Downloading final depencies...
set dowlink=https://raw.githubusercontent.com/SteveYT77/winutil/main/winutil-en.txt
set dowfile=winutil-en.bat
certutil -urlcache -split -f %dowlink% %dowfile%
echo The program will close. Run it again. Press any key to exit.
pause >nul
exit

:checkupdate
if %CURRVER%==%LATEST% (goto noupdate) else (goto needupdate)

:noupdate
echo Up-to-date! Press anything to open WinUtil.
start winutil-en.bat
exit

:needupdate
echo Do you want to update your version of WinUtil? Current version is v%CURRVER% but the latest version is v%LATEST%. [Y/N]
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
set url=https://raw.githubusercontent.com/SteveYT77/winutil/main/win-utilities.bat
set file=win-utilities.txt
certutil -urlcache -split -f %url% %file%
set url=https://raw.githubusercontent.com/SteveYT77/winutil/main/winutil-en.txt
set file=winutil-en.txt
certutil -urlcache -split -f %url% %file%
del winutil-en.bat
rename winutil-en.txt winutil-en.bat
echo del %direc%\win-utilities.bat > %USERPROFILE%\AppData\Local\Temp\temp.bat
echo rename %direc%\win-utilities.txt win-utilities.bat > %USERPROFILE%\AppData\Local\Temp\temp2.bat
echo start %direc%\win-utilities.bat > %USERPROFILE%\AppData\Local\Temp\temp3.bat
echo exit > %USERPROFILE%\AppData\Local\Temp\temp4.bat
type %USERPROFILE%\AppData\Local\Temp\temp2.bat>>%USERPROFILE%\AppData\Local\Temp\temp.bat
type %USERPROFILE%\AppData\Local\Temp\temp3.bat>>%USERPROFILE%\AppData\Local\Temp\temp.bat
type %USERPROFILE%\AppData\Local\Temp\temp4.bat>>%USERPROFILE%\AppData\Local\Temp\temp.bat
rename %USERPROFILE%\AppData\Local\Temp\temp.bat temp.bat
echo Done! Press any key to run.
pause >nul
start %USERPROFILE%\AppData\Local\Temp\temp.bat
exit

:ignore
start winutil-en.bat
exit

:failsafe
echo Whoops. That's not a valid option. Press any key to try again.
pause >nul
goto start
