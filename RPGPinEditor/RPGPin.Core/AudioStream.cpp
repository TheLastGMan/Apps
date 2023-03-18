#include "AudioStream.h"

namespace Audio
{
	int AudioStream::Id()
	{
		return _Id;
	}

	int AudioStream::Volume()
	{
		return _Volume;
	}

	void AudioStream::SetVolume(int value)
	{
		//validate range
		if (value < 0)
			value = 0;
		if (value > 100)
			value = 100;

		_Volume = value;
	}
}