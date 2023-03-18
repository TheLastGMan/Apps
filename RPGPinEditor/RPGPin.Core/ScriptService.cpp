#include "ScriptService.h"
#include <memory>
#include "VariableScriptProcessor.h"
#include "ResourceService.h"
#include "UnknownCommandException.h"
#include "Logger.h"

using namespace std;
using namespace Resource;
using namespace Scripting::Processor;
using namespace System::IO;
using namespace Logging;

namespace Scripting
{
	enum class ScriptCommandCode : int
	{
		Return = 31
	};

	//set static defaults
	UniqueCollection<IScriptProcessor*> ScriptService::_GeneralProcessors = UniqueCollection<IScriptProcessor*>();

	ScriptService::~ScriptService()
	{
		//clean up
		while(_ScriptProcessors.Any())
			delete _ScriptProcessors.Pop();
	}

	/*
	<summary>Compares two scripts to check if their id's are equal</summary>
	<param name="o1">Script Processor 1</param>
	<param name="o2">Script Processor 2</param>
	<returns>T/F if they match</returns>
	<access>Private Static</access>
	*/
	bool ScriptService::scriptComparer(IScriptProcessor* o1, IScriptProcessor* o2)
	{
		return o1->Id() == o2->Id();
	}

	/*
	<summary>Script entry point, find script and process</summary>
	<param name="id">Script Id</param>
	<returns>script processed value</returns>
	<access>Public Static</access>
	*/
	int ScriptService::ProcessScript(int id)
	{
		//process script with default values
		return ProcessScript(id, ParameterBlock());
	}

	/*
	<summary>Secondary entry point, runs script with specified input parameters</summary>
	<param name="id">Script Id</param>
	<param name="inputParameters">Input parameter values for script</param>
	<returns>Script processed value</returns>
	<access>Protected</access>
	*/
	int ScriptService::ProcessScript(int id, ParameterBlock inputParameters)
	{
		return ProcessScript(id, inputParameters, null);
	}

	int ScriptService::ProcessScript(int id, ParameterBlock inputParameters, IScriptProcessor* customProcessor)
	{
		Logger::LogDebug("Script: Process: " + to_string(id));

		//load stream
		unique_ptr<BinaryReader> stream(ResourceService::Load(ResourceType::SCRIPT, id));

		//setup
		unique_ptr<ScriptService> svc(new ScriptService(id, null));
		auto vsp = new VariableScriptProcessor();
		vsp->InputParameterAddRange(inputParameters);

		//load initial script processors
		svc->PushScriptProcessor(vsp);

		//process stream
		int result = 0;
		try
		{
			svc->ProcessMethod(stream.get());
		}
		catch (Exception* ex)
		{
			//looks like c++ deletes my in use pointers of this method
			throw new Exception("Script: Error: " + to_string(id), ex);
		}

		//give result
		return result;
	}

	/*
	<summary>Add a global general processor that parses commands, checks that it is unique</summary>
	<param name="processor">Script processor</param>
	<access>Public Static</access>
	*/
	void ScriptService::AddGeneralProcessor(IScriptProcessor& processor)
	{
		if (_GeneralProcessors.Add(&processor, scriptComparer))
			Logger::LogDebug("Script: General processor: " + to_string(processor.Id()) + " | Added");
	}

	/*
	<summary>Remove a specified global script processor</summary>
	<param name="processor">Script processor</param>
	<access>Public Static</access>
	*/
	void ScriptService::RemoveGeneralProcessor(IScriptProcessor& processor)
	{
		if (_GeneralProcessors.Delete(&processor, scriptComparer))
			Logger::LogDebug("Script: General processor:" + to_string(processor.Id()) + " | Removed");
	}

	int ScriptService::ProcessMethod(BinaryReader* stream)
	{
		//process script until return statement is reached or unknown command
		int result = 0;
		while (!_ReturnFromScript)
		{
			result = Process(stream);
		}

		//log return value
		Logger::LogDebug("Script: Id: " + to_string(_RunningScriptId) + " | Return: " + to_string(result));
		return result;
	}

	/*
	<summary>Process script as a stream</summary>
	<param name="stream">Binary stream to process script commands</param>
	<returns>script processed value</returns>
	<access>Protected</access>
	*/
	int ScriptService::Process(BinaryReader* stream)
	{
		//next command
		int code = stream->ReadInt32();
		Logger::LogDebug("Script: Running: " + to_string(_RunningScriptId) + " | Code: " + to_string(code));

		//check for return code if we are not already returning, prevent infinite return loop
		if (code == (int)ScriptCommandCode::Return && !_ReturnFromScript)
		{
			_ReturnFromScript = true;
			return Process(stream);
		}

		//create default result
		int result = 0;

		//check custom processor
		if (_CustomProcessor != null)
			if (_CustomProcessor->Process(this, stream, code, result))
				return result;

		//go through master script processors
		for (auto it = _ScriptProcessors.rbegin(); it != _ScriptProcessors.rend(); it++)
		{
			//process and give result if decoded
			if ((*it)->Process(this, stream, code, result))
			{
				return result;
			}
		}

		//go through general processors
		for each (auto processor in _GeneralProcessors)
		{
			//process and give result if decoded
			if (processor->Process(this, stream, code, result))
			{
				return result;
			}
		}

		//if we reached this point, it wasn't a known command
		throw new UnknownCommandException(_RunningScriptId, stream->BaseStream()->Position(), code);
	}

	/*
	<summary>Push a top level script processor, called first to process commands</summary>
	<param name="processor">Script processor</param>
	<access>Protected</access>
	*/
	void ScriptService::PushScriptProcessor(IScriptProcessor* processor)
	{
		if (_ScriptProcessors.Add(processor))
			Logger::LogDebug("Script: Processor Added: " + to_string(processor->Id()));
		else
			//throw an error as this is required for proper functionality
			throw new Exception("Script: Processor Add Unable: " + to_string(processor->Id()));
	}

	/*
	<summary>Pop the last script processor</summary>
	*/
	object ScriptService::PopScriptProcessor()
	{
		return _ScriptProcessors.Pop();
	}
}