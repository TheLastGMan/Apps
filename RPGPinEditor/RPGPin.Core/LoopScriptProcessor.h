#pragma once
#include "ScriptService.h"

namespace Scripting
{
	namespace Processor
	{
		class LoopScriptProcessor : public IScriptProcessor
		{
		private:
			int _BreakPosition;
			int _ContinuePosition;
		public:
			LoopScriptProcessor(int breakPosition, int continuePosition);
			int Id();
			bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
		};
	}
}