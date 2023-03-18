#pragma once
#include <string>

using namespace std;

namespace Logging
{
	class ILogger
	{
	public:
		virtual void LogDebug(string message) {};
		virtual void LogInfo(string message) {};
		//virtual void LogNotice(string message) {};
		virtual void LogWarning(string message) {};
		virtual void LogError(string message) {};
		//virtual void LogCirtical(string message) {};
		//virtual void LogAlert(string message) {};
	};
}