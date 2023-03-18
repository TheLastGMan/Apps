#include "SettingService.h"
#include "AdminResource.h"

namespace GameAdmin
{
	unique_ptr<SettingService> SettingService::_Instance = unique_ptr<SettingService>(new SettingService());

	SettingService::SettingService() : GameCacheAbleSetting("SettingService")
	{
		_Type = ResourceType::ADMIN;
		_ResourceId = (int)AdminResource::SETTING;
	}

	SettingService* SettingService::Instance()
	{
		return _Instance.get();
	}
}