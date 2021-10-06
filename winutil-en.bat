@echo off
:initial
if exist %USERPROFILE%\AppData\Local\WinUtil (goto initialfexist) else (goto initialfnotexist)

:initialfexist
if exist %USERPROFILE%\AppData\Local\WinUtil\settings.txt (goto initialoexist) else (goto initialonotexist)

:initialfnotexist
mkdir %USERPROFILE%\AppData\Local\WinUtil
goto initial

:initialonotexist
(
echo 0
echo .
echo 1
)>%USERPROFILE%\AppData\Local\WinUtil\settings.txt
goto initialoexist

REM variables in order: start as admin, quick folder path, is it first time or not

:initialoexist
setlocal enableDelayedExpansion & set i=0
@For /F "Tokens=1* Delims=] EOL=" %%A In ('Find /N /V ""^<"%USERPROFILE%\AppData\Local\WinUtil\settings.txt"') Do (
   set /a i=i+1
   set "settings_!i!=%%B"
)
if settings_3==1 (goto firsttime) else (goto initialadmincheck)

:firsttime
echo Welcome to WinUtil. It seems like it's your
echo first time running this program. In that case,
echo I hope you love WinUtil. If you find any bugs
echo or issues, please go to this program's GitHub
echo and tell us more about it in there.
echo.
echo https://github.com/SteveYT77/winutil
echo.
echo Press anything to continue.
pause >nul
(
echo %settings_1%
echo %SETTINGS_2%
echo 0
)>%USERPROFILE%\AppData\Local\WinUtil\settings.txt
goto startprev

:initialadmincheck
if %settings_1%==1 (goto initialadmin) else (goto startprev)

:initialadmin
if not "%1"=="am_admin" (powershell start -verb runas '%0' am_admin & exit /b)
goto startprev

:startprev
goto start

:start
set util=blank
set quick=blank
set choice=blank
set process=blank
set pid=blank
set usepid=blank
set delete=blank
set correct=blank
set urlchoice=blank
set setschoice=blank
set delsetsask=blank
set sspath=blank
set ss=blank
goto start2

:start2
title WinUtil v1.6
echo WinUtil - Windows MultiUtilities v1.6
echo Tool by Stevee
echo It's currently %time%.
echo Please type in your choice, then press enter.
echo.
echo [1] Restart File Explorer and Taskbar.
echo.
echo [2] Kill any app that might be causing you problems.
echo.
echo [3] Open the Task Manager.
echo.
echo [4] Delete a file/folder of your choice.
echo.
echo [5] Enter/Change/Create a quick access folder.
echo.
echo [6] Log every existing file on a folder.
echo.
echo [7] Quick File Downloader (Faster than normal downloads!).
echo.
echo [8] Bookmark Websites. [UNDER DEVELOPMENT]
echo.
echo [9] Super Shortcut Creator.
echo.
echo [S] Settings
echo.
echo [X] Close WinUtil.
echo Waiting for input...
set /p util=""
cls
if /i %UTIL%==i (goto input)
if /i %UTIL%==d (goto debug)
if /i %UTIL%==x (goto bye)
if /i %UTIL%==s (goto winutilsettings)
goto %UTIL%

:winutilsettings
title Settings
cls
echo WinUtil Settings
echo.
echo [1] Start WinUtil as administrator?
echo.
echo [2] Website Bookmarks.
echo.
echo [3] Quick Access Folder Path.
echo.
echo [s] Save settings.
echo.
echo [d] Delete settings.
echo.
echo [x] Go back to the main menu.
set /p setschoice=""
if /i %SETSCHOICE%==1 (goto settings1)
if /i %SETSCHOICE%==2 (goto settings2)
if /i %SETSCHOICE%==3 (goto settings3)
if /i %SETSCHOICE%==s (goto savesettings)
if /i %SETSCHOICE%==x (goto start)
if /i %SETSCHOICE%==d (goto deletesettings)

:settings1
echo.
echo Would you like to start WinUtil as
echo administrator?
set /p usettings_1=""
if /i %USETTINGS_1%==y (goto settings1yes)
if /i %USETTINGS_1%==n (goto settings1no) else (goto fail)

:settings1yes
set SETTINGS_1=1
pause
goto winutilsettings

:settings1no
set SETTINGS_1=0
pause
goto winutilsettings

:settings2
echo.
echo Hi! Sorry, this option is going under
echo development for now. Press anything to
echo go back to the settings menu.
pause >nul
goto winutilsettings

:settings3
echo.
if %SETTINGS_2%==. (goto settings3noexist) else (goto settings3exist)

:settings3noexist
echo What is the path to your Quick Access folder?
set /p SETTINGS_2=""
goto winutilsettings

:settings3exist
set DIR=%SETTINGS_2% 	
echo Current quick folder directory: %DIR%
echo Would you like to change it? [Y/N]
set /p settings3ch=""
if /i %SETTINGS3CH%==y (goto settings3yes)
if /i %SETTINGS3CH%==n (goto settings3no) else (goto fail)

