#include "Mode.h"
#include "ScriptProcessor.h"
#include "ModeService.h"

namespace GameService
{
	enum class ModeCommandCode : int
	{
		ModeAdd = 5000,
		ModeRemoveLast = 5002,
		ModeRemoveSelf = 5004,
		ModeRemoveId = 5006,
		ModeRemoveAllId = 5008,

		ModeVariableGet = 5100,
		ModeVariableSet = 5102,
		ModeVariableAdd = 5104
	};

	int Mode::Id()
	{
		return (int)DataType::ScriptProcessor::Modes;
	}

	bool Mode::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
	{
		int lvalue = 0;
		int rvalue = 0;

		switch ((ModeCommandCode)code)
		{
			//mode commands
		case ModeCommandCode::ModeAdd:
			lvalue = stream->ReadInt32();
			ModeService::StartMode(lvalue, stream);
			break;
		case ModeCommandCode::ModeRemoveLast:
			ModeService::EndLastMode();
			break;
		case ModeCommandCode::ModeRemoveId:
			lvalue = stream->ReadInt32();
			ModeService::EndLastSpecificMode(lvalue);
			break;
		case ModeCommandCode::ModeRemoveAllId:
			lvalue = stream->ReadInt32();
			ModeService::EndAllSpecificMode(lvalue);
			break;
		case ModeCommandCode::ModeRemoveSelf:
			ModeService::EndLastSpecificMode(ModeId());
			break;

			//mode variables
		case ModeCommandCode::ModeVariableGet:
			lvalue = stream->ReadInt32();
			result = Variables.Get(lvalue);
			break;
		case ModeCommandCode::ModeVariableSet:
			lvalue = stream->ReadInt32();
			rvalue = stream->ReadInt32();
			Variables.Set(lvalue, rvalue);
			break;
		case ModeCommandCode::ModeVariableAdd:
			lvalue = stream->ReadInt32();
			rvalue = stream->ReadInt32();
			result = Variables.Add(lvalue, rvalue);
			break;

		default:
			return false;
		}

		//default not reached, passed
		return true;
	}
}
