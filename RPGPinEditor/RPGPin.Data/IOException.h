#pragma once
#include "Exception.h"

namespace System
{
	class IOException : public Exception
	{
	private:
		const string _IOEx = "IO Exception";
	public:
		IOException() : Exception(_IOEx) {};
		IOException(string message) : Exception(message) {};
		IOException(string message, Exception* innerException) : Exception(message, innerException) {};
	};
}