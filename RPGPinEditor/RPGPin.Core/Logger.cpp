#include "Types.h"
#include "Logger.h"

namespace Logging
{
	unique_ptr<ILogger> Logger::_MasterLogger = unique_ptr<ILogger>(new ILogger());

	void Logger::Provide(ILogger* logger)
	{
		_MasterLogger.reset((logger != null) ? logger : new ILogger());
		LogDebug("Logger: Provided");
	}

	void Logger::LogDebug(string message)
	{
		_MasterLogger->LogDebug(message);
	}

	void Logger::LogInfo(string message)
	{
		_MasterLogger->LogInfo(message);
	}

	void Logger::LogWarn(string message)
	{
		_MasterLogger->LogWarning(message);
	}

	void Logger::LogError(string message)
	{
		_MasterLogger->LogError(message);
	}
}