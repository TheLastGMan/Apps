#pragma once
#include "GameCacheAbleSetting.h"

namespace GameAdmin
{
	class AuditService : public GameCacheAbleSetting
	{
	private:
		static unique_ptr<AuditService> _AuditService;
		AuditService();
	public:
		static AuditService* Instance();
	};
}