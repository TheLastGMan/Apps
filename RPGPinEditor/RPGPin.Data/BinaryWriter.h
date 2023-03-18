#pragma once
#include "IDisposable.h"
#include "Stream.h"
#include <memory>
#include <string>

namespace System
{
	namespace IO
	{
		class BinaryWriter : public IDisposable
		{
		private:
			Stream* _OutStream;
			bool _LeaveOpen;
			byte _Buffer[4] = { 0 };
		public:
			BinaryWriter(Stream* output) : BinaryWriter(output, false) {}
			BinaryWriter(Stream* output, bool leaveOpen);
			~BinaryWriter() { Dispose(); }
			Stream* BaseStream() { return _OutStream; }

			void Close();
			void Flush();
			int Seek(int offset, SeekOrigin origin);
			void Write(bool value);
			void Write(sbyte value);
			void Write(byte value);
			void Write(byte buffer[], int length);
			void Write(char buffer[], int length);
			void Write(Int16 value);
			void Write(Int32 value);
			void Write(Int64 value);
			void Write(string value); //limited to 255 characters
			void Dispose();
		};
	}
}