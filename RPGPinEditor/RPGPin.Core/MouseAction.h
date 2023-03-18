#pragma once
#include "Types.h"

namespace HAL
{
	namespace IO
	{
		enum class MouseAction : byte
		{
			Unknown = 0,
			Click = 1,
			ClickDouble = 2,
			Release = 4
		};
	}
}