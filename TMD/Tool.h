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
	//���Դ�Сд���ַ����Ƚ�
	static bool Cmp(string str1, string str2);
	//ָ����
	void Split(string cmd, vector<string>& vec);
	//��ȡ�����ļ�
	bool ReaderConfig(string util,Json::Value& root);
	//д�������ļ�
	bool WriterConfig(Json::Value& root);
	//�ж��ļ�����·���Ƿ����
	bool FileOrDirExist(const string& path);
};
