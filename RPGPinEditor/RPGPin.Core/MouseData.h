#pragma once
#include "MouseAction.h"

namespace HAL
{
	namespace IO
	{
		typedef struct
		{
			int Id;
			MouseAction Action;
		} MouseData;
	}
}