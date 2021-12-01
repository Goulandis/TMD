# TMD

---

TMD---工具命令行

TMD工具命令行是一个集成个人学习工作中常使用的一些命令集和工具集的集成自动化调用的命令行工具集。
新增的IDE界面使用DevExpress.v20.2.3框架搭建，下载源码需要有框架支持。

当前支持工具集：

-----------2021.07.28

IDE界面

SO文件堆栈分析

一键软件库下载

-----------2021.07.28

UE4 Cook

UE4 Pak

----

## 最新版本

[TMD_1.0.0_20211201_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.0.0_20211201_release.zip)

##历史版本

[TMD_0.1.1_20210728_alpha](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_0.1.1_20210728_alpha.zip)

## TMD_1.0.0_20211201_release

- 新增IDE界面

  为UE4Cook和Pak增加IDE界面，UEEditor、UnrealPak、项目目录配置更加便捷。

- Cook和Pak和随意组合使用

  实现不依赖引擎版本，不依赖项目类型。

- 支持可选只渲染修改内容

- 新增SO文件堆栈分析功能

  什么是SO文件？

  SO文件是unix系统的动态连接库文件，是一个二进制文件，在UE打包安卓apk时，会在项目目录\Binaries\Android\项目名称_Symbols_vxx文件夹下，对应的apk崩溃时会在adb的日志中打印出堆栈信息，通过这些堆栈信息可以，通过安卓的堆栈分析工具可以追踪到崩溃代码。

- 新增软件集下载

  这个功能是自己在用新电脑时产生的问题，即每个人有自己习惯使用的一套软件库，使用新电脑时需要一个个去下载，有时有些小众软件可能还不记得下载地址了，所以就写了这么一个功能已记录自己的软件库，达到一键下载自选软件库的目的。

  如何使用？

  在软件根目录/Config/SoftwareSetConfig.ini中的[SoftwareSetLinkStart]字段下按照软件名+空格+下载地址的格式添加自己的软件库即可。
  
  注意：默认软件库中部分软件使用了官网下载链接，可能会出现链接失效的情况。

  TMD如何下载软件？

  TMD是直接调用的Windos系统用户默认浏览器来下载的。

## TMD_0.1.1_20210728_alpha

[TMD_0.1.1_20210728_alpha](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_0.1.1_20210728_alpha.zip)

支持功能：

- UE4 工具集配置指令

  说明：

  目前只支持UnrealPak.exe工具、UE4Editor-Cmd.exe工具，以及这两个工具在使用中涉及到的UPoject文件，Cook文件夹，输出Pak包，Log日志等路径的配置，配置存储在Config.json中。

  指令详情：

  | Instruction                 | Directions                                                   |
  | --------------------------- | ------------------------------------------------------------ |
  | config ue4editor (path)     | 配置UE4Editor-Cmd.exe工具的路径                              |
  | config uproject (path)      | 配置工程uproject文件路径                                     |
  | config cooklog (path)       | 配置cook时存储log的路径                                      |
  | config unrealpak (path)     | 配置UnrealPak.exe工具的路径                                  |
  | config outputpak (path)     | 配置pak时pak文件的存储路径                                   |
  | config cookdir (num) (path) | 配置pak时指定pak的cook文件夹，num为文件槽，可支持文件夹最大数量，目前最大支持6个 |

- UE4 Cook指令

  说明：

  启动UE4的UE4Editor-Cmd.exe工具进行内容烘培，可以指定烘培平台，烘培方式等，烘培日志存储在cooklog配置的文件夹下。

  指令详情：

  | Instruction         | Directions                                                   |
  | ------------------- | ------------------------------------------------------------ |
  | cook (s) (platform) | 烘培指定平台的内容格式，s为可选项，加s表示只烘培有修改的内容，不加表示清除原来的烘培内容重新烘培所有内容，此版本支持常用的3个平台，并以指定缩写形式表示，astc-Andriod_ASTC，etc1-Andriod_ETC1，win-WindowsNoEditor |

- UE4 Pak指令

  说明：

  启用UE4的UnrealPak.exe工具进行内容打包，打出的Pak包存储在outputpak配置的文件夹下。

  指令详情：

  | Instruction             | Directions                                                   |
  | ----------------------- | ------------------------------------------------------------ |
  | pak (num) (pakfilename) | pak文件打包，num为cookdir对应的cook文件槽，pakfilename为打包出来的pak文件的名称 |
  | pak look                | 查看当前所有的cookdir的配置详情                              |

- UE4 List指令

  说明：

  启用UE4的UnrealPak.exe工具查看pak里的内容。

  指令详情：

  | Instruction | Directions                             |
  | ----------- | -------------------------------------- |
  | list (path) | 接pak文件路径即可查看指定pak文件的内容 |

- UE4 Cook烘培Pak打包一键自动化操作

  说明：

  自动化UE4的UE4Editor-Cmd.exe工具和UnrealPak.exe工具，自动化烘培和打包。

  指令说明：

  | Instruction                 | Directions                                                   |
  | --------------------------- | ------------------------------------------------------------ |
  | cookpak (num) (pakfilename) | num为cookdir对应的cook文件槽，pakfilename为打包出来的pak文件的名称 |

