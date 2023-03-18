#pragma once
#include <memory>
#include "GameSetting.h"
#include "Types.h"
#include "BasicCollection.h"
#include "ResourceType.h"

using namespace DataType;
using namespace Resource;

namespace GameAdmin
{
	class GameCacheAbleSetting : public GameSetting
	{
	protected:
		GameCacheAbleSetting(string name) : GameSetting(name) {}
		ResourceType _Type = ResourceType::UNK;
		int _ResourceId = 0;
	public:
		//general usage
		ResourceType Type() { return _Type; }
		int ResourceId() { return _ResourceId; }

		//specific
		void Fill();
		void Flush();
	};
}