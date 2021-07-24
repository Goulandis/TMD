#pragma once
#include <string>
#include <vector>
#include "json/json.h"
#include <direct.h>
#include "Output.h"
#include <fstream>

using namespace std;
class Tool
{
private:
	static Tool* instance;
public:
	string ConfigJsonPath;
private:
	Tool();
public:
	static Tool* ToolInstance();
	//忽略大小写的字符串比较
	static bool Cmp(string str1, string str2);
	//指令拆分
	void Split(string cmd, vector<string>& vec);
	//读取配置文件
	bool ReaderConfig(string util,Json::Value& root);
	//写入配置文件
	bool WriterConfig(Json::Value& root);
	//判断文件或者路径是否存在
	bool FileOrDirExist(const string& path);
};
