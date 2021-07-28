# CMake generated Testfile for 
# Source directory: D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner
# Build directory: D:/Goulandis/TMD/jsoncpp-master/out/build/x64-Debug/src/jsontestrunner
# 
# This file includes the relevant testing commands required for 
# testing this directory and lists subdirectories to be tested as well.
add_test(jsoncpp_readerwriter "C:/Users/admin/AppData/Local/Programs/Python/Python39/python.exe" "-B" "D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/../../test/runjsontests.py" "D:/Goulandis/TMD/jsoncpp-master/out/build/x64-Debug/bin/jsontestrunner_exe.exe" "D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/../../test/data")
set_tests_properties(jsoncpp_readerwriter PROPERTIES  WORKING_DIRECTORY "D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/../../test/data" _BACKTRACE_TRIPLES "D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/CMakeLists.txt;43;add_test;D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/CMakeLists.txt;0;")
add_test(jsoncpp_readerwriter_json_checker "C:/Users/admin/AppData/Local/Programs/Python/Python39/python.exe" "-B" "D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/../../test/runjsontests.py" "--with-json-checker" "D:/Goulandis/TMD/jsoncpp-master/out/build/x64-Debug/bin/jsontestrunner_exe.exe" "D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/../../test/data")
set_tests_properties(jsoncpp_readerwriter_json_checker PROPERTIES  WORKING_DIRECTORY "D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/../../test/data" _BACKTRACE_TRIPLES "D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/CMakeLists.txt;47;add_test;D:/Goulandis/TMD/jsoncpp-master/src/jsontestrunner/CMakeLists.txt;0;")
