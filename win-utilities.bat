@echo on
set currver=0.8
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
if %CURRVER%==%LATEST% (goto noupdate) else (goto needupdate)

:noupdate
echo Up-to-date! Press anything to open WinUtil.
start winutil-en.bat

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

:failsafe
echo Whoops. That's not a valid option. Press any key to try again.
pause >nul
goto start
