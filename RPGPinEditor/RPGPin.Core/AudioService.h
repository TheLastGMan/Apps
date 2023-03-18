#pragma once
#include "AudioStream.h"
#include "IAudioChannel.h"
#include "UniqueCollection.h"

using namespace DataType;
using namespace System::IO;

namespace Audio
{
	class AudioService
	{
	private:
		AudioService() {};
		static UniqueCollection<IAudioChannel*> _AudioChannels;
		static BasicCollection<AudioStream*> _AudioQueue;
		static void applyChannelAction(void(*action)(int));
		static bool audioComparer(IAudioChannel* o1, IAudioChannel* o2);
	public:
		//Channels
		static void AddChannel(IAudioChannel* channel);
		static void RemoveChannel(IAudioChannel* channel);
		static void Update(); //loads queued items into available channels
		static void Mute(int channel);
		static void UnMute(int channel);
		static int ChannelCount();

		//Features
		static int Play(AudioStream* stream); //Play a given stream, returns channel or -1 if queued
		static int PlayImmediate(AudioStream* stream); //Play a given stream immediately, kick highest id

		static void Stop(int channel); //Stop a given channel, makes it available
		static void StopAll(); //Stop all channels

		static void SetMute(int channel, bool mute); //set the mute on a given channel
		static void MuteAll(bool mute); //set mute status on all channels

		static void SetVolume(int channel, int volume);
		static void SetVolumeAll(int volume);

		static void Pause(int channel);
		static void PauseAll();

		static void Resume(int channel);
		static void ResumeAll();
	};
}