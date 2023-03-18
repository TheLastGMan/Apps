#pragma once
#include <string>

using namespace std;

namespace System
{
	class ResourceString
	{
	private:
		ResourceString() {};
	public:
		const static string ArgumentOutOfRange_NeedPosNum;
		const static string ArgumentOutOfRange_NegativeCapacity;
		const static string ArgumentOutOfRange_StreamLength;
		const static string Argument_InvalidSeekOrigin;
		const static string ArgumentOutOfRange_NeedNonNegNum;
		const static string Argument_MinMaxValue;
		const static string ObjectDisposed_StreamClosed;
		const static string NotSupported_UnreadableStream;
		const static string NotSupported_UnwritableStream;
		const static string IO_SeekBeforeBegin;
		const static string IO_EOF_ReadBeyondEOF;
	};
}