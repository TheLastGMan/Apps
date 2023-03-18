#pragma once
#include <string>
#include <memory>
#include "LoggingLevel.h"
#include "ILogger.h"

namespace Logging
{
	class Logger
	{
	private:
		static unique_ptr<ILogger> _MasterLogger;
	public:
		static void Provide(ILogger* logger);

		//override
		static void LogDebug(string message);
		static void LogInfo(string message);
		static void LogWarn(string message);
		static void LogError(string message);
	};
}