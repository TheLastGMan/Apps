#pragma once
#include "ScriptService.h"
#include "GameSetting.h"

using namespace Scripting;

namespace GameAdmin
{
	class SettingScriptProcessor : public IScriptProcessor
	{
	private:
		int Get(GameSetting* providor, BinaryReader* stream);
		void Set(GameSetting* providor, BinaryReader* stream);
		int Increment(GameSetting* providor, BinaryReader* stream);
	public:
		int Id();
		bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
	};
}