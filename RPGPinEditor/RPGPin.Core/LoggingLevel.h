#pragma once

namespace Logging
{
	enum class LoggingLevel : int
	{
		//System is unusable
		Emergency = 0,
		Emerg = 0,

		//should be corrected immediately
		Alert = 1,

		//Critical Conditions (failue in primary app)
		Critical = 2,
		Crit = 2,

		//Error Conditions (app exceeded storage limit)
		Error = 3,
		Err = 3,

		//Indicate that an error will occur if action is not taken (file sys has 2GB remaining)
		Warning = 4,

		//Events are unusual, but not errors
		Notice = 5,

		//Normal op messages, require no action (started, stopped, etc)
		Informational = 6,
		Info = 6,

		//Useful to developers
		Debug = 7
	};
}