#pragma once
#include "Types.h"

namespace DateTime
{
	typedef union
	{
		struct {
			byte Day : 5;
			byte Month : 4;
			byte Year : 7;
			byte DayOfWeek : 3;
			ushort DayOfYear : 9;
			bool IsLeapYear : 1;
		};
		int RAW;
	} DATE;
}