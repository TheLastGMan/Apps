#pragma once
#include "BinaryReader.h"
#include "UniqueCollection.h"
#include "ParameterBlock.h"
#include "IDisposable.h"

using namespace std;
using namespace System::IO;
using namespace DataType;

namespace Scripting
{
	// IScriptService
	template<typename ISP = IScriptProcessor>
	class IScriptService
	{
	public:
		virtual int Process(BinaryReader* stream) { return 0; };
		virtual void PushScriptProcessor(ISP* processor) {};
		virtual Object PopScriptProcessor() { return null; };
	};

	// IScriptProcessor
	class IScriptProcessor
	{
	public:
		virtual int Id() { return 0; }
		virtual bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result) { return false; };
	};

	// ScriptService
	class ScriptService : protected IScriptService<>
	{
	private:
		static UniqueCollection<IScriptProcessor*> _GeneralProcessors;
		BasicCollection<IScriptProcessor*> _ScriptProcessors;
		IScriptProcessor* _CustomProcessor;
		bool _ReturnFromScript = false;
		int _RunningScriptId;
		ScriptService(int scriptId, IScriptProcessor* customProcessor)
		{
			_RunningScriptId = scriptId;
			_CustomProcessor = customProcessor;
		};
		static bool scriptComparer(IScriptProcessor* o1, IScriptProcessor* o2);
	public:
		~ScriptService();
		int ProcessMethod(BinaryReader* stream);

		//IScriptService:
		int Process(BinaryReader* stream);
		void PushScriptProcessor(IScriptProcessor* processor);
		object PopScriptProcessor();

		//Global Access
		static int ProcessScript(int id);
		static int ProcessScript(int id, ParameterBlock inputParameters);
		static int ProcessScript(int id, ParameterBlock inputParameters, IScriptProcessor* customProcessor);
		static void AddGeneralProcessor(IScriptProcessor& processor);
		static void RemoveGeneralProcessor(IScriptProcessor& processor);
	};
}