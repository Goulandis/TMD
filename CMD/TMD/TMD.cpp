#include <iostream>
#include "TMD.h"
#include "UtilFactory.h"
#include "Input.h"

using namespace std;

int main(int argc, char** argv)
{
	Input::InputCmd(argv);
}

string TMD::exitCmd = "";
string TMD::cmd = "";

string TMD::tmd = "tmd";
string TMD::ue4 = "ue4";
string TMD::exit = "exit";
