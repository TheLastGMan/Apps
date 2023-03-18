#pragma once
#include "Exception.h"

namespace System
{
	class InvalidOperationException : public Exception
	{
	private:
		const string _InvalidOp = string("Invalid Operation");
	public:
		InvalidOperationException() : Exception(_InvalidOp) {};
		InvalidOperationException(string message) : Exception(message) {};
		InvalidOperationException(string message, Exception* innerException) : Exception(message, innerException) {};
	};
}