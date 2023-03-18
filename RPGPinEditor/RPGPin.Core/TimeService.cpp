#include "TimeService.h"
#include "Types.h"
#include "Logger.h"

using namespace Logging;

namespace HAL
{
	unique_ptr<ITimeProvider> TimeService::_Provider = null;

	void TimeService::Provide(ITimeProvider* provider)
	{
		_Provider.reset((provider != null) ? provider : new ITimeProvider());
		Logger::LogDebug("TimeService: Provide: " + to_string(_Provider->Id()));
	}

	ITimeProvider* TimeService::Retrieve()
	{
		//check if provider should be set
		if (_Provider.get() == null)
			Provide(null);

		//provide instance
		Logger::LogDebug("TimeService: Retrieve: " + to_string(_Provider->Id()));
		return _Provider.get();
	}
}
