#pragma once
#include "ModeKeyMap.h"
#include "GameSetting.h"
#include "ScriptService.h"

using namespace DataType;
using namespace GameAdmin;
using namespace Scripting;

namespace GameService
{
	class Mode : public IScriptProcessor
	{
	private:
		int Id;
	public:
		BasicCollection<ModeKeyMap> KeyMap = BasicCollection<ModeKeyMap>();
		ISettingProvider Variables;
		int StartingScriptId;
		int EndingScriptId;
		bool MarkedForDelete;

		Mode(int id)
		{
			Id = id;
			Variables = GameSetting("Mode" + to_string(id));
		}
		int ModeId() { return Id; }

		//script overrides
		int Id();
		bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
	};
}