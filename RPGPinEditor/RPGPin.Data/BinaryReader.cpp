#include "BinaryReader.h"
#include "ResourceStrings.h"
#include "ArgumentNullException.h"
#include "NotSupportedException.h"
#include "ArgumentOutOfRangeException.h"
#include "EndOfStreamException.h"

namespace System
{
	namespace IO
	{
		BinaryReader::BinaryReader(Stream* input)
		{
			if (input == null)
				throw new ArgumentNullException("input");
			if (!input->CanRead())
				throw new NotSupportedException(ResourceString::NotSupported_UnreadableStream);

			_BaseStream = input;
		}

		BinaryReader::~BinaryReader()
		{
			Close();
		}

		void BinaryReader::FillBuffer(int size)
		{
			//validate
			if (_Buffer != null && (size < 0 || size > _BinaryBufferSize))
				throw new ArgumentOutOfRangeException("size", "Must be between 0 and buffer size");

			int readIn = _BaseStream->Read(_Buffer, 0, size);
			if (readIn == 0)
				throw new EndOfStreamException(ResourceString::IO_EOF_ReadBeyondEOF);
		}

		//PUBLIC

		void BinaryReader::Close()
		{
			_BaseStream->Close();
		}

		int BinaryReader::Read(byte buffer[], int offset, int length)
		{
			if (buffer == null)
				throw new ArgumentNullException("buffer");
			if (offset < 0)
				throw new ArgumentOutOfRangeException("offset", ResourceString::ArgumentOutOfRange_NeedNonNegNum);
			if (length < 0)
				throw new ArgumentOutOfRangeException("length", ResourceString::ArgumentOutOfRange_NeedNonNegNum);
			return _BaseStream->Read(buffer, offset, length);
		}

		bool BinaryReader::ReadBoolean()
		{
			return ReadByte() != 0;
		}

		byte BinaryReader::ReadByte()
		{
			byte result = _BaseStream->ReadByte();
			if (result == 0)
				return -1;

			return result;
		}

		Int16 BinaryReader::ReadInt16()
		{
			FillBuffer(2);
			return (Int16)(_Buffer[0] | _Buffer[1] << 8);
		}

		Int32 BinaryReader::ReadInt32()
		{
			FillBuffer(4);
			return (Int32)(_Buffer[0] | _Buffer[1] << 8 | _Buffer[2] << 16 | _Buffer[3] << 24);
		}

		Int64 BinaryReader::ReadInt64()
		{
			Int32 lo = ReadInt32();
			Int64 hi = ReadInt32();
			return (hi <<= 32) | lo;
		}

		string BinaryReader::ReadString()
		{
			//format, first read is number of characters (limited to 255)
			byte size = ReadByte();

			//create string from stream
			unique_ptr<byte[]>str(new byte[size]);
			BaseStream()->Read(str.get(), 0, size);
			string result = string((char*)str.get(), size);

			//move stream position to integer boundary and give loaded string
			int seekIntBoundary = sizeof(int) - ((size + 1) % sizeof(int));
			BaseStream()->Seek(seekIntBoundary, SeekOrigin::Current);
			return result;
		}
	}
}
