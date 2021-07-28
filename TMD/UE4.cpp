#include "UE4.h"
#include "Output.h"
#include "json/json.h"
#include <io.h>


string UE4::cook = "cook";
string UE4::Andriod_ASTC = "astc";
string UE4::WindowsNoEditor = "win";
string UE4::Andriod_ETC1 = "etc1";

string UE4::pak = "pak";
string UE4::look = "look";
string UE4::list = "list";
string UE4::config = "config";
string UE4::cookpak = "cookpak";

UE4::UE4()
{
	ReaderConfig();
	Tool* tool = Tool::ToolInstance();
	cmdue.push_back(cook);
	cmdue.push_back(pak);
	cmdue.push_back(list);
}

void UE4::Analyze(string cmd)
{
	Tool::ToolInstance()->Split(cmd, cmdvec);
	if (cmdvec.size() <= 1)
	{
		Output::OutSyntaxError(cmd);
		Output::OutHelp(cook);
		return;
	}
	vector<string>::iterator it = cmdvec.begin();
	string cmdexe;
	if (*it == cook)
	{
		Cook(it, cmdexe, cmd);
	}
	else if (*it == pak)
	{
		Pak(it, cmdexe, cmd);
	}
	else if (*it == config)
	{
		Config(it, cmd);
	}
	else if (*it == list)
	{
		List(it, cmdexe, cmd);
	}
	else if (*it == cookpak)
	{
		CookPak(it, cmdexe, cmd);
	}
	else
	{
		Output::OutSyntaxError(cmd);
		Output::OutHelp(TMD::ue4);
		return;
	}
	if (cmdexe.empty())
	{
		return;
	}
	cout << cmdexe << endl;
	system(cmdexe.data());
}

void UE4::ReaderConfig()
{	
	Tool::ToolInstance()->ReaderConfig("UE4", root);	
	UE4Editor = root["UE4Editor"].asString();
	UProject = root["UProject"].asString();
	CookLog = root["CookLog"].asString();
	UnrealPak = root["UnrealPak"].asString();
	OutputPak = root["OutputPak"].asString();
	CookDir = root["CookDir1"].asString();
}

void UE4::Cook(vector<string>::iterator it, string& cmdexe, string cmd)
{
	/*if (cmdvec.size() > 2)
	{
		Output::OutSyntaxError(cmd);
		Output::OutHelp(cook);
		return;
	}*/
	
	if (!tool->FileOrDirExist(UE4Editor) || !tool->FileOrDirExist(UProject))
	{
		return;
	}
	if (CookLog.empty())
	{
		Output::OutError("CookLog is not configured");
		return;
	}
	++it;
	string cookstr = " -run=Cook -TargetPlatform=Android_ASTC -fileopenlog -unversioned -abslog=";
	if (*it == "s")
	{
		cookstr = " -run=Cook -TargetPlatform=Android_ASTC -fileopenlog -unversioned -iterate -abslog=";
		++it;
	}	
	if (*it == Andriod_ASTC)
	{
		cmdexe = UE4Editor + " " + UProject + cookstr + CookLog + " -stdout -CrashForUAT -unattended -NoLogTimes -UTF8Output";
	}
	else if (*it == WindowsNoEditor)
	{
		cmdexe = UE4Editor + " " + UProject + cookstr + CookLog + " -stdout -CrashForUAT -unattended -NoLogTimes -UTF8Output";
	}
	else if (*it == Andriod_ETC1)
	{
		cmdexe = UE4Editor + " " + UProject + cookstr + CookLog + " -stdout -CrashForUAT -unattended -NoLogTimes -UTF8Output";
	}
	else
	{
		Output::OutSyntaxError(cmd);
		Output::OutHelp(cook);
		return;
	}
}

void UE4::Pak(vector<string>::iterator it, string& cmdexe, string cmd)
{
	if (cmdvec.size() != 3)
	{
		Output::OutError(cmd);
		return;
	}
	++it;
	if (*it == "1")
	{
		CookDir = root["CookDir1"].asString();
	}
	else if (*it == "2")
	{
		CookDir = root["CookDir2"].asString();
	}
	else if (*it == "3")
	{
		CookDir = root["CookDir3"].asString();
	}
	else if (*it == "4")
	{
		CookDir = root["CookDir4"].asString();
	}
	else if (*it == "5")
	{
		CookDir = root["CookDir5"].asString();
	}
	else if (*it == "6")
	{
		CookDir = root["CookDir6"].asString();
	}
	else if (*it == look)
	{
		Look();
		return;
	}
	else
	{
		Output::OutError("The pak's output path is not configured");
		return;
	}
	if (!tool->FileOrDirExist(UnrealPak) || !tool->FileOrDirExist(CookDir))
	{
		return;
	}
	if (!tool->FileOrDirExist(OutputPak))
	{
		if (!_mkdir(OutputPak.data()))
		{
			Output::OutError("Failed to create file " + OutputPak);
			return;
		}
	}
	++it;
	string path = *it;
	string pak = OutputPak + "\\" + *it;
	cmdexe = UnrealPak + " " + pak + " " + " -Create=" + CookDir + " -compress";
}

