#include "TimeStampService.h"
#include "AdminResource.h"
#include "Logger.h"
#include "TimeService.h"

using namespace HAL;
using namespace Logging;

namespace GameAdmin
{
	unique_ptr<TimeStampService> TimeStampService::_Instance = unique_ptr<TimeStampService>(new TimeStampService());

	TimeStampService::TimeStampService() : GameCacheAbleSetting("TimeStampService")
	{
		_Type = ResourceType::ADMIN;
		_ResourceId = (int)AdminResource::TIMESTAMP;
	}

	TimeStampService* TimeStampService::Instance()
	{
		return _Instance.get();
	}

	void TimeStampService::SetTime(int index)
	{
		Logger::LogDebug(Name() + ": SetTime: " + to_string(index));
		Set(index, TimeService::Retrieve()->Now());
	}
}