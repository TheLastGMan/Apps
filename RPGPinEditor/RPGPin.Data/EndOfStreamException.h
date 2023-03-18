#pragma once
#include "IOException.h"

namespace System
{
	class EndOfStreamException : public IOException
	{
	private:
		const string _EOSEx = "End Of Stream";
	public:
		EndOfStreamException() : IOException(_EOSEx) {};
		EndOfStreamException(string message) : IOException(message) {};
		EndOfStreamException(string message, Exception* innerException) : IOException(message, innerException) {};
	};
}