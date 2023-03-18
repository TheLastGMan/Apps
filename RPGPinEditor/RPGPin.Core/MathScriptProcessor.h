#pragma once
#include "ScriptService.h"

using namespace Scripting;

namespace HAL
{
	class MathScriptProcessor : IScriptProcessor
	{
	public:
		int Id();
		bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
	};
}