#pragma once
#include <string>
#include "UtilBase.h"

using namespace std;

class UtilFactory
{
private:
	static UtilFactory* instance;
private:
	UtilFactory();
public:
	static UtilFactory* UtilFactoryInstance();
	//��������ģ���ʵ��
	UtilBase* SpawnUtilInstance(string& cmd);
};

