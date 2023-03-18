#include "GameSetting.h"
#include "Logger.h"

using namespace Logging;

namespace GameAdmin
{
	GameSetting::GameSetting(string name)
	{
		_Name = name;
	}

	void GameSetting::ClearAll()
	{
		Logger::LogDebug(_Name + ": Clear All");
		for (auto it = _Values.begin(); it != _Values.end(); it++)
			*it = 0;
	}

	int GameSetting::Get(int index)
	{
		Logger::LogDebug(_Name + ": Get: " + to_string(index));
		return _Values[index];
	}

	void GameSetting::Set(int index, int value)
	{
		Logger::LogDebug(_Name + ": Set: " + to_string(index) + " | Value: " + to_string(value));
		_Values.Update(index, value);
	}

	int GameSetting::Add(int index, int value)
	{
		Logger::LogDebug(_Name + ": Add: " + to_string(index) + " | Value: " + to_string(value));
		int newValue = _Values[index] + value;
		_Values.Update(index, newValue);
		return newValue;
	}

	int GameSetting::AddNew(int value)
	{
		_Values.Add(value);
		return _Values.Count();
	}

	void GameSetting::AddLast(int value)
	{
		Logger::LogDebug(_Name + ": AddLast: " + to_string(value));
		_Values.Add(value);
	}

	int GameSetting::Count()
	{
		Logger::LogDebug(_Name + ": Count");
		return _Values.Count();
	}

	void GameSetting::Dispose()
	{
		Logger::LogDebug(_Name + ": Dispose");
		_Values.Clear();
	}
}