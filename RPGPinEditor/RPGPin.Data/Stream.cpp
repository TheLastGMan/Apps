#include "Stream.h"
#include "ArgumentOutOfRangeException.h"
#include "ObjectDisposedException.h"
#include "NotSupportedException.h"
#include "ResourceStrings.h"

namespace System
{
	namespace IO
	{
		void Stream::Dispose()
		{
			Close();
		}

		void Stream::CopyTo(Stream& destination)
		{
			CopyTo(destination, Length());
		}

		void Stream::CopyTo(Stream& destination, int bufferSize)
		{
			//validate
			if (bufferSize <= 0)
				throw new ArgumentOutOfRangeException("bufferSize", ResourceString::ArgumentOutOfRange_NeedPosNum);
			if (!CanRead() && !CanWrite())
				throw new ObjectDisposedException(ResourceString::ObjectDisposed_StreamClosed);
			if (!destination.CanRead() && !destination.CanWrite())
				throw new ObjectDisposedException("destination", ResourceString::ObjectDisposed_StreamClosed);
			if (!CanRead())
				throw new NotSupportedException(ResourceString::NotSupported_UnreadableStream);
			if (!destination.CanWrite())
				throw new NotSupportedException(ResourceString::NotSupported_UnwritableStream);

			//create buffer and read counter
			byte *buffer = new byte[_BlockSize];
			int read;

			//write while we read
			while ((read = Read(buffer, 0, _BlockSize)) != 0)
			{
				destination.Write(buffer, 0, read);
			}

			//delete buffer
			delete[] buffer;
		}

		byte Stream::ReadByte()
		{
			//create buffer
			byte *buffer = new byte[1];
			int r = Read(buffer, 0, 1);

			//store result of read
			byte result = -1;
			if (r > 0)
				result = buffer[0];

			//delete allocation and return result
			delete[] buffer;
			return result;
		}

		void Stream::WriteByte(byte value)
		{
			//create buffer with value
			byte *buffer = new byte[1];
			buffer[0] = value;

			//write buffer to stream
			Write(buffer, 0, 1);

			//delete allocation
			delete[] buffer;
		}
	}
}
