#pragma once
#include "ITimeProvider.h"
#include <memory>

namespace HAL
{
	class TimeService
	{
	private:
		static unique_ptr<ITimeProvider> _Provider;
		TimeService() {};
	public:
		static void Provide(ITimeProvider* provider);
		static ITimeProvider* Retrieve();
	};
}