void UE4::Look()
{
	cout << "CookDir1:" << root["CookDir1"].asString() << endl;
	cout << "CookDir2:" << root["CookDir2"].asString() << endl;
	cout << "CookDir3:" << root["CookDir3"].asString() << endl;
	cout << "CookDir4:" << root["CookDir4"].asString() << endl;
	cout << "CookDir5:" << root["CookDir5"].asString() << endl;
	cout << "CookDir6:" << root["CookDir6"].asString() << endl;
}

void UE4::Config(vector<string>::iterator it, string cmd)
{
	if (cmdvec.size() < 3 && cmdvec.size() > 4)
	{
		/*if (cmdvec.size() == 4 && (atoi(cmdvec[3].data()) < 1 || atoi(cmdvec[3].data())> 6))
		{
			Output::OutError("CookDir " + cmdvec[3] + " does not exist");
			Output::OutHelp(config);
			return;
		}*/
		Output::OutSyntaxError(cmd);
		Output::OutHelp(config);
		return;
	}

	string configUtil;
	string dirNum;
	string path;

	if (cmdvec.size() == 3)
	{
		configUtil = *(++it);
		path = *(++it);
	}
	if (cmdvec.size() == 4)
	{
		configUtil = *(++it);
		dirNum = *(++it);
		path = *(++it);
	}
	
	Json::Value roottmp;
	tool->ReaderConfig("", roottmp);
	if (tool->Cmp(configUtil, VNAME(UE4Editor)))
	{
		roottmp["UE4"]["UE4Editor"] = path;
	}
	else if (tool->Cmp(configUtil, VNAME(UProject)))
	{
		roottmp["UE4"]["UProject"] = path;
	}
	else if (tool->Cmp(configUtil, VNAME(CookLog)))
	{
		roottmp["UE4"]["CookLog"] = path;
		
	}
	else if (tool->Cmp(configUtil, VNAME(UnrealPak)))
	{
		roottmp["UE4"]["UnrealPak"] = path;
	}
	else if (tool->Cmp(configUtil, VNAME(OutputPak)))
	{
		roottmp["UE4"]["OutputPak"] = path;
	}
	else if (tool->Cmp(configUtil, VNAME(CookDir)))
	{
		switch (atoi(dirNum.data()))
		{
		case 1:
			roottmp["UE4"]["CookDir1"] = path;
			break;
		case 2:
			roottmp["UE4"]["CookDir2"] = path;
			break;
		case 3:
			roottmp["UE4"]["CookDir3"] = path;
			break;
		case 4:
			roottmp["UE4"]["CookDir4"] = path;
			break;
		case 5:
			roottmp["UE4"]["CookDir5"] = path;
			break;
		case 6:
			roottmp["UE4"]["CookDir6"] = path;
			break;
		default:
			Output::OutError("CookDir " + cmdvec[3] + " does not exist");
			Output::OutHelp(config);
			return;
		}
	}
	else
	{
		Output::OutSyntaxError(cmd);
		Output::OutHelp(config);
		return;
	}
	if (tool->WriterConfig(roottmp))
	{
		Output::OutSuccess("config and restart TMD to take effect");
	}
}

void UE4::List(vector<string>::iterator it, string& cmdexe, string cmd)
{
	if (cmdvec.size() != 2)
	{
		Output::OutError(cmd);
		Output::OutHelp(list);
	}
	string path = *(++it);
	if (!tool->FileOrDirExist(path))
	{
		return;
	}
	if (!tool->FileOrDirExist(UnrealPak))
	{
		Output::OutError("UnrealPak is not configured");
		Output::OutHelp(config);
	}
	cmdexe = UnrealPak + " \"" + path + "\" -list";
}

void UE4::CookPak(vector<string>::iterator it, string& cmdexe, string cmd)
{
	vector<string>::iterator p = it;
	++p;
	if (atoi((*p).data()) < 1 || atoi((*p).data()) > 6)
	{
		Output::OutError(cmd);
		// Output::OutHelp(list);
		return;
	}
	string cook = UE4Editor + " " + UProject + " -run=Cook -TargetPlatform=Android_ASTC -fileopenlog -unversioned -iterate -abslog=" + CookLog + " -stdout -CrashForUAT -unattended -NoLogTimes -UTF8Output";
	string pak = "";
	Pak(it, pak, cmd);
	system(cook.data());
	system(pak.data());
}

/*
"UE4": {
	"CookLog": "",
		"OutputPak" : "",
		"UE4Editor" : "",
		"UProject" : "",
		"UnrealPak" : "",
		"CookDir1" : "",
		"CookDir2" : "",
		"CookDir3" : "",
		"CookDir4" : "",
		"CookDir5" : "",
		"CookDir6" : ""
}
*/

