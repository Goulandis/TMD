# TMD

---

TMD---工具命令行

TMD工具命令行是一个集成个人学习工作中常使用的一些命令集和工具集的集成自动化调用的命令行工具集。
新增的IDE界面使用DevExpress.v20.2.3框架搭建，下载源码需要有框架支持。

当前支持工具集：

-----------2021.12.15

全局快捷键

快捷运行自定义脚本

移除DevExpress在软件启动时的弹窗

-----------2021.12.01

IDE界面

SO文件堆栈分析

一键软件库下载

-----------2021.07.28

UE4 Cook

UE4 Pak

----

## 最新版本

[TMD_1.2.4_20211222_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.2.4_20211222_release.zip)

## 历史版本

[TMD_1.2.4_20211222_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.2.4_20211222_release.zip)

[TMD_1.2.3_20211216_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.2.3_20211216_release.zip)

[TMD_1.2.1_20211215_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.2.1_20211201_release.zip)

[TMD_1.1.0_20211201_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.1.0._20211201_release.zip)

[TMD_0.1.1_20210728_alpha](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_0.1.1_20210728_alpha.zip)

## 使用说明

![](https://github.com/Goulandis/TMD/blob/main/Img/Snipaste_2021-12-23_15-04-35.png)

![](https://github.com/Goulandis/TMD/blob/main/Img/Snipaste_2021-12-23_15-06-45.png)

<font color=red>这里需要注意，不同版本的安卓NDK，ADB的SO解析工具名称和路径可能不一样。</font>

![](https://github.com/Goulandis/TMD/blob/main/Img/Snipaste_2021-12-23_15-08-35.png)

软件配置界面，做这个界面的起因是有一些个人常用的软件，在换新机时可能又需要手动下载，有时可能又一下子记不住有那些软件，所以就做了这么一个界面来一键下载，软件会调用电脑默认的浏览器来下载软件，并且保存在浏览器的默认存储路径中。

可以通过软件目录中的Config/SoftwareSetConfig.ini配置文件来配置自己的软件库，在`[SoftwareSetLinkStart]`和`[SoftwareSetLinkEnd]`中间按`软件名`+`空格`+`下载地址`的格式添加自定义软件库。

通过Cancel按钮可以使软件挂在后台，在Windows右下角菜单中可以找到软件图标，软甲支持全局快捷键，可以单击图标呼出快捷菜单，鼠标悬停可以查看快捷键。

![](https://github.com/Goulandis/TMD/blob/main/Img/Snipaste_2021-12-23_15-23-39.png)

AddNew按钮无快捷键，软件预留了4个按钮用于添加自定义快捷脚本。增加这个功能的原因是有时候开发中有一些繁琐而又重复的步骤，我们可以通过写一个.bat脚本来批量执行或者要运行某个exe来解算，但是这个.bat脚本可能又需要手动频繁的调用，当文件夹开的比较多的时候找起来很麻烦，而这些脚本又没办法使用快捷键快速启动，所就新增了一个接口，以便这些自定义脚本也能使用全局快捷键来快速启动。

新增的按钮会永久保存，不会在下次启动软件后消失，按钮的配置在软件目录/Config/Config.ini文件中的[HotKeyStart]项找到，P开头的为预定义配置，C开头的为自定义配置，预定义配置也可以在配置文件中修改快捷键。

## TMD_1.2.4_20211222_release

[TMD_1.2.4_20211222_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.2.4_20211222_release.zip)

- 修复AddNew新增自定义快捷按钮时文件可选类型为.pak的bug

## TMD_1.2.3_20211216_release

[TMD_1.2.3_20211216_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.2.3_20211216_release.zip)

- 优化了未选择Pak文件时直接Pak的提示信息。
- 删除了热键被占用时的提示信息。
- 修复生成脚本失败时未关闭脚本的bug。
- 删除上一版本Setting界面的debug遗留。

## TMD_1.2.1_20211215_release

[TMD_1.2.1_20211215_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.2.1_20211201_release.zip)

- 新增默认快捷键配置

  UECook，Pak，List等可以直接使用全局快捷键一键运行了，全局快捷键支持软件聚焦，失去焦点，最小化，隐藏等状态的快捷键识别。

- 预留了四个接口用于快捷运行自定义脚本

  在隐藏状态时的右键菜单中新增了AddNew按钮，用于打开配置系定义脚本运行的配置，可以配置新增按钮的名称，脚本路径和快捷键，配置会永久保存。

- 移除DevExpress在软件启动时的弹窗。

## TMD_1.1.0_20211201_release

[TMD_1.1.0_20211201_release](https://github.com/Goulandis/TMD/raw/main/Zip/TMD_1.1.0._20211201_release.zip)

- 新增IDE界面

  为UE4Cook和Pak增加IDE界面，UEEditor、UnrealPak、项目目录配置更加便捷。

- Cook和Pak和随意组合使用

  实现不依赖引擎版本，不依赖项目类型。

- 支持可选只渲染修改内容

- 新增Pak包内容查看功能

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

