@echo off
title WinUtil
set startupwinutilversion=1.7.2
set prerelease=n
goto initial

:initial
if exist %USERPROFILE%\AppData\Local\WinUtil (goto initialfexist)

:initialfnotexist
mkdir %USERPROFILE%\AppData\Local\WinUtil
goto initial

:initialfexist
if exist %USERPROFILE%\AppData\Local\WinUtil\settings.txt (goto initialconvert)
if exist %USERPROFILE%\AppData\Local\WinUtil\settings.json (goto initialoexist) else (goto initialconvert)
pause

:initialconvert
(
echo 0
echo 0
echo 1
echo %STARTUPWINUTILVERSION%
echo .
echo .
echo .
echo .
echo .
echo 0
echo 7
)>%USERPROFILE%\AppData\Local\WinUtil\settings.json
del %USERPROFILE%\AppData\Local\WinUtil\settings.txt
cls
goto initial

:initialoexist
(
set /p needadmin=
set /p absolutelynothinguseful=
set /p firsttime=
set /p winutilversion=
set /p quickfolder1=
set /p quickfolder2=
set /p quickfolder3=
set /p quickfolder4=
set /p quickfolder5=
set /p backgroundcolor=
set /p textcolor=
)<%USERPROFILE%\AppData\Local\WinUtil\settings.json
set winutilversion=%STARTUPWINUTILVERSION%
(
echo %NEEDADMIN%
echo 0
echo %FIRSTTIME%
echo %WINUTILVERSION%
echo %QUICKFOLDER1%
echo %QUICKFOLDER2%
echo %QUICKFOLDER3%
echo %QUICKFOLDER4%
echo %QUICKFOLDER5%
echo %BACKGROUNDCOLOR%
echo %TEXTCOLOR%
)>%USERPROFILE%\AppData\Local\WinUtil\settings.json
if %FIRSTTIME%==1 (goto firsttime) else (goto initialadmincheck)

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
echo %NEEDADMIN%
echo 0
echo 0
echo %WINUTILVERSION%
echo %QUICKFOLDER1%
echo %QUICKFOLDER2%
echo %QUICKFOLDER3%
echo %QUICKFOLDER4%
echo %QUICKFOLDER5%
echo %BACKGROUNDCOLOR%
echo %TEXTCOLOR%
)>%USERPROFILE%\AppData\Local\WinUtil\settings.json
goto startprev

:initialadmincheck
if %NEEDADMIN%==1 (goto initialadmincheckagain) else (goto startprev)

:initialadmincheckagain
openfiles >nul
IF ERRORLEVEL 1 (goto initialadmin) else (goto startprev)

:initialadmin
powershell start -verb runas '%0' am_admin & exit /b

:startprev
if /i %PRERELEASE%==y (goto start) else (goto updatecheck)

:updatecheck
pushd %USERPROFILE%\AppData\Local\WinUtil
if exist curlVersion.txt (del curlVersion.txt)
curl https://raw.githubusercontent.com/SteveeWasTaken/winutil/main/curlVersion.txt --output curlVersion.txt
if %ERRORLEVEL%==6 (goto start)
(
set /p webversion=
)<%USERPROFILE%\AppData\Local\WinUtil\curlVersion.txt
popd
if /i %WEBVERSION% gtr %WINUTILVERSION% (goto needupdate) else (goto start)
goto start

:start
set util=.
set quick=.
set choice=.
set process=.
set pid=.
set usepid=.
set delete=.
set correct=.
set urlchoice=.
set setschoice=.
set delsetsask=.
set sspath=.
set ss=.
set reminders1=.
set reminders2=.
set reminders3=. 

