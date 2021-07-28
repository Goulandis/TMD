# Install script for directory: D:/Goulandis/TMD/jsoncpp-master/include

# Set the install prefix
if(NOT DEFINED CMAKE_INSTALL_PREFIX)
  set(CMAKE_INSTALL_PREFIX "D:/Goulandis/TMD/jsoncpp-master/out/install/x64-Debug")
endif()
string(REGEX REPLACE "/$" "" CMAKE_INSTALL_PREFIX "${CMAKE_INSTALL_PREFIX}")

# Set the install configuration name.
if(NOT DEFINED CMAKE_INSTALL_CONFIG_NAME)
  if(BUILD_TYPE)
    string(REGEX REPLACE "^[^A-Za-z0-9_]+" ""
           CMAKE_INSTALL_CONFIG_NAME "${BUILD_TYPE}")
  else()
    set(CMAKE_INSTALL_CONFIG_NAME "Debug")
  endif()
  message(STATUS "Install configuration: \"${CMAKE_INSTALL_CONFIG_NAME}\"")
endif()

# Set the component getting installed.
if(NOT CMAKE_INSTALL_COMPONENT)
  if(COMPONENT)
    message(STATUS "Install component: \"${COMPONENT}\"")
    set(CMAKE_INSTALL_COMPONENT "${COMPONENT}")
  else()
    set(CMAKE_INSTALL_COMPONENT)
  endif()
endif()

# Is this installation the result of a crosscompile?
if(NOT DEFINED CMAKE_CROSSCOMPILING)
  set(CMAKE_CROSSCOMPILING "FALSE")
endif()

if("x${CMAKE_INSTALL_COMPONENT}x" STREQUAL "xUnspecifiedx" OR NOT CMAKE_INSTALL_COMPONENT)
  file(INSTALL DESTINATION "${CMAKE_INSTALL_PREFIX}/include/json" TYPE FILE FILES
    "D:/Goulandis/TMD/jsoncpp-master/include/json/allocator.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/assertions.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/config.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/forwards.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/json.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/json_features.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/reader.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/value.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/version.h"
    "D:/Goulandis/TMD/jsoncpp-master/include/json/writer.h"
    )
endif()

