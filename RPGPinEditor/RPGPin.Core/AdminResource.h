#pragma once

namespace GameAdmin
{
	enum class AdminResource : int
	{
		GLOBAL = 1,
		AUDIT = 2,
		SETTING = 4,
		TIMESTAMP = 8,
		COUNTS = 16
	};
}