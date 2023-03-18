#include "GameServiceScriptProcessor.h"
#include "ScriptProcessor.h"
#include "Types.h"
#include "PlayerService.h"
#include "KeyBoard.h"
#include "Mouse.h"

using namespace HAL::IO;

namespace GameService
{
	enum class GameServiceCommandCode : int
	{
		//Player
		PlayerAdd = 4000,
		PlayerRemoveLast = 4002,
		PlayerCount = 4004,
		PlayerClearAll = 4006,

		//Player Settings
		PlayerSettingGet = 4020,
		PlayerSettingSet = 4022,
		PlayerSettingAdd = 4024,
		PlayerSettingCount = 4026,
		PlayerSettingClearAll = 4028,

		//Keyboard
		KeyboardEventAdd = 4400,
		KeyboardEventClearAll = 4402,

		//Mouse
		MouseEventAdd = 4426,
		MouseEventClearAll = 4428
	};

	int GameServiceScriptProcessor::Id()
	{
		return (int)DataType::ScriptProcessor::GameService;
	}

	bool GameServiceScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
	{
		//common lh/rh values
		int lvalue = 0;
		int rvalue = 0;
		int ovalue = 0;

		//determine action
		switch ((GameServiceCommandCode)code)
		{
			//Player
		case GameServiceCommandCode::PlayerAdd:
		{
			lvalue = stream->ReadInt32(); //# of settings
			result = PlayerService::Add(lvalue);

			//active player
			auto player = PlayerService::Player(result);

			//add defaults
			lvalue = stream->ReadInt32();
			while (lvalue-- > 0)
			{
				rvalue = stream->ReadInt32(); //default setting index
				ovalue = stream->ReadInt32(); //non-zero default value
				player->Set(rvalue, ovalue);
			}
			break;
		}
		case GameServiceCommandCode::PlayerRemoveLast:
			PlayerService::Remove();
			break;
		case GameServiceCommandCode::PlayerCount:
			result = PlayerService::Count();
			break;
		case GameServiceCommandCode::PlayerClearAll:
			PlayerService::Clear();
			break;

			//Player Settings
		case GameServiceCommandCode::PlayerSettingGet:
			lvalue = service->Process(stream); //index
			rvalue = service->Process(stream); //setting index
			PlayerService::Player(lvalue)->Get(rvalue);
			break;
		case GameServiceCommandCode::PlayerSettingSet:
			lvalue = service->Process(stream); //index
			rvalue = service->Process(stream); //setting index
			ovalue = service->Process(stream); //new value
			PlayerService::Player(lvalue)->Set(rvalue, ovalue);
			break;
		case GameServiceCommandCode::PlayerSettingAdd:
			lvalue = service->Process(stream); //index
			rvalue = service->Process(stream); //setting index
			ovalue = service->Process(stream); //new value
			result = PlayerService::Player(lvalue)->Add(rvalue, ovalue);
			break;
		case GameServiceCommandCode::PlayerSettingCount:
			lvalue = service->Process(stream);
			result = PlayerService::Player(lvalue)->Count();
			break;
		case GameServiceCommandCode::PlayerSettingClearAll:
			lvalue = service->Process(stream);
			PlayerService::Player(lvalue)->ClearAll();
			break;

			//Keyboard
		case GameServiceCommandCode::KeyboardEventAdd:
			KeyData keyData;
			keyData.Id = service->Process(stream); //id
			keyData.Action = (KeyAction)service->Process(stream); //action
			KeyBoard::AddEvent(keyData);
			break;
		case GameServiceCommandCode::KeyboardEventClearAll:
			KeyBoard::ClearEvents();
			break;

			//Mouse
		case GameServiceCommandCode::MouseEventAdd:
			MouseData mouseData;
			mouseData.Id = service->Process(stream); //id
			mouseData.Action = (MouseAction)service->Process(stream); //action
			Mouse::AddEvent(mouseData);
			break;
		case GameServiceCommandCode::MouseEventClearAll:
			Mouse::ClearEvents();
			break;

		default:
			return false;
		}

		//default return
		return true;
	}
}