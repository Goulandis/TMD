#pragma once
#include "UtilBase.h"
#include "Tool.h"

#define VNAME(value) #value

using namespace std;
class UE4 : public UtilBase
{
public: 
	UE4();
	//����ָ��
	void Analyze(string cmd);
	//��ȡUE4�������
	void ReaderConfig();
	//Cook����
	void Cook(vector<string>::iterator it,string& cmdexe,string cmd);
	//Pak����
	void Pak(vector<string>::iterator it, string& cmdexe, string cmd);
	//�鿴cook�ļ������ã�Ŀǰֻ֧��6������δʵ�ֶ�̬����
	void Look();
	//����UE4��ص�����
	void Config(vector<string>::iterator it, string cmd);
	//List����
	void List(vector<string>::iterator it, string& cmdexe, string cmd);
	void CookPak(vector<string>::iterator it, string& cmdexe, string cmd);
private:
	//�洢��ֵ�ָ��
	vector<string> cmdvec;
	//�洢����Ԥ��ָ�
	vector<string> cmdue;
	//�洢UE4������õ�Json����
	Json::Value root;
	Tool* tool;

	//UE4������ñ���
	string UE4Editor;
	string UProject;
	string CookLog;
	string UnrealPak;
	string OutputPak;
	string CookDir;
public:
	//UE4ָ����ر���
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

