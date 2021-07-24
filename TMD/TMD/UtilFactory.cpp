#include "UtilFactory.h"
#include "TMD.h"
#include "UE4.h"

UtilFactory* UtilFactory::instance = nullptr;

UtilFactory::UtilFactory()
{
}

UtilFactory* UtilFactory::UtilFactoryInstance()
{
	if (instance == nullptr)
	{
		instance = new UtilFactory();
	}
	return instance;
}

UtilBase* UtilFactory::SpawnUtilInstance(string& cmd)
{
	UtilBase* base = nullptr;
	if (cmd == TMD::ue4)
	{
		base = new UE4();
	}
	return base;
}
