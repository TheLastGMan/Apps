#include "CountsService.h"
#include "AdminResource.h"

namespace GameAdmin
{
	unique_ptr<CountsService> CountsService::_Instance = unique_ptr<CountsService>(new CountsService());

	CountsService::CountsService() : GameCacheAbleSetting("CountsService")
	{
		_Type = ResourceType::ADMIN;
		_ResourceId = (int)AdminResource::COUNTS;
	}

	CountsService* CountsService::Instance()
	{
		return _Instance.get();
	}
}
