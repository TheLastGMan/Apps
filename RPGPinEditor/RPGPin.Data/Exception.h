#pragma once
#include <string>

using namespace std;

namespace System
{
	class Exception
	{
	private:
		string _Message;
		Exception* _InnerException;
	public:
		~Exception() { delete _InnerException; }
		Exception() {}
		Exception(string message) { _Message = string(message); }
		Exception(string message, Exception* innerException) : Exception(message) { _InnerException = innerException; }
		Exception* InnerException() { return _InnerException; }
		virtual string Message() { return _Message; }
	};
}
