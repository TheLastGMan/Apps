#include <iostream>
#include <chrono>
#include "MemoryStream.h"
#include "ScriptService.h"
#include "SystemScriptProcessor.h"
#include "EqualityScriptProcessor.h"
#include "BasicMathScriptProcessor.h"
#include "ResourceService.h"
#include "Logger.h"
#include "Exception.h"

using namespace Logging;
using namespace System;
using namespace Scripting;
using namespace Scripting::Processor;
using namespace Resource;

byte dataStream[][1024] = {
	{ 31,0,0,0,4,0,0,0,0,0,0,0 }, //return 0
	{ 31,0,0,0,150,1,0,0,1,0,0,0,0,0,0,0 }, //return @Var[0]
	{ 31,0,0,0,8,0,0,0,4,0,0,0,1,0,0,0,1,0,0,0,4,0,0,0,255,255,255,255 }, //return another scripts value with generic parameter
	{ 148,1,0,0,4,0,0,0,6,0,0,0,148,1,0,0,4,0,0,0,14,0,0,0,148,1,0,0,200,0,0,0,4,0,0,0,160,15,0,0,4,0,0,0,97,0,0,0,32,0,0,0,52,0,0,0,16,0,0,0,86,1,0,0,150,1,0,0,158,1,0,0,4,0,0,0,255,3,0,0,7,0,0,0,152,1,0,0,4,0,0,0,0,0,0,0,4,0,0,0,255,3,0,0,2,0,0,0,38,0,0,0,16,0,0,0,86,1,0,0,150,1,0,0,158,1,0,0,4,0,0,0,255,7,0,0,7,0,0,0,152,1,0,0,4,0,0,0,0,0,0,0,4,0,0,0,255,7,0,0,2,0,0,0,24,0,0,0,16,0,0,0,86,1,0,0,150,1,0,0,158,1,0,0,4,0,0,0,1,16,0,0,12,0,0,0,152,1,0,0,4,0,0,0,1,0,0,0,4,0,0,0,1,16,0,0,152,1,0,0,158,1,0,0,4,0,0,0,255,3,0,0,34,0,0,0,2,0,0,0,5,0,0,0,152,1,0,0,4,0,0,0,0,0,0,0,4,0,0,0,255,255,255,255,112,0,0,0,154,1,0,0,148,1,0,0,4,0,0,0,6,0,0,0,148,1,0,0,4,0,0,0,14,0,0,0,16,0,0,0,68,1,0,0,200,0,0,0,150,1,0,0,4,0,0,0,0,0,0,0,150,1,0,0,4,0,0,0,1,0,0,0,4,0,0,0,15,0,0,0,7,0,0,0,152,1,0,0,4,0,0,0,0,0,0,0,4,0,0,0,128,0,0,0,2,0,0,0,5,0,0,0,152,1,0,0,4,0,0,0,1,0,0,0,4,0,0,0,255,0,0,0,1,0,0,0,16,0,0,0,20,0,0,0,4,0,0,0,1,0,0,0,16,0,0,0,20,0,0,0,4,0,0,0,1,0,0,0,12,0,0,0,20,0,0,0,64,1,0,0,200,0,0,0,4,0,0,0,32,0,0,0,4,0,0,0,64,0,0,0,4,0,0,0,90,0,0,0,2,0,0,0,4,0,0,0,1,0,0,0,5,0,0,0,152,1,0,0,4,0,0,0,1,0,0,0,4,0,0,0,255,1,0,0,152,1,0,0,4,0,0,0,1,0,0,0,20,0,0,0,4,0,0,0,1,0,0,0,10,0,0,0,24,0,0,0,4,0,0,0,1,0,0,0,6,0,0,0,20,0,0,0,4,0,0,0,1,0,0,0,2,0,0,0,4,0,0,0,1,0,0,0,1,0,0,0,152,1,0,0,4,0,0,0,0,0,0,0,8,0,0,0,4,0,0,0,1,0,0,0,2,0,0,0,4,0,0,0,0,4,0,0,4,0,0,0,0,8,0,0,31,0,0,0,4,0,0,0,159,0,0,0 }
};
int dataLength[] = { 12, 16, 28, 632 }; //bytes

class ConsoleLogger : public ILogger
{
public:
	void LogDebug(string message) { cout << "DEBUG: " << message << endl; }
	void LogInfo(string message) { cout << "INFO: " << message << endl; }
	void LogWarning(string message) { cout << "WARN: " << message << endl; }
	void LogError(string message) { cout << "ERROR: " << message << endl; }
};

class DebugScriptStream : public IResourceLocator
{
public:
	int Id() { return -1; };

	BinaryReader* Load(ResourceType type, int id)
	{
		auto result = new BinaryReader(new MemoryStream(dataStream[id], dataLength[id], false));
		return result;
	};

	BinaryWriter* SaveStream(ResourceType type, int id)
	{
		auto result = new BinaryWriter(new MemoryStream(dataStream[id], dataLength[id], true));
		return result;
	}
};

using namespace std::chrono;
int main()
{
	Logger::Provide(new ConsoleLogger());
	Logger::LogInfo("START");

	auto resourceStream = unique_ptr<DebugScriptStream>(new DebugScriptStream());
	ResourceService::AddLocater(resourceStream.get());

	ScriptService::AddGeneralProcessor(SystemScriptProcessor());
	ScriptService::AddGeneralProcessor(EqualityScriptProcessor());
	ScriptService::AddGeneralProcessor(BasicMathScriptProcessor());

	milliseconds msStart = duration_cast<milliseconds>(system_clock::now().time_since_epoch());
	try
	{
		ScriptService::ProcessScript(3);
	}
	catch (Exception* ex)
	{
		Exception* main = ex;
		do
		{
			string message = ex->Message();
			Logger::LogError(message);
		} while ((ex = ex->InnerException()) != null);
		delete main;
	}

	//Duration
	milliseconds msEnd = duration_cast<milliseconds>(system_clock::now().time_since_epoch());
	cout << "Script Time (ms): " << to_string((int)(msEnd.count() - msStart.count())) << endl;

	//Remove Script Processors
	ScriptService::RemoveGeneralProcessor(SystemScriptProcessor());
	ScriptService::RemoveGeneralProcessor(EqualityScriptProcessor());
	ScriptService::RemoveGeneralProcessor(BasicMathScriptProcessor());

	ResourceService::RemoveLocater(resourceStream.get());
	Logger::LogInfo("END");
}