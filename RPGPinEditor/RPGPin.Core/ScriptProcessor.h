#pragma once

namespace DataType
{
	enum class ScriptProcessor : int
	{
		SYSTEM = 3, //1 | 2
		Switch = 4,
		Loop = 8,
		System = 100,
		BasicMath = 200,
		Equality = 300,
		Variable = 400,

		Audio = 500,
		Time = 800,
		Math = 900,
		GameAdminSettings = 3000,
		GameService = 4000,
		Modes = 5000,

		TBD = 0
	};
}