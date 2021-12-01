rem adbsoanalyzetool
set soanalyzetool=C:\NVPACK\android-ndk-r14b\toolchains\arm-linux-androideabi-4.9\prebuilt\windows-x86_64\bin\arm-linux-androideabi-addr2line.exe
rem sofile
set sofile=D:\Projects\UE4_MMO_server_3.5.0_featrue\RobotEngine\Binaries\Android\RobotEngine_Symbols_v132\RobotEngine-armv7-es2\libUE4.so
rem stackcontent
set stackcontent=
rem fileexist
if not exist %soanalyzetool% ( echo %soanalyzetool% dones not exist; pause)
if not exist %sofile% ( echo %sofile% dones not exist; pause)
rem docmd
%soanalyzetool% -e %sofile% %stackcontent%
pause

rem auto so file analyze
rem Author:Goulandis