:start2
if /i "%BACKGROUNDCOLOR%"=="ECHO is off." (goto colorfix)
color %BACKGROUNDCOLOR%%TEXTCOLOR%
cls
title WinUtil v%WINUTILVERSION%
echo  Windows MultiUtilities v%WINUTILVERSION%
echo  Tool made by SteveeWasTaken                 
echo.
echo [1] Restart File Explorer and Taskbar.
echo.
echo [2] Kill any app that might be causing you problems. [NEEDS ADMIN]
echo.
echo [3] Open the Task Manager. [NEEDS ADMIN]
echo.
echo [4] Delete a file/folder of your choice. [MAY NEED ADMIN]
echo.
echo [5] Quick Access Shortcuts.
echo.
echo [6] Log every existing file on a folder.                    
echo.
echo [7] Faster Downloader                                       
echo.
echo [8] Startup Reminders
echo.
echo [9] Super Shortcut Creator [NEEDS ADMIN]
echo.
echo [S] Settings
echo.
echo [A] About WinUtil                                           
echo.
echo  Press anything else to close WinUtil.            
echo.
set /p util=""
cls
if /i %UTIL%==x (goto bye)
if /i %UTIL%==s (goto winutilsettings)
if /i %UTIL%==a (goto aboutwinutil)
goto w%UTIL%

:winutilsettings
title Settings
cls
echo WinUtil Settings
echo.
echo [1] Start WinUtil as administrator?
echo.
echo [2] Color
echo.
echo [3] Change Quick Access Shortcuts
echo.
echo [S] Save settings.
echo.
echo [D] Delete settings.
echo.
echo [X] Go back to the main menu.
echo.
echo Press anything else to close WinUtil.
set /p setschoice=""
if /i %SETSCHOICE%==s (goto savesettings)
if /i %SETSCHOICE%==x (goto start)
if /i %SETSCHOICE%==d (goto deletesettings)
goto settings%SETSCHOICE%

:debugging
set debuggingchoice=.
cls
title Debug Mode
echo [I] Variable Editor
echo.
echo [L] Enable/Disable Logging
echo. 
echo [X] Go back to the main menu.
set /p debuggingchoice=""
if /i %DEBUGGINGCHOICE%==I (goto input)
if /i %DEBUGGINGCHOICE%==L (goto debug)
if /i %DEBUGGINGCHOICE%==X (goto winutilsettings) else (goto fail)	
cls

:settings1
set usettings_1=.
cls
echo.
echo Would you like to start WinUtil as
echo administrator? [Y/N]
set /p usettings_1=""
if /i %USETTINGS_1%==y (goto settings1yes)
if /i %USETTINGS_1%==n (goto settings1no) else (goto fail)

:settings1yes
set NEEDADMIN=1
goto winutilsettings

:settings1no
set NEEDADMIN=0
goto winutilsettings

:settings2
goto settings4

:settings3
cls
echo What is the path to your Quick Access Shortcuts?
set /p quickfolder1="Shortcut 1: "
set /p quickfolder2="Shortcut 2: "
set /p quickfolder3="Shortcut 3: "
set /p quickfolder4="Shortcut 4: "
set /p quickfolder5="Shortcut 5: "
goto winutilsettings

:settings4
@echo off
cls
echo What color would you like WinUtil to use for
echo the background? [The default is 0.]
echo.
echo 0 = Black       8 = Gray
echo 1 = Blue        9 = Light Blue
echo 2 = Green       A = Light Green
echo 3 = Aqua        B = Light Aqua
echo 4 = Red         C = Light Red
echo 5 = Purple      D = Light Purple
echo 6 = Yellow      E = Light Yellow
echo 7 = White       F = Bright White
set /p backgroundcolor=""
echo What color would you like WinUtil to use for
echo the text? (Use the same letters/numbers
echo from above.) [The default is 7.]
set /p textcolor=""
color %BACKGROUNDCOLOR%%TEXTCOLOR%
cls
echo This is how WinUtil looks now. Keep settings? [Y/N]
set /p usettings_4=""
if /i %USETTINGS_4%==y (goto winutilsettings)
goto settings4r

:settings4r
set BACKGROUNDCOLOR=.
set TEXTCOLOR=.
color 07
goto settings4

