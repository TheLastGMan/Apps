#pragma once
#include "Types.h"
#include "SeekOrigin.h"
#include "IDisposable.h"

namespace System
{
	namespace IO
	{
		class Stream : public IDisposable
		{
		private:
			const int _BlockSize = 512; //512B buffer
		protected:
			Stream() {};
			~Stream() { Dispose(); };
			int _ReadTimeout = 0;
			int _WriteTimeout = 0;
			int _Length = 0;
			int _Position = 0;
		public:
			//Properties
			virtual bool CanRead() { return false; };
			virtual bool CanSeek() { return false; };
			virtual bool CanTimeout() { return false; };
			virtual bool CanWrite() { return false; };
			virtual int Length() { return _Length; };
			virtual int Position() { return _Position; };
			virtual void PositionSet(int value) { _Position = value; };
			virtual int ReadTimeout() { return _ReadTimeout; };
			virtual void ReadTimeOutSet(int value) { _ReadTimeout = value; };
			virtual int WriteTimeout() { return _WriteTimeout; };
			virtual void WriteTimeoutSet(int value) { _WriteTimeout = value; };

			//Methods
			virtual void Dispose();
			virtual void Close() { };
			void CopyTo(Stream& destination);
			void CopyTo(Stream& destination, int bufferSize);
			virtual void Flush() {};
			virtual int Seek(int offset, SeekOrigin origin) { return 0; };
			virtual int Read(byte buffer[], int offset, int bufferSize) { return 0; };
			virtual byte ReadByte();
			virtual void SetLength(int value) { _Length = value; };
			virtual void Write(byte buffer[], int offset, int bufferSize) {};
			virtual void WriteByte(byte value);
		};
	}
}