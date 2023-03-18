#pragma once

#include "BinaryReader.h"

using namespace System::IO;

namespace Audio
{
	class AudioStream : public BinaryReader
	{
	private:
		int _Id;
		int _Volume;
	public:
		AudioStream(int id, int volume, Stream* stream) : BinaryReader(stream)
		{
			_Id = id;
			SetVolume(volume);
		};

		int Id();
		int Volume();
		void SetVolume(int value);

		bool operator==(AudioStream other) { return _Id == other.Id(); };
	};
}