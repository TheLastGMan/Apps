#pragma once
#include "GameCacheAbleSetting.h"

namespace GameAdmin
{
	class TimeStampService : public GameCacheAbleSetting
	{
	private:
		static unique_ptr<TimeStampService> _Instance;
		TimeStampService();
	public:
		void SetTime(int index);
		static TimeStampService* Instance();
	};
}