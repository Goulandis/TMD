# TMD

---

TMD---工具命令行

TMD工具命令行是一个集成个人学习工作中常使用的一些命令集和工具集的集成自动化调用的命令行工具集。

当前支持工具集：

UE4 Cook

UE4 Pak

----

## 初始开发版本 

[TMD 0.1.1.20210728 alpha](https://github.com/Goulandis/TMD/raw/main/Zip/TMD.zip)

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

---

## 下一版本的优化功能

1.cook文件槽设定为动态扩展，不再限定槽的数量；

2.cook文件槽支持别名，一边更容易记忆；

3.完善Help提示；

4.cookpak自动烘培打包和cook支持多平台配置。
