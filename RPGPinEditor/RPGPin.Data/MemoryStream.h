#pragma once
#include <memory>
#include "Stream.h"

using namespace std;

namespace System
{
	namespace IO
	{
		class MemoryStream : public Stream
		{
		private:
			unique_ptr<byte[]> _Buffer; //stream
			bool _Expandable; //we created buffer
			bool _Writable; //can we write to stream
			bool _IsOpen; //is this open or closed
		public:
			//Constructors
			MemoryStream() {};
			MemoryStream(byte buffer[], int length);
			MemoryStream(byte buffer[], int length, bool writable);
			MemoryStream(int capacity);

			//Overrides
			void Dispose();
			bool CanRead() { return _IsOpen; };
			bool CanSeek() { return _IsOpen; };
			bool CanWrite() { return _Writable; };
			int Length() { return _Length; };
			void SetLength(int value) {};

			//methods
			int Position();
			void PositionSet(int value);
			byte* GetBuffer() { return _Buffer.get(); };
			int Read(byte buffer[], int offset, int count);
			byte ReadByte();
			int Seek(int offset, SeekOrigin origin);
			void Write(byte buffer[], int offset, int count);
			void WriteByte(byte value);
		};
	}
}