:savesettings
(
echo %NEEDADMIN%
echo 0
echo %FIRSTTIME%
echo %WINUTILVERSIONCUR%
echo %QUICKFOLDER1%
echo %QUICKFOLDER2%
echo %QUICKFOLDER3%
echo %QUICKFOLDER4%
echo %QUICKFOLDER5%
echo %BACKGROUNDCOLOR%
echo %TEXTCOLOR%
)>%USERPROFILE%\AppData\Local\WinUtil\settings.json
echo Settings saved.
echo Press anything to go back to the main menu.
pause >nul
goto start

:deletesettings
set delsetask=.
echo Are you sure you want to clear all of your
echo settings? (REQUIRES WINUTIL RESTART) [Y/N]
set /p delsetask=""
if /i %DELSETASK%==y (goto deletesettingsy)
if /i %DELSETASK%==n (goto winutilsettings) else (goto fail)

:deletesettingsy
del %USERPROFILE%\AppData\Local\WinUtil\settings.txt
echo Cleared your settings. Press anything to restart
echo WinUtil, and apply changes.
pause >nul
exit

:input
title Variable Editor
set vartoedit=.
set varsetas=.
echo Welcome to the secret variable menu.
echo What variable do you want to edit? (If you have
echo access to this section, you should know the 
echo variables you're editing.)
set /p vartoedit=""
echo What would you like to set the variable as?
set /p varsetas=""
echo Changing variables...
@echo on
set %VARTOEDIT%=%VARSETAS%
@echo off
echo Done.
echo Sending you back to the main menu... Press any
echo key to go back.
pause >nul
goto start2

:debug
echo Logging enabled.
@echo on
pause >nul
goto start

:debugoff
set isdebug=false
@echo off
echo Debug disabled. Logging disabled.
echo Press any key to go back to the main menu.
pause >nul
goto start

:debugon
set isdebug=true
@echo on
echo Debug enabled. Logging enabled.
echo Press any key to go back to the main menu.
pause >nul
goto start

:w1
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

:w2
title Program killer
echo Do you know the process name?
set /p choice="[Y/N] "
if /i %CHOICE%==Y (goto 2yes)
if /i %CHOICE%==N (goto 2no) else (goto fail)

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

:w3
title Task Manager
echo Opening the Task Manager...
start taskmgr.exe
echo Task manager has opened. Press anything
echo to go back to the main menu.
pause >nul
goto start

:w4
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

:w5
if %QUICKFOLDER1%==. (goto w5error) else (goto w5continue)

:w5error
title ...
echo You haven't set up your Shortcuts!
echo Press anything to go back to the main menu.
pause>nul
goto start

:w5continue
title Quick Folder Shortcut Menu
echo.
echo [1] %QUICKFOLDER1%
echo.
echo [2] %QUICKFOLDER2%
echo.
echo [3] %QUICKFOLDER3%
echo.
echo [4] %QUICKFOLDER4%
echo.
echo [5] %QUICKFOLDER5%
echo.
echo [X] Back to the WinUtil menu
set /p w5choice=""
cls
if /i %W5CHOICE%==x (goto start)
goto w5-%W5CHOICE%

:w5-1
start "" "%QUICKFOLDER1%"
goto w5

:w5-2
start "" "%QUICKFOLDER2%"
goto w5

:w5-3
start "" "%QUICKFOLDER3%"
goto w5

:w5-4
start "" "%QUICKFOLDER4%"
goto w5

:w5-5
start "" "%QUICKFOLDER5%"
goto w5

:w6
title Folder Logger
cls
set logfold=.
set logfoldsave=.
set logfoldtxt=.
echo Folder to log? (Insert full path.)
set /p logfold=""
echo Where to save logged text file? (Insert full path.)
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

:w7
title Fast Downloader
cls
set filechoice=.
echo Welcome to the Fast Downloader. Before
echo continuing, you're gonna need a direct
echo download link, if you don't use 
echo a direct one specifically, you will
echo have some problems.
echo.
echo Press [1] to continue with the process.
echo Press [2] to get a quick tutorial on how to get
echo a direct link.
set /p filechoice=""
if %FILECHOICE%==1 (goto 7cont)
if %FILECHOICE%==2 (goto 7tut) else (goto fail)

:7cont
set durl=.
set dfile=.
echo Direct link:
set /p durl=""
echo Save as (Include the full path including file extension):
set /p dfile=""
curl %DURL% --output %DFILE%
echo Your download should be finished. Else, check the
echo message(s) above to make sure there weren't any errors.
echo Press anything to go back to the main menu.
pause >nul
goto start

:7tut
title Fast Downloader Tutorial
cls
set tutorialchoice=.
echo Welcome to the tutorial for direct links. What browser do
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
goto w7

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
goto w7

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
goto w7

:w8
cls
set w8choice=.
title Startup Reminders
echo The Startup Reminders are messages that will
echo display when the computer starts up. You can
echo setup three of them.
echo.
echo Do you want to delete or change your reminders? [D/C]
set /p w8choice=""
if /i %W8CHOICE%==d (goto w8delete)
if /i %W8CHOICE%==c (goto w8change) else (goto fail)

:w8delete
del %APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup\reminders.bat
echo Deleted the reminders. You won't get any messages
echo when starting the PC anymore.
echo.
echo Press anything to go back to the main menu.
pause>nul
goto start

:w8change
title Startup Reminders
echo What will be the first reminder?
set /p reminders1=""
echo What will be the second reminder?
set /p reminders2=""
echo What will be the third reminder?
set /p reminders3=""
echo.
if %REMINDERS1%==. (goto w8error)
goto w8save

:w8error
echo You didn't set any reminders. Press anything
echo to go back to the main menu.

:w8save
pushd "%APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup\"
(
echo @echo off
echo set reminder1=%REMINDERS1%
echo set reminder2=%REMINDERS2%
echo set reminder3=%REMINDERS3%
echo title Startup Reminders
echo echo.
echo echo You have reminders set.
echo echo.
echo echo 1. %%REMINDER1%%
echo echo.
echo echo 2. %%REMINDER2%%
echo echo.
echo echo 3. %%REMINDER3%%
echo echo.
echo pause
)>reminders.txt
del reminders.bat
rename reminders.txt reminders.bat
popd
cls
echo Done! Keep in mind: You will keep getting
echo a message on startup, unless you go back and
echo delete the reminders, with WinUtil.
echo.
echo Press anything to go back to the main menu.
pause>nul
goto start

:w9
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
echo Created your Super Shortcut. Press anything to go
echo back to the main menu.
pause >nul
goto start

:bye
cls
exit

:aboutwinutil
cls
echo Hi. Thank you for using WinUtil. This program was
echo made by SteveeWasTaken. The idea was born since one
echo day, I was playing around with batch files. And
echo I saw how much code there was, and I thought that
echo there's people that don't know how to use this type of
echo code correctly. So I decided I could help them, by
echo making it easier for anyone to understand how it works,
echo and so, the project started. This, of course, hasn't been
echo easy, but it has been really fun to work on it. Again,
echo thank you for using WinUtil. Press anything to go
echo back to the main menu.
pause >nul
goto start

:fail
title  
echo That wasn't an option. Press anything to go back.
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

:needupdate
cls
title Your WinUtil is outdated!
echo You have an outdated version of WinUtil. Your version
echo is %WINUTILVERSION%, but the latest update is %WEBVERSION%.
echo Press anything to go to the GitHub page, and update from there.
pause >nul
start /max https://github.com/SteveYT77/winutil/releases
exit

:colorfix
(
echo %NEEDADMIN%
echo 0
echo %FIRSTTIME%
echo %WINUTILVERSION%
echo %QUICKFOLDER1%
echo %QUICKFOLDER2%
echo %QUICKFOLDER3%
echo %QUICKFOLDER4%
echo %QUICKFOLDER5%
echo 0
echo 7
)>%USERPROFILE%\AppData\Local\WinUtil\settings.json
goto initial