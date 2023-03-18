#pragma once
#include "KeyAction.h"

namespace HAL
{
	namespace IO
	{
		typedef struct
		{
			int Id;
			KeyAction Action;
		} KeyData;
	}
}