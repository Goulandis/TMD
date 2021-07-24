#pragma once
#include <iostream>
#include "TMD.h"

class Output
{
public:
	static void InputPrefix(string TMDType);
	static void OutError(string msg);
	static void OutSyntaxError(string cmd);
	static void OutHelp(string type);
	static void OutSuccess(string msg);
};

