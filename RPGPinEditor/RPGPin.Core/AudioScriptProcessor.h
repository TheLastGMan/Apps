#pragma once
#include "ScriptService.h"

using namespace Scripting;

namespace Audio
{
	class AudioScriptProcessor : public IScriptProcessor
	{
	public:
		int Id();
		bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
	};
};