#include "PlayerService.h"
#include "Logger.h"

using namespace Logging;

namespace GameService
{
	string PlayerService::_Name = "PlayerService: ";
	BasicCollection<PlayerSetting*> PlayerService::_Players = BasicCollection<PlayerSetting*>();

	byte PlayerService::Add(int settingCount)
	{
		Logger::LogDebug(_Name + "Add: Settings: " + to_string(settingCount));

		if (_Players.Count() == 256) //check if we are full
			throw new Exception(_Name + "Full");

		//add must be in-line for a strange reason
		_Players.Add(new PlayerSetting(_Players.Count(), settingCount));
		return (byte)(_Players.Count() - 1);
	}

	void PlayerService::Remove()
	{
		delete _Players.Pop();
	}

	int PlayerService::Count()
	{
		Logger::LogDebug(_Name + "Count");
		return _Players.Count();
	}

	PlayerSetting* PlayerService::Player(int index)
	{
		Logger::LogDebug(_Name + "Get: " + to_string(index));
		return _Players[index];
	}

	void PlayerService::Clear()
	{
		Logger::LogDebug(_Name + " Clear");

		//need to delete each Player pointer, raw clear wouldn't do this
		while (_Players.Count() > 0)
			delete _Players.Pop();
	}
}