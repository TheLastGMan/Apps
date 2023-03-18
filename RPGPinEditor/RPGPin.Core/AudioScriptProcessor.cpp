#include "AudioScriptProcessor.h"
#include "AudioService.h"

namespace Audio
{
	enum class AudioCommandCode : int
	{
		//TODO: AudioScriptProcessor: Command Code Values
		AudioPlay = 500, //(AudioStream(id, volume))
		AudioPlayImmediate = 502, //(AudioStream(id, volume))
		AudioStop = 504, //(channel)
		AudioStopAll = 506,

		AudioSetMute = 508, //(channel, mute T/F)
		AudioSetMuteAll = 510, //(mute T/F)

		AudioSetVolume = 512, //(channel, volume)
		AudioSetVolumeAll = 514, //(volume)

		AudioPause = 516, //(channel)
		AudioPauseAll = 518,

		AudioResume = 520, //(channel)
		AudioResumeAll = 522,

		AudioChannels = 524
	};

	int AudioScriptProcessor::Id()
	{
		return 500;
	}

	bool AudioScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
	{
		int channel = 0;
		int rvalue = 0;

		//check for audio action
		switch ((AudioCommandCode)code)
		{
		case AudioCommandCode::AudioPlay:
			//(AudioStream(id, volume))
			channel = service->Process(stream);
			rvalue = service->Process(stream);
			//TODO: AudioScriptProcessor: Play
			break;
		case AudioCommandCode::AudioPlayImmediate: //(AudioStream(id, volume))
			channel = service->Process(stream);
			rvalue = service->Process(stream);
			//TODO: AudioScriptProcessor: PlayImmediate
			break;
		case AudioCommandCode::AudioStop: //(channel)
			channel = service->Process(stream);
			AudioService::Stop(channel);
			break;
		case AudioCommandCode::AudioStopAll:
			AudioService::StopAll();
			break;

		case AudioCommandCode::AudioSetMute: //(channel: mute T/F)
			channel = service->Process(stream);
			rvalue = service->Process(stream);
			AudioService::SetMute(channel, rvalue != 0);
			break;
		case AudioCommandCode::AudioSetMuteAll: //(mute T/F)
			rvalue = service->Process(stream);
			AudioService::MuteAll(rvalue != 0);
			break;

		case AudioCommandCode::AudioSetVolume: //(channel: volume)
			channel = service->Process(stream);
			rvalue = service->Process(stream);
			AudioService::SetVolume(channel, rvalue);
			break;
		case AudioCommandCode::AudioSetVolumeAll: //(volume)
			rvalue = service->Process(stream);
			AudioService::SetVolumeAll(rvalue);
			break;

		case AudioCommandCode::AudioPause: //(channel)
			channel = service->Process(stream);
			AudioService::Pause(channel);
			break;
		case AudioCommandCode::AudioPauseAll:
			AudioService::PauseAll();
			break;

		case AudioCommandCode::AudioResume:
			//(channel)
			channel = service->Process(stream);
			AudioService::Resume(channel);
			break;
		case AudioCommandCode::AudioResumeAll:
			AudioService::ResumeAll();
			break;

		case AudioCommandCode::AudioChannels:
			result = AudioService::ChannelCount();
			break;

		default:
			return false;
		}

		//default
		return true;
	}
}