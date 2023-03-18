#include "AuditService.h"
#include "AdminResource.h"

namespace GameAdmin
{
	unique_ptr<AuditService> AuditService::_AuditService = unique_ptr<AuditService>(new AuditService);

	AuditService::AuditService() : GameCacheAbleSetting("AuditService")
	{
		_Type = ResourceType::ADMIN;
		_ResourceId = (int)AdminResource::AUDIT;
	}

	AuditService* AuditService::Instance()
	{
		return _AuditService.get();
	}
}