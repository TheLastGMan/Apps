#pragma once
#include "AudioStream.h"

namespace Audio
{
	class IAudioChannel
	{
	private:
		AudioStream* _AudioStream = null;
	public:
		//basic information
		virtual int Id() { return -1; }
		bool IsAvailable() { return _AudioStream == null; }
		int AudioId() { return _AudioStream->Id(); }

		//common commands
		virtual void Mute() {}
		virtual void UnMute() {}
		virtual void Play(AudioStream* stream) {}
		virtual void Stop() {}
		virtual void Pause() {}
		virtual void Resume() {}
		virtual void SetVolume(int volume) {}
	};
}