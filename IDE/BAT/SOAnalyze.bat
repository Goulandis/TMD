rem adbsoanalyzetool
set soanalyzetool=C:\NVPACK\android-ndk-r14b\toolchains\arm-linux-androideabi-4.9\prebuilt\windows-x86_64\bin\arm-linux-androideabi-addr2line.exe
rem sofile
set sofile=D:\Projects\UE4_MMO_server_develop_restruction\RobotEngine\Binaries\Android\RobotEngine_Symbols_v132\RobotEngine-armv7-es2\libUE4.so
rem stackcontent
set stackcontent=000174c8  06e60d20  06e5c594  06e5b324  06eed254  06e58cf8  066e4a9c  065fd504  069ab050  069a9f98  069a9560  066a7a48  0683e040  0329620c  0328cd84  0329cc54  032be46c  000470c3  00019e3d
rem fileexist
if not exist %soanalyzetool% ( echo %soanalyzetool% dones not exist; pause)
if not exist %sofile% ( echo %sofile% dones not exist; pause)
rem docmd
%soanalyzetool% -e %sofile% %stackcontent%
pause

rem auto so file analyze
rem Author:Goulandis