:settings3yes
echo.
echo What will be the new Quick Access Folder path?
set /p settings_2=""
goto winutilsettings

:settings3no
goto winutilsettings

:savesettings
(
echo %SETTINGS_1%
echo %SETTINGS_2%
echo %SETTINGS_3%
)>%USERPROFILE%\AppData\Local\WinUtil\settings.txt
echo Saved!
echo Press anything to go back to the menu.
pause >nul
goto start

:deletesettings
echo Are you sure you want to clear all of your
echo settings? (REQUIRES WINUTIL RESTART) [Y/N]
set /p delsetask=""
if /i %DELSETASK%==y (goto deletesettingsy)
if /i %DELSETASK%==n (goto settings) else (goto fail)

:deletesettingsy
del %USERPROFILE%\AppData\Local\WinUtil\settings.txt
echo Cleared your settings. Press anything to go
echo back to the settings menu.
pause >nul
goto winutilsettings

:input
title Variable Editor
set vartoedit=blank
set varsetas=blank	
echo Welcome to the secret variable menu.
echo What variable do you want to edit? (If you have
echo access to this section, you should know the 
echo variables you're editing.)
set /p vartoedit=""
echo What would you like to set the variable as?
set /p varsetas=""
echo Changing variables...
set %VARTOEDIT%=%VARSETAS%
echo Done.
echo Sending you back to the main menu... Press any
echo key to go back.
pause >nul
goto start2

:debug
title Debug Mode
if %ISDEBUG%==true (goto debugoff)
if %ISDEBUG%==false (goto debugon) else (goto failsafe)

:debugoff
set isdebug=false
echo Debug disabled. Logging disabled.
@echo off
echo Press any key to go back to the main menu.
pause >nul
goto start

:debugon
set isdebug=true
echo Debug enabled. Logging enabled.
@echo on
echo Press any key to go back to the main menu.
pause >nul
goto start

:1
title Explorer reset
echo Closing explorer...
taskkill /f /im explorer.exe
echo Opening explorer again... (If this window
echo gets stuck, but you see your taskbar,
echo close this window.)
start explorer.exe
echo Explorer restarted. Press anything to
echo go back to the main menu.
pause >nul
goto start
set /p choice=""
if %CHOICE%==1 (goto start) else (goto bye)

:2
title Program killer
echo Do you know the process name?
set /p choice="[Y/N] "
if /i %CHOICE%==Y (goto 2yes) else (goto 2no)

:2no
tasklist
echo Find the process in the list above.
set /p process="Process name (include the .exe) "
taskkill /f /im %PROCESS%
echo The program should have closed. Else,
echo check the message(s) above to make
echo sure there weren't any errors. Press
echo anything to go back to the main menu.
pause >nul
goto start

:2yes
set /p usepid="Use PID or use process name? [Pi/Pr] "
if /i %USEPID%==pi (goto pid)
if /i %USEPID%==pr (goto process) else (goto fail)

:pid
set /p pid="PID: "
taskkill /f /pid %PID%
echo The program should have closed. Else,
echo check the message(s) above to make
echo sure there weren't any errors. Press
echo anything to go back to the main menu.
pause >nul
goto start

:process
set /p process="Process name (include the .exe) "
taskkill /f /im %PROCESS%
echo The program should have closed. Else,
echo check the message(s) above to make
echo sure there weren't any errors. Press
echo anything to go back to the main menu.
pause >nul
goto start

:3
title Task Manager
echo Opening the Task Manager...
start taskmgr.exe
echo Task manager has opened. Press anything
echo to go back to the main menu.
pause >nul
goto start

:4
title File Eraser
echo Directory/File to delete? (Include the
echo  full route, example: C:\Users\user\myfile.txt)
set /p delete=""
echo.
echo Are you sure the directory is correct?
echo Syntax: %DELETE% [Y/N]
set /p confirm=""
cls
if /i %DELETE%==Y (goto cont) else (goto no)

:no
cls
echo You canceled the deletion. Press anything
echo to go back to the main menu.
pause >nul
goto start

:cont
del %delete%
echo Deletion should be done. Else, check the
echo message(s) above to make sure there 
echo weren't any errors. Press anything to go
echo back to the main menu.
set /p choice=""
pause >nul
goto start

:5
if not %SETTINGS_2%==. (goto 5start) else (goto 5error)

:5error
echo There's no Quick Folder set. Please go to
echo settings to create one. Press anything to
echo go back to the main menu.
pause >nul
goto start

:5start
start "" "%SETTINGS_2%"
echo Quick Folder opened. Press anything to go back
echo to the main menu.
pause >nul
goto start

:6
title Folder Logger
cls
set logfold=blank
set logfoldsave=blank
set logfoldtxt=blank
echo Folder to log? (Insert full path!)
set /p logfold=""
echo Where to save logged text file? (Insert full path!)
set /p logfoldsave=""
echo Save as:
set /p logfoldtxt=""
FOR %%i IN (%LOGFOLD%\*.*) DO echo %%i >> %LOGFOLDSAVE%\%LOGFOLDTXT%.txt
echo The file should have been created. Else, check
echo the message(s) above to make sure there weren't
echo any errors.
echo Press anything to go back to the main menu.
pause >nul
goto start

:7
title File Downloader
cls
set filechoice=blank
echo Welcome to the Quick File Downloader. Before
echo continuing, make sure you have the following:
echo.
echo 1. A direct download URL. [MUST BE A DIRECT
echo LINK, ELSE PROBLEMS MAY OCCUR!]
echo 2. Save folder path.
echo Press [1] to continue with the process.
echo Press [2] to get a quick tutorial on how to get
echo a direct link.
set /p filechoice=""
if %FILECHOICE%==1 (goto 7cont)
if %FILECHOICE%==2 (goto 7tut) else (goto fail)

:7cont
echo Direct link:
set /p durl=""
echo Save as (Include the full path including file extension):
set /p dfile=""
powershell -Command "(New-Object Net.WebClient).DownloadFile('%DURL%', '%DFILE%')"
echo Your download should be finished. Else, check the
echo message(s) above to make sure there weren't any errors.
echo Press anything to go back to the main menu.
pause >nul
goto start

:7tut
title File Downloader Tutorial
cls
set tutorialchoice=blank
echo Welcome to the direct link tutorial. What browser do
echo you use? (The procedure is pretty similar for each one,
echo but if you don't know much about what you're doing,
echo it's recommended you follow the tutorial.)
echo.
echo [1] Mozilla Firefox
echo.
echo [2] Google Chrome / Brave Browser
echo.
echo [3] Opera / Opera GX
set /p tutorialchoice=""
if %TUTORIALCHOICE%==1 (goto 7firefox)
if %TUTORIALCHOICE%==2 (goto 7google)
if %TUTORIALCHOICE%==3 (goto 7opera)
if %TUTORIALCHOICE%==4 (goto 7brave) else (goto fail)

:7firefox
cls
echo 1. Open Firefox, then start a download via normal
echo means. (Just download it as you would usually do.)
echo 2. Right click on the file itself. A menu should 
echo appear. Click "Copy Download Link".
echo 2.5 Cancel the download as soon as you've got the
echo download link. This is done to prevent massive network
echo load.
echo 3. Paste the link as the direct link in this program.
echo.
echo Press any key to go back to the quick downloader menu.
pause >nul
goto 7

:7google
cls
echo Keep in mind that, while both Google Chrome and Brave
echo browser look differently, they work the same way.
echo 1. Open Google Chrome/Brave Browser, then start a
echo download via normal means. (Just download it as 
echo you would usually do.)
echo 2. Click "Show All".
echo 3. You should see a list of all of your downloads.
echo Under the name of the one we're searching for, you
echo should see a link. Right click it, and press "Copy
echo link address."
echo 3.5 Cancel the download as soon as you've got the
echo download link. This is done to prevent massive network
echo load.
echo 4. Paste the link as the direct link in this program.
echo.
echo Press any key to go back to the quick downloader menu.
pause >nul
goto 7

:7opera
cls
echo 1. Open Opera, then start a download via normal means.
echo (Just download it as you would usually do.)
echo 2. Click on the little download icon, then "Show More".
echo 3. You should see a list of all of your downloads. 
echo Under the name of the one we're searching for, you 
echo should see a link. Right click it, and press 
echo "Copy download address."
echo 3.5 Cancel the download as soon as you've got the 
echo download link. This is done to prevent massive network
echo load.
echo 4. Paste the link as the direct link in this program.
echo.
echo Press any key to go back to the quick downloader menu.
pause >nul
goto 7

:8
title [UNDER DEVELOPMENT]
echo Hi! Sorry, this option is going under development now.
echo Press anything to go back to the main menu.
pause >nul
goto start

:9
title Super Shortcut
echo Welcome to the Super Shortcut Creator menu.
echo This "Super" Shortcut is not a normal shortcut.
echo It's a new shortcut that does NOT use the usual
echo extension "lnk". In other words, this version of
echo shortcuts does NOT conflict with any program or
echo anything.
set /p ss="Super Shortcut target path (Where the folder you want to create a Super Shortcut for is located. Example: C:\Windows\System32): 
set /p sspath="Super Shortcut path (Where the new Super Shortcut will be, plus it's name. Example: C:\Users\user\Desktop\supershortcut): 
mklink /D %SSPATH% %SS%
echo Created your Super Shortcut! Press anything to go
echo back to the main menu.
pause >nul
goto start

:bye
cls
exit

:fail
title ??
echo That wasn't an option! Press any key to go back to the main menu.
pause >nul
goto start

:failsafe
title Oops...
cls
echo You find yourself in a strange situation... You have done something the program 
echo wasn't expecting, and somehow ended up in a secret room. Please report what you
echo did, to the developer, and he will do his best to fix it. Press any key to leave
echo the program, and open the GitHub page.
pause >nul
start /max https://github.com/SteveYT77/winutil
start /max https://raw.githubusercontent.com/SteveYT77/winutil/main/winutil-media/uhoh.txt
exit