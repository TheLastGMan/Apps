#include "SettingScriptProcessor.h"
#include "ScriptProcessor.h"
#include "Types.h"
#include "AuditService.h"
#include "SettingService.h"
#include "TimeStampService.h"
#include "PlayerService.h"
#include "CountsService.h"
#include "GlobalSettingService.h"

namespace GameAdmin
{
	enum class GameSettingCommandCode : int
	{
		//Audit
		GameAuditGet = 3000, //index
		GameAuditSet = 3002, //index, value
		GameAuditAdd = 3004, //index, value
		GameAuditCount = 3006,
		GameAuditClearAll = 3008,

		//Settings
		GameSettingGet = 3020, //index
		GameSettingSet = 3022, //index, value
		GameSettingAdd = 3024, //index, value
		GameSettingCount = 3026,
		GameSettingClearAll = 3028,

		//TimeStamps
		GameTimeStampGet = 3040, //index
		GameTimeStampSet = 3042, //index (value is from Time.Now())
		GameTimeStampAdd = 3044, //index, value
		GameTimeStampCount = 3046,
		GameTimeStampClearAll = 3048,

		//Counts
		GameCountsGet = 3060,
		GameCountsSet = 3062,
		GameCountsAdd = 3064,
		GameCountsCount = 3066,
		GameCountsClearAll = 3068,

		//Globals
		GameGlobalGet = 3080,
		GameGlobalSet = 3082,
		GameGlobalAdd = 3084,
		GameGlobalCount = 3086,
		GameGlobalFill = 3088,
		GameGlobalClearAll = 3090
	};

	int SettingScriptProcessor::Id()
	{
		return (int)DataType::ScriptProcessor::GameAdminSettings;
	}

	bool SettingScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
	{
		//common lh/rh values
		int lvalue = 0;
		int rvalue = 0;
		int ovalue = 0;

		//determine action
		switch ((GameSettingCommandCode)code)
		{
			//Audits
		case GameSettingCommandCode::GameAuditGet:
			result = Get(AuditService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameAuditSet:
			Set(AuditService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameAuditAdd:
			result = Increment(AuditService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameAuditCount:
			result = AuditService::Instance()->Count();
			break;
		case GameSettingCommandCode::GameAuditClearAll:
			AuditService::Instance()->ClearAll();
			break;

			//Settings
		case GameSettingCommandCode::GameSettingGet:
			result = Get(SettingService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameSettingSet:
			Set(SettingService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameSettingAdd:
			result = Increment(SettingService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameSettingCount:
			result = SettingService::Instance()->Count();
			break;
		case GameSettingCommandCode::GameSettingClearAll:
			SettingService::Instance()->ClearAll();
			break;

			//TimeStamps
		case GameSettingCommandCode::GameTimeStampGet:
			result = Get(TimeStampService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameTimeStampSet:
			Set(TimeStampService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameTimeStampAdd:
			result = Increment(TimeStampService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameTimeStampCount:
			result = TimeStampService::Instance()->Count();
			break;
		case GameSettingCommandCode::GameTimeStampClearAll:
			TimeStampService::Instance()->ClearAll();
			break;

			//Counts
		case GameSettingCommandCode::GameCountsGet:
			result = Get(CountsService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameCountsSet:
			Set(CountsService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameCountsAdd:
			result = Increment(CountsService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameCountsCount:
			result = CountsService::Instance()->Count();
			break;
		case GameSettingCommandCode::GameCountsClearAll:
			CountsService::Instance()->ClearAll();
			break;

			//Globals
		case GameSettingCommandCode::GameGlobalGet:
			result = Get(GlobalSettingService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameGlobalSet:
			Set(GlobalSettingService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameGlobalAdd:
			result = Increment(GlobalSettingService::Instance(), stream);
			break;
		case GameSettingCommandCode::GameGlobalCount:
			result = GlobalSettingService::Instance()->Count();
			break;
		case GameSettingCommandCode::GameGlobalFill:
		{
			lvalue = stream->ReadInt32(); //# of settings

			//local reference to instance
			auto globalSvc = GlobalSettingService::Instance();
			globalSvc->ClearAll();
			globalSvc->Fill(lvalue);

			//add defaults
			lvalue = stream->ReadInt32(); //# of defaults
			while (lvalue-- > 0)
			{
				rvalue = stream->ReadInt32(); //index
				ovalue = stream->ReadInt32(); //value
				globalSvc->Set(rvalue, ovalue);
			}
			break;
		}
		case GameSettingCommandCode::GameGlobalClearAll:
			GlobalSettingService::Instance()->ClearAll();
			break;

		default:
			return false;
		}

		//default return
		return true;
	}

	int SettingScriptProcessor::Get(GameSetting* providor, BinaryReader* stream)
	{
		int index = stream->ReadInt32();
		return providor->Get(index);
	}

	void SettingScriptProcessor::Set(GameSetting* providor, BinaryReader* stream)
	{
		int index = stream->ReadInt32();
		int value = stream->ReadInt32();
		providor->Set(index, value);
	}

	int SettingScriptProcessor::Increment(GameSetting* providor, BinaryReader* stream)
	{
		int index = stream->ReadInt32();
		int value = stream->ReadInt32();
		return providor->Add(index, value);
	}
}