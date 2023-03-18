#pragma once
#include "ArgumentException.h"

namespace System
{
	class ArgumentNullException : public ArgumentException
	{
	private:
		const string _ArgumentNull = string("Argument Null");
	public:
		ArgumentNullException() : ArgumentException(_ArgumentNull) {};
		ArgumentNullException(string paramName) : ArgumentException(_ArgumentNull + ": " + paramName) {};
		ArgumentNullException(string message, Exception* innerException) : ArgumentException(message, innerException) {};
		ArgumentNullException(string paramName, string message) : ArgumentException(message, paramName) {};
	};
}