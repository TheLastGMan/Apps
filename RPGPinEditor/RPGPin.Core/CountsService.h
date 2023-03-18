#pragma once
#include "GameCacheAbleSetting.h"

namespace GameAdmin
{
	class CountsService : public GameCacheAbleSetting
	{
	private:
		static unique_ptr<CountsService> _Instance;
		CountsService();
	public:
		static CountsService* Instance();
	};
}