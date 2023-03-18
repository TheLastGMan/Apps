#include "BinaryWriter.h"
#include "ArgumentNullException.h"

namespace System
{
	namespace IO
	{
		BinaryWriter::BinaryWriter(Stream* output, bool leaveOpen)
		{
			//validate
			if (output == null)
				throw new ArgumentNullException("output");
			if (!output->CanWrite())
				throw new ArgumentException("Stream not writable");

			_OutStream = output;
			_LeaveOpen = leaveOpen;
		}

		void BinaryWriter::Close()
		{
			Dispose();
		}

		void BinaryWriter::Flush()
		{
			_OutStream->Flush();
		}

		int BinaryWriter::Seek(int offset, SeekOrigin origin)
		{
			return _OutStream->Seek(offset, origin);
		}

		void BinaryWriter::Write(bool value)
		{
			Write((byte)(value ? 1 : 0));
		}

		void BinaryWriter::Write(sbyte value)
		{
			Write((byte)value);
		}

		void BinaryWriter::Write(byte value)
		{
			_OutStream->WriteByte(value);
		}

		void BinaryWriter::Write(byte buffer[], int length)
		{
			//validate
			if (buffer == null)
				throw new ArgumentNullException("buffer");

			_OutStream->Write(buffer, 0, length);
		}

		void BinaryWriter::Write(char buffer[], int length)
		{
			//validate
			if (buffer == null)
				throw new ArgumentNullException("buffer");

			_OutStream->Write((byte*)buffer, 0, length);
		}

		void BinaryWriter::Write(Int16 value)
		{
			_Buffer[0] = (byte)value;
			_Buffer[1] = (byte)(value >> 8);
			_OutStream->Write(_Buffer, 0, 2);
		}

		void BinaryWriter::Write(Int32 value)
		{
			_Buffer[0] = (byte)value;
			_Buffer[1] = (byte)(value >> 8);
			_Buffer[2] = (byte)(value >> 16);
			_Buffer[3] = (byte)(value >> 24);
			_OutStream->Write(_Buffer, 0, 4);
		}

		void BinaryWriter::Write(Int64 value)
		{
			Write((Int32)(value & 0xFFFFFFFF));
			Write((Int32)(value >>= 32));
		}

		void BinaryWriter::Write(string value)
		{
			//limited to 255 characters
			Write((byte)value.length());
			_OutStream->Write((byte*)value.c_str(), 0, value.length());

			//clear buffer to write zeros as align int boundary
			_Buffer[0] = 0;
			_Buffer[1] = 0;
			_Buffer[2] = 0;
			_Buffer[3] = 0;
			_OutStream->Write(_Buffer, 0, value.length() % 4);
		}

		void BinaryWriter::Dispose()
		{
			if (_LeaveOpen)
				Flush();
			else
				_OutStream->Close();
		}
	}
}