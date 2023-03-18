#pragma once
#include "Exception.h"

using namespace System;

namespace Scripting
{
	class UnknownCommandException : public Exception
	{
	private:
		int _ScriptId;
		int _Position;
		int _Code;
	public:
		UnknownCommandException(int scriptId, int position, int code)
		{
			_ScriptId = scriptId;
			_Position = position;
			_Code = code;
		};

		string Message()
		{
			return "Unknown Command Code\r\nScript Id: " + to_string(_ScriptId)
				+ "\r\nPosition: " + to_string(_Position)
				+ "\r\nNext Line: " + to_string(_Position / 4)
				+ "\r\nCode: " + to_string(_Code);
		};
	};
}