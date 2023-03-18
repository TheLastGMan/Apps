#pragma once
#include "ScriptService.h"

using namespace Scripting;

namespace GameService
{
	class GameServiceScriptProcessor : public IScriptProcessor
	{
	public:
		int Id();
		bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
	};
}