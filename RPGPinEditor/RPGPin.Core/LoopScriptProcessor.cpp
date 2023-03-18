#include "LoopScriptProcessor.h"
#include "BlockCommandCode.h"
#include "ScriptProcessor.h"

namespace Scripting
{
	namespace Processor
	{
		LoopScriptProcessor::LoopScriptProcessor(int breakPosition, int continuePosition)
		{
			_BreakPosition = breakPosition;
			_ContinuePosition = continuePosition;
		};

		int LoopScriptProcessor::Id()
		{
			return (int)DataType::ScriptProcessor::Loop;
		}

		bool LoopScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
		{
			switch ((BlockCommandCode)code)
			{
			case BlockCommandCode::Break:
				stream->BaseStream()->Seek(_BreakPosition, SeekOrigin::Begin);
				break;
			case BlockCommandCode::Continue:
				stream->BaseStream()->Seek(_ContinuePosition, SeekOrigin::Begin);
				break;

			default:
				return false;
			}

			return true;
		}
	}
}