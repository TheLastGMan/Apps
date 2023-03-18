#pragma once
#include "Types.h"

namespace DateTime
{
	typedef union
	{
		struct {
			byte Seconds : 6;
			byte Minutes : 6;
			byte Hours : 4;
			byte AmPm : 1;
		};
		int RAW;
	} TIME;
}
