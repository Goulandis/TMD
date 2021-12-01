rem time
set time=%date:~5,2%%date:~8,2%%time:~0,2%%time:~3,2%%time:~6,2%
rem outputdir
set outputdir=D:\PAK
rem UE4Editor
set UE4Editor-Cmd=C:\harix-ue4-engine\UnrealEngine-4.23.0-release\Engine\Binaries\Win64\UE4Editor-Cmd.exe
rem UnrealPak
set UnrealPak=C:\harix-ue4-engine\UnrealEngine-4.23.0-release\Engine\Binaries\Win64\UnrealPak.exe
rem uproject
set uproject=D:\Projects\UE4_MMO_server_develop_restruction\RobotEngine\RobotEngine.uproject
rem cooklogoutput
set cooklogoutput=D:\Logs
rem pakdir
set pakdir0=D:\Projects\UE4_MMO_server_develop_restruction\RobotEngine\Saved\Cooked\Android_ETC1\RobotEngine\Content\Comps\Acom_PatrolClient
set pakdir1=D:\Projects\UE4_MMO_server_develop_restruction\RobotEngine\Saved\Cooked\Android_ETC1\RobotEngine\Content\Maps\UMap_Patrol
set pakdir2=D:\Projects\UE4_MMO_server_develop_restruction\RobotEngine\Saved\Cooked\LinuxServer\RobotEngine\Content\Maps\UMap_Patrol
set pakdir3=D:\Projects\UE4_MMO_server_develop_restruction\RobotEngine\Saved\Cooked\LinuxServer\RobotEngine\Content\Comps\Acom_PatrolServer
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
set cook=%UE4Editor-Cmd% %uproject% -run=Cook -TargetPlatform=Android_ETC1 -fileopenlog -unversioned -abslog=%cooklogoutput%\Cook.log -stdout - CrashForUAT - unattended - NoLogTimes - UTF8Output
rem pakcmd
set pakcmd0=%UnrealPak% %outputdir%\Paks_%time%\Acom_PatrolClient_Android_ETC1_%time% -Create=%pakdir0% -compress
set pakcmd1=%UnrealPak% %outputdir%\Paks_%time%\UMap_Patrol_Android_ETC1_%time% -Create=%pakdir1% -compress
set pakcmd2=%UnrealPak% %outputdir%\Paks_%time%\UMap_Patrol_LinuxServer_%time% -Create=%pakdir2% -compress
set pakcmd3=%UnrealPak% %outputdir%\Paks_%time%\Acom_PatrolServer_LinuxServer_%time% -Create=%pakdir3% -compress
rem docook
%cook%
rem pakdirexsit
if not exist %pakdir0% (echo %pakdir0% done not exist; pause)
if not exist %pakdir1% (echo %pakdir1% done not exist; pause)
if not exist %pakdir2% (echo %pakdir2% done not exist; pause)
if not exist %pakdir3% (echo %pakdir3% done not exist; pause)
rem dopak
%pakcmd0%&&%pakcmd1%&&%pakcmd2%&&%pakcmd3%
start explorer "%outputdir%\Paks_%time%"
rem autocook&&pak.bat
rem Author:Goulandis
