#pragma once
#include "Types.h"

namespace HAL
{
	namespace IO
	{
		enum class KeyAction : byte
		{
			Unknown = 0,
			KeyDown = 1,
			KeyHeld = 2,
			KeyUp = 4
		};
	}
}