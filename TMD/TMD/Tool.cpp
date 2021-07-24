#include "Tool.h"
#include <io.h>
#include <algorithm>
#include <windows.h>
#include <stdlib.h>
#include <atlconv.h>

Tool* Tool::instance = nullptr;

Tool::Tool()
{
}

Tool* Tool::ToolInstance()
{
	if (instance == nullptr)
	{
		instance = new Tool();
	}
	return instance;
}

bool Tool::Cmp(string str1, string str2)
{
	transform(str1.begin(), str1.end(), str1.begin(), ::tolower);
	transform(str2.begin(), str2.end(), str2.begin(), ::tolower);
	return str1 == str2;
}

void Tool::Split(string cmd, vector<string>& vec)
{
	vec.clear();
	char* splitString = (char*)cmd.c_str();
	char* split = (char*)(" ");
	char* p = NULL;
	char* ret;
	ret = strtok_s(splitString, split, &p);
	while (ret)
	{
		vec.push_back(ret);
		ret = strtok_s(NULL, split, &p);
	}
}

bool Tool::ReaderConfig(string util, Json::Value& root)
{
	char szFilePath[MAX_PATH + 1] = { 0 };
	string path;
	//获取当前exe所在路径	
	GetModuleFileNameA(NULL, szFilePath, MAX_PATH);
	(strrchr(szFilePath, '\\'))[0] = 0;

//#ifdef _DEBUG
	//如果是Debug模式获取当前程序所在路径
	//_getcwd(szFilePath, MAX_PATH);	
//#endif

	path = szFilePath;
	string config = path;
	config += "\\Config.json";
	ifstream in(config);
	string json((istreambuf_iterator<char>(in)), istreambuf_iterator<char>());
	if (!in.is_open())
	{
		string error = "INTERNAL ERROR:\ncan't open file:" + config;
		Output::OutError(error);
		return false;
	}
	ToolInstance()->ConfigJsonPath = config;
	Json::CharReaderBuilder builder;
	Json::CharReader* reader(builder.newCharReader());
	Json::Value roottmp;
	JSONCPP_STRING errs;
	bool ok = reader->parse(json.data(), json.data() + json.length(), &roottmp, &errs);
	if (!ok)
	{
		Output::OutError(errs);
		in.close();
		return false;
	}
	else
	{
		if (util.empty())
		{
			root = roottmp;
		}
		else
		{
			root = roottmp[util];			
		}
		in.close();
		return true;
	}
}

bool Tool::WriterConfig(Json::Value& root)
{
	Json::StreamWriterBuilder writerBuilder;
	unique_ptr<Json::StreamWriter> writer(writerBuilder.newStreamWriter());	
	ofstream ofs;
	ostringstream os;
	if (!FileOrDirExist(ToolInstance()->ConfigJsonPath))
	{
		return false;
	}
	writer->write(root,&os);
	string strWriter = os.str();
	ofs.open(ToolInstance()->ConfigJsonPath);
	ofs << strWriter;
	ofs.close();
	return true;
}

bool Tool::FileOrDirExist(const string& path)
{
	if (_access(path.data(), 0) == -1)
	{
		if (path.empty())
		{
			Output::OutError("path does not exist ");
		}
		else
		{
			Output::OutError(path + " does not exist");
			return false;
		}		
	}
	else
	{
		return true;
	}
}
