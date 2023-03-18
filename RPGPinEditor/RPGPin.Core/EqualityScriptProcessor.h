#pragma once
#include "ScriptService.h"

namespace Scripting
{
	namespace Processor
	{
		class EqualityScriptProcessor : public IScriptProcessor
		{
		public:
			int Id();
			bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
		};
	}
}