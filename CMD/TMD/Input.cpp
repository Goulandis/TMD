#include "Input.h"
#include "UE4.h"
#include "UtilFactory.h"

void Input::InputCmd(char** argv)
{
	while (TMD::cmd != TMD::exit)
	{
		Output::InputPrefix(TMD::tmd);
		cin >> TMD::cmd;
		AnalyzeUtilCmd(TMD::cmd);
	}
}

void Input::AnalyzeUtilCmd(string cmd)
{
	UtilFactory* factory = UtilFactory::UtilFactoryInstance();
	if (cmd == TMD::exit)
	{
		return;
	}
	else if (cmd == TMD::ue4)
	{
		UE4* ue4 = static_cast<UE4*>(factory->SpawnUtilInstance(cmd));
		
		while (cmd != TMD::exit)
		{
			ClearInput();	
			Output::InputPrefix(TMD::ue4);
			getline(cin, TMD::cmd);
			if (TMD::cmd.empty())
			{
				continue;
			}
			else if (TMD::cmd == TMD::exit)
			{
				return;
			}
			ue4->Analyze(TMD::cmd);
		}
	}
	else
	{
		Output::OutSyntaxError(cmd);
		Output::OutHelp(TMD::tmd);
	}
}

void Input::ClearInput()
{
	cin.ignore(numeric_limits<std::streamsize>::max(), '\n');	
}
