#pragma once
#include "Exception.h"

namespace System
{
	class ArgumentException : public Exception
	{
	private:
		string _ParamName;
	public:
		ArgumentException() : Exception("Argument Exception") {};
		ArgumentException(string message) : Exception(message) {};
		ArgumentException(string message, Exception* innerException) : Exception(message, innerException) {};
		ArgumentException(string message, string paramName, Exception* innerException) : Exception(message, innerException)
		{
			_ParamName = paramName;
		}
		ArgumentException(string message, string paramName) : Exception(message)
		{
			_ParamName = paramName;
		}

		virtual string Message()
		{
			if (!_ParamName.empty())
			{
				return Exception::Message() + "\r\nParameter Name: " + _ParamName;
			}
			return Exception::Message();
		}
	};
}