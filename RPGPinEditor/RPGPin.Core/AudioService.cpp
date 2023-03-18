#include "AudioService.h"
#include "Logger.h"

using namespace Logging;

namespace Audio
{
	UniqueCollection<IAudioChannel*> AudioService::_AudioChannels = UniqueCollection<IAudioChannel*>();
	BasicCollection<AudioStream*> AudioService::_AudioQueue = BasicCollection<AudioStream*>();

	bool AudioService::audioComparer(IAudioChannel* o1, IAudioChannel* o2)
	{
		return o1->Id() == o2->Id();
	}

	void AudioService::AddChannel(IAudioChannel* channel)
	{
		if (_AudioChannels.Add(channel, audioComparer))
			Logger::LogDebug("Audio: Added Id: " + to_string(channel->Id()) + " | Channel: " + to_string(_AudioChannels.Count() - 1));
	}

	void AudioService::RemoveChannel(IAudioChannel* channel)
	{
		if (_AudioChannels.Delete(channel, audioComparer))
			Logger::LogDebug("Audio: Removed Id: " + to_string(channel->Id()));
	}

	void AudioService::applyChannelAction(void(*action)(int))
	{
		int channel = 0;
		for (auto it = _AudioChannels.begin(); it != _AudioChannels.end(); it++)
			action(channel++);
	}

	int AudioService::ChannelCount()
	{
		return _AudioChannels.Count();
	}

	void AudioService::Update()
	{
		//log status
		Logger::LogDebug("Audio: Updating");

		//go though audio channels, add from queue if slot available
		for (auto it = _AudioChannels.begin(); it != _AudioChannels.end(); it++)
			if ((*it)->IsAvailable())
				if (_AudioQueue.Any())
					(*it)->Play(_AudioQueue.Pop());
				else
					break; //exit loop, nothing to play
	}

	void AudioService::Mute(int channel)
	{
		Logger::LogDebug("Audio: Mute Channel: " + to_string(channel));
		_AudioChannels.ValueAt(channel)->Mute();
	}

	void AudioService::UnMute(int channel)
	{
		Logger::LogDebug("Audio: UnMute Channel: " + to_string(channel));
		_AudioChannels.ValueAt(channel)->UnMute();
	}

	//Play a given stream, returns channel or -1 if queued
	int AudioService::Play(AudioStream* stream)
	{
		Logger::LogDebug("Audio: Play AudioStream: " + to_string(stream->Id()));

		if (_AudioChannels.Any())
		{
			//check queue for duplicate, update previous with max volume of both
			for (auto it = _AudioQueue.begin(); it != _AudioQueue.end(); it++)
				if ((*it) == stream)
				{
					//update with higher of two volumes
					if (stream->Volume() > (*it)->Volume())
						(*it)->SetVolume(stream->Volume());

					//item was in queue, no point in trying to find open channel
					return -1;
				}

			//check for open channel
			int channel = 0;
			for (auto it = _AudioChannels.begin(); it != _AudioChannels.end(); it++, channel++)
				if ((*it)->IsAvailable())
				{
					(*it)->Play(stream);
					return channel;
				}

			//got this far, add to queue
			if (_AudioQueue.Add(stream))
				Logger::LogDebug("Audio: Play AudioStream: " + to_string(stream->Id()) + " | Queued");
			else
				//only log a warning, not critical if we can't play a stream
				Logger::LogWarn("Audio: Play AudioStream: " + to_string(stream->Id()) + " | Unable to Queue");
		}
		else
			Logger::LogDebug("Audio: Play AudioStream: " + to_string(stream->Id()) + " | No Audio Channels");

		//default return
		return -1;
	}

	//Play a given stream immediately, kick highest id
	int AudioService::PlayImmediate(AudioStream* stream)
	{
		Logger::LogDebug("Audio: Play AudioStream Immediate: " + to_string(stream->Id()));

		if (_AudioChannels.Any())
		{
			//we know we have audio channels, so if play returns false, kick highest audio stream
			int activeChannel = Play(stream);
			if (activeChannel == -1)
			{
				//high AudioStream info
				int highChannel = 0;
				int highId = -1;

				//find lowest priority audio stream
				int channel = 0;
				for (auto it = _AudioChannels.begin(); it != _AudioChannels.end(); it++, channel++)
				{
					int audioId = (*it)->AudioId();
					if (audioId > highId)
					{
						highChannel = channel;
						highId = audioId;
					}
				}

				//kick highest audio
				_AudioChannels.ValueAt(highChannel)->Play(stream);
			}
			else
				return activeChannel;
		}
		else
			Logger::LogDebug("Audio: Play AudioStream Immediate: " + to_string(stream->Id()) + " | No Audio Channels");

		//default return;
		return -1;
	}

	void AudioService::Stop(int channel)
	{
		Logger::LogDebug("Audio: Stop Channel: " + to_string(channel));
		_AudioChannels.ValueAt(channel)->Stop();
	}

	void AudioService::StopAll()
	{
		applyChannelAction(Stop);
	}

	void AudioService::SetMute(int channel, bool mute)
	{
		Logger::LogDebug("Audio: Set Mute Channel: " + to_string(channel) + " | Mute: " + to_string(mute));

		//Mute or UnMute based on selection
		if (mute)
			Mute(channel);
		else
			UnMute(channel);
	}

	void AudioService::MuteAll(bool mute)
	{
		int channel = 0;
		for (auto it = _AudioChannels.begin(); it != _AudioChannels.end(); it++)
			SetMute(channel++, mute);
	}

	void AudioService::SetVolume(int channel, int volume)
	{
		Logger::LogDebug("Audio: Set Volume Channel: " + to_string(channel) + " | Volume: " + to_string(volume));
		_AudioChannels.ValueAt(channel)->SetVolume(volume);
	}

	void AudioService::SetVolumeAll(int volume)
	{
		int channel = 0;
		for (auto it = _AudioChannels.begin(); it != _AudioChannels.end(); it++)
			SetVolume(channel++, volume);
	}

	void AudioService::Pause(int channel)
	{
		Logger::LogDebug("Audio: Pause Channel: " + to_string(channel));
		_AudioChannels.ValueAt(channel)->Pause();
	}

	void AudioService::PauseAll()
	{
		applyChannelAction(Pause);
	}

	void AudioService::Resume(int channel)
	{
		Logger::LogDebug("Audio: Resume Channel: " + to_string(channel));
		_AudioChannels.ValueAt(channel)->Resume();
	}

	void AudioService::ResumeAll()
	{
		applyChannelAction(Resume);
	}
}