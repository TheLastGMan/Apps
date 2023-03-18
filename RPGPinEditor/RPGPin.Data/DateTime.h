#pragma once
#include "Date.h"
#include "Time.h"

namespace DateTime
{
	typedef struct
	{
		TIME Time;
		DATE Date;
	} DATETIME;
}