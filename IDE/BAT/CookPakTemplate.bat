rem time
set time=%date:~5,2%%date:~8,2%%time:~0,2%%time:~3,2%%time:~6,2%
rem outputdir
set outputdir=D:\PAK
rem UE4Editor
set UE4Editor-Cmd=C:\harix-ue4-engine\UnrealEngine-4.23.0-release\Engine\Binaries\Win64\UE4Editor-Cmd.exe
rem UnrealPak
set UnrealPak=C:\harix-ue4-engine\UnrealEngine-4.23.0-release\Engine\Binaries\Win64\UnrealPak.exe
rem uproject
set uproject=
rem cooklogoutput
set cooklogoutput=D:\Logs
rem pakdir
rem fileexsit
if not exist %UE4Editor-Cmd% (
echo %UE4Editor-Cmd% done not exist 
pause
)
if not exist %UnrealPak% (
echo %UnrealPak% done not exist
pause
)
if not exist %uproject% (
echo %uproject% done not exist
pause
)
rem cookcmd
set cook=%UE4Editor-Cmd% %uproject% -run=Cook  -TargetPlatform=LinuxServer+Android_ETC1 -fileopenlog -unversioned -abslog=%cooklogoutput%\Cook.log -stdout -CrashForUAT -unattended -NoLogTimes  -UTF8Output -iterate
rem pakcmd
rem docook
rem pakdirexsit
rem dopak

rem autocook&&pak.bat
rem Author:Goulandis