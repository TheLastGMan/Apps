#pragma once
#include "Random.h"

namespace HAL
{
	class RandomService
	{
	private:
		static unique_ptr<Random> _Provider;
		RandomService() {};
	public:
		static void Provide(Random* provider);
		static Random* Retrieve();
	};
}