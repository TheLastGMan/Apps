#include "SwitchScriptProcessor.h"
#include "BlockCommandCode.h"
#include "ScriptProcessor.h"

namespace Scripting
{
	namespace Processor
	{
		SwitchScriptProcessor::SwitchScriptProcessor(int initialPosition, int breakPosition)
		{
			_InitialPosition = initialPosition;
			_BreakPosition = breakPosition;
		}

		int SwitchScriptProcessor::Id()
		{
			return (int)DataType::ScriptProcessor::Switch;
		}

		bool SwitchScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
		{
			switch ((BlockCommandCode)code)
			{
			case BlockCommandCode::Break:
				stream->BaseStream()->Seek(_BreakPosition, SeekOrigin::Begin);
				break;
			case BlockCommandCode::GotoCase:
				stream->BaseStream()->Seek(_InitialPosition, SeekOrigin::Begin);
				break;

			default:
				return false;
			}

			return true;
		}
	}
}