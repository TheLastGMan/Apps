#include "GlobalSettingService.h"
#include "AdminResource.h"
#include "Logger.h"

using namespace Logging;

namespace GameAdmin
{
	unique_ptr<GlobalSettingService> GlobalSettingService::_Instance = unique_ptr<GlobalSettingService>(new GlobalSettingService());

	GlobalSettingService::GlobalSettingService() : GameSetting("GlobalSetting")
	{
	}

	GlobalSettingService* GlobalSettingService::Instance()
	{
		return _Instance.get();
	}

	void GlobalSettingService::Fill(int count)
	{
		Logger::LogDebug(Name() + ": Fill: " + to_string(count));
		ClearAll();
		while (count-- > 0)
			AddLast(0);
	}
}