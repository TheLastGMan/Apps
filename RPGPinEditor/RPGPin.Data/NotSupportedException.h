#pragma once
#include "Exception.h"

namespace System
{
	class NotSupportedException : public Exception
	{
	private:
		const string _NotAllowed = string("Not Supported");
	public:
		NotSupportedException() : Exception(_NotAllowed) {};
		NotSupportedException(string message) : Exception(message) {};
		NotSupportedException(string message, Exception* innerException) : Exception(message, innerException) {};
	};
}