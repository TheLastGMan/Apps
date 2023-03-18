#include "MemoryStream.h"
#include "ResourceStrings.h"
#include "ArgumentOutOfRangeException.h"
#include "ArgumentNullException.h"
#include "ObjectDisposedException.h"
#include "IOException.h"
#include "NotSupportedException.h"

namespace System
{
	namespace IO
	{
		MemoryStream::MemoryStream(byte buffer[], int length) : MemoryStream::MemoryStream(buffer, length, true)
		{
		}

		MemoryStream::MemoryStream(byte buffer[], int length, bool writable)
		{
			//validate
			if (buffer == null)
				throw new ArgumentNullException("buffer");
			if (length < 0)
				throw new ArgumentOutOfRangeException("length", ResourceString::ArgumentOutOfRange_NeedNonNegNum);

			_Buffer = unique_ptr<byte[]>(buffer);
			_Length = length;
			_Writable = writable;
			_IsOpen = true;
		}

		MemoryStream::MemoryStream(int capacity)
		{
			//validate
			if (capacity < 0)
				throw new ArgumentOutOfRangeException("capacity", ResourceString::ArgumentOutOfRange_NeedNonNegNum);

			_Buffer = unique_ptr<byte[]>(new byte[capacity]);
			_Length = capacity;
			_Expandable = true;
		}

		void MemoryStream::Dispose()
		{
			//update status
			_IsOpen = false;
			_Writable = false;
			_Expandable = false;
			Stream::Dispose();
		}

		int MemoryStream::Position()
		{
			if (!_IsOpen)
				throw new ObjectDisposedException(ResourceString::ObjectDisposed_StreamClosed);
			return _Position;
		}

		void MemoryStream::PositionSet(int value)
		{
			//validate
			if (!_IsOpen)
				throw new ObjectDisposedException(ResourceString::ObjectDisposed_StreamClosed);
			if (value < 0)
				throw new ArgumentOutOfRangeException("value", ResourceString::ArgumentOutOfRange_NeedNonNegNum);
			if (value > Length())
				throw new ArgumentOutOfRangeException("value", ResourceString::ArgumentOutOfRange_StreamLength);

			//set value
			_Position = value;
		}

		int MemoryStream::Seek(int offset, SeekOrigin origin)
		{
			//validate
			if (!_IsOpen)
				throw new ObjectDisposedException(ResourceString::ObjectDisposed_StreamClosed);
			if (offset > Length())
				throw new ArgumentOutOfRangeException("offset", ResourceString::ArgumentOutOfRange_StreamLength);

			int nextPosition = 0;
			switch (origin)
			{
			case SeekOrigin::Begin:
				nextPosition = offset;
				break;
			case SeekOrigin::Current:
				nextPosition = _Position + offset;
				break;
			case SeekOrigin::End:
				nextPosition = _Length + offset - 1;
				break;
			default:
				throw new ArgumentException(ResourceString::Argument_InvalidSeekOrigin);
			}

			//validate
			if (nextPosition < 0)
				throw new IOException(ResourceString::IO_SeekBeforeBegin);

			_Position = nextPosition;
			return _Position;
		}

		byte MemoryStream::ReadByte()
		{
			//validate
			if (!_IsOpen)
				throw new ObjectDisposedException(ResourceString::ObjectDisposed_StreamClosed);
			if (_Position >= _Length)
				throw new ArgumentOutOfRangeException(ResourceString::ArgumentOutOfRange_StreamLength);

			//give buffer
			return _Buffer.get()[_Position++];
		}

		int MemoryStream::Read(byte buffer[], int offset, int count)
		{
			//validate
			if (!_IsOpen)
				throw new ObjectDisposedException(ResourceString::ObjectDisposed_StreamClosed);
			if (buffer == null)
				throw new ArgumentNullException("buffer");
			if (offset < 0)
				throw new ArgumentOutOfRangeException("offset", ResourceString::ArgumentOutOfRange_NeedNonNegNum);
			if (count < 0)
				throw new ArgumentOutOfRangeException("count", ResourceString::ArgumentOutOfRange_NeedNonNegNum);

			//length validation
			int n = _Length - _Position;
			if (n > count)
				n = count;
			if (n <= 0)
				return 0;

			//copy bytes
			int byteCount = n;
			while (--byteCount >= 0)
				buffer[offset + byteCount] = _Buffer.get()[_Position + byteCount];

			//update position
			_Position += n;
			return n;
		}

		void MemoryStream::WriteByte(byte value)
		{
			//validate
			if (!_IsOpen)
				throw new ObjectDisposedException(ResourceString::ObjectDisposed_StreamClosed);
			if (!_Writable)
				throw new NotSupportedException(ResourceString::NotSupported_UnwritableStream);
			if (_Position >= _Length)
				throw new ArgumentOutOfRangeException(ResourceString::ArgumentOutOfRange_StreamLength);

			//write value
			_Buffer.get()[_Position++] = value;
		}

		void MemoryStream::Write(byte buffer[], int offset, int count)
		{
			//validate
			if (buffer == null)
				throw new ArgumentNullException("buffer");
			if (offset < 0)
				throw new ArgumentOutOfRangeException("offset", ResourceString::ArgumentOutOfRange_NeedNonNegNum);
			if (count < 0)
				throw new ArgumentOutOfRangeException("count", ResourceString::ArgumentOutOfRange_NeedNonNegNum);
			if (!_IsOpen)
				throw new ObjectDisposedException(ResourceString::ObjectDisposed_StreamClosed);
			if (!_Writable)
				throw new NotSupportedException(ResourceString::NotSupported_UnwritableStream);

			int i = _Position + count;
			if (i < 0 || i > _Length)
				throw new ArgumentOutOfRangeException(ResourceString::ArgumentOutOfRange_StreamLength);

			//write input to stream
			int byteCount = count;
			while (--byteCount >= 0)
				_Buffer.get()[_Position + byteCount] = buffer[offset + byteCount];

			//update position
			_Position = i;
		}
	}
}