#include "RandomService.h"
#include "Logger.h"

using namespace Logging;

namespace HAL
{
	unique_ptr<Random> RandomService::_Provider = null;

	void RandomService::Provide(Random* provider)
	{
		_Provider.reset((provider != null) ? provider : new Random());
		Logger::LogDebug("RandomService: Provide: " + to_string(_Provider->Id()));
	}

	Random* RandomService::Retrieve()
	{
		//check if provider should be set
		if (_Provider.get() == null)
			Provide(null);

		//provide instance
		Logger::LogDebug("RandomService: Retrieve: " + to_string(_Provider->Id()));
		return _Provider.get();
	}
}
