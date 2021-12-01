#pragma once
#include "UtilBase.h"
#include "Tool.h"

#define VNAME(value) #value

using namespace std;
class UE4 : public UtilBase
{
public: 
	UE4();
	//解析指令
	void Analyze(string cmd);
	//读取UE4相关配置
	void ReaderConfig();
	//Cook命令
	void Cook(vector<string>::iterator it,string& cmdexe,string cmd);
	//Pak命令
	void Pak(vector<string>::iterator it, string& cmdexe, string cmd);
	//查看cook文件夹配置，目前只支持6个，还未实现动态配置
	void Look();
	//配置UE4相关的配置
	void Config(vector<string>::iterator it, string cmd);
	//List命令
	void List(vector<string>::iterator it, string& cmdexe, string cmd);
	void CookPak(vector<string>::iterator it, string& cmdexe, string cmd);
private:
	//存储拆分的指令
	vector<string> cmdvec;
	//存储所有预设指令集
	vector<string> cmdue;
	//存储UE4相关配置的Json对象
	Json::Value root;
	Tool* tool;

	//UE4相关配置变量
	string UE4Editor;
	string UProject;
	string CookLog;
	string UnrealPak;
	string OutputPak;
	string CookDir;
public:
	//UE4指令相关变量
	static string cook;
	static string Andriod_ASTC;
	static string WindowsNoEditor;
	static string Andriod_ETC1;

	static string pak;

	static string look;
	static string list;
	static string config;
	static string cookpak;
};

