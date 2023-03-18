#pragma once
#include "ArgumentException.h"

namespace System
{
	class ArgumentOutOfRangeException : public ArgumentException
	{
	private:
		const string _OOR = string("Out Of Range");
		string _RangeMessage;
		string _ParamName;
	public:
		ArgumentOutOfRangeException() : ArgumentException(RangeMessage()) {};
		ArgumentOutOfRangeException(string paramName) : ArgumentException(RangeMessage(), paramName) {};
		ArgumentOutOfRangeException(string paramName, string message) : ArgumentException(message, paramName) {};
		ArgumentOutOfRangeException(string message, Exception* innerException) : ArgumentException(message, innerException) {};

		virtual string RangeMessage()
		{
			if (_RangeMessage.empty())
				return _OOR;
			return _RangeMessage;
		};
	};
}