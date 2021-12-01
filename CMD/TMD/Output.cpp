#include "Output.h"
#include "UE4.h"

void Output::InputPrefix(string TMDType)
{
	if (TMDType == TMD::tmd)
	{
		cout << "tmd>";
	}
	else if(TMDType == TMD::ue4)
	{
		cout << "tmd>ue4>";
	}
}

void Output::OutError(string msg)
{
	cout << "Error:"<< msg << endl;
}

void Output::OutSyntaxError(string cmd)
{
	string error = "SyntaxError:TMD hasn't " + cmd;
	cout << error << endl;
}

void Output::OutHelp(string type)
{
	cout << endl;
	if (type == UE4::cook)
	{
		cout << "--ue4>cook help:" << endl;
		cout << ">cook astc" << endl;
		cout << ">cook etc1" << endl;
		cout << ">cook win" << endl;
	}
	else if (type == TMD::tmd)
	{
		cout << "--tmd help:" << endl;
		cout << ">ue4" << endl;
	} 
	else if (type == UE4::config)
	{
		cout << "--ue4>config help:" << endl;
		cout << ">config outputpak <path>" << endl;
		cout << ">config cooklog <path>" << endl;
		cout << ">config ue4editor <path>" << endl;
		cout << ">config uproject <path>" << endl;
		cout << ">config unrealpak <path>" << endl;
		cout << ">config cookdir 1 <path>" << endl;
		cout << ">config cookdir 2 <path>" << endl;
		cout << ">config cookdir 3 <path>" << endl;
		cout << ">config cookdir 4 <path>" << endl;
		cout << ">config cookdir 5 <path>" << endl;
		cout << ">config cookdir 6 <path>" << endl;
	}
}

void Output::OutSuccess(string msg)
{
	cout << "Success:" << msg << endl;
}
