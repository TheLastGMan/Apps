#pragma once
#include "GameCacheAbleSetting.h"

namespace GameAdmin
{
	class SettingService : public GameCacheAbleSetting
	{
	private:
		static unique_ptr<SettingService> _Instance;
		SettingService();
	public:
		static SettingService* Instance();
	};
}