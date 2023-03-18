#pragma once
#include "GameSetting.h"
#include <memory>
#include <string>

using namespace DataType;

namespace GameAdmin
{
	class GlobalSettingService : public GameSetting
	{
	private:
		static unique_ptr<GlobalSettingService> _Instance;
		GlobalSettingService();
	public:
		static GlobalSettingService* Instance();
		void Fill(int count);
	};
}