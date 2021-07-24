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
	//生产各个模块的实例
	UtilBase* SpawnUtilInstance(string& cmd);
};

