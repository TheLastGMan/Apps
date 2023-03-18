#pragma once
#include <memory>
#include <string>
#include "Stream.h"

using namespace std;

namespace System
{
	namespace IO
	{
		class BinaryReader
		{
		private:
			static const int _BinaryBufferSize = 4;
			Stream* _BaseStream;
			byte _Buffer[_BinaryBufferSize] = {0};
			void FillBuffer(int size);
		public:
			//Constructor
			BinaryReader(Stream* input);
			~BinaryReader();

			//Method
			Stream* BaseStream() { return _BaseStream; };
			void Close();
			int Read(byte buffer[], int offset, int length);
			bool ReadBoolean();
			byte ReadByte();
			Int16 ReadInt16();
			Int32 ReadInt32();
			Int64 ReadInt64();
			string ReadString();
		};
	}
}