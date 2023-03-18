#pragma once
#include "ScriptService.h"

namespace Scripting
{
	namespace Processor
	{
		class SwitchScriptProcessor : public IScriptProcessor
		{
		private:
			int _InitialPosition;
			int _BreakPosition;
		public:
			SwitchScriptProcessor(int initialPosition, int breakPosition);
			int Id();
			bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
		};
	}
}