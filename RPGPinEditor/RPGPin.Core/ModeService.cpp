#include "ModeService.h"
#include "ScriptService.h"
#include "ResourceService.h"

namespace GameService
{
	string ModeService::_Name = "ModeService: ";
	unique_ptr<ModeService> ModeService::_Instance = unique_ptr<ModeService>(new ModeService());
	BasicCollection<Mode> ModeService::_Modes = BasicCollection<Mode>();

	ModeService* ModeService::Instance()
	{
		return _Instance.get();
	}

	//methods
	void ModeService::StartMode(int modeId)
	{
		//mode template
		Mode mode = Mode(modeId);

		//load resource
		unique_ptr<BinaryReader> stream(Resource::ResourceService::Load(Resource::ResourceType::MODE, modeId));
		mode.StartingScriptId = stream->ReadInt32();
		mode.EndingScriptId = stream->ReadInt32();

		//variables
		int count = stream->ReadInt32();
		while (count-- > 0)
			mode.Variables.AddNew(0);

		//variable defaults
		count = stream->ReadInt32();
		while (count-- > 0)
		{
			int index = stream->ReadInt32();
			int value = stream->ReadInt32();
			mode.Variables.Set(index, value);
		}

		//key maps
		count = stream->ReadInt32();
		while (count-- > 0)
		{
			//key
			ModeKeyMap map;
			map.KeyId = stream->ReadInt32();

			//down
			map.KeyDownScriptId = stream->ReadInt32();
			map.KeyDownInhibit = stream->ReadBoolean();

			//held
			map.KeyHeldScriptId = stream->ReadInt32();
			map.KeyHeldInhibit = stream->ReadBoolean();

			//up
			map.KeyUpScriptId = stream->ReadInt32();
			map.KeyUpInhibit = stream->ReadBoolean();
			stream->ReadByte(); //spacer to align end boundary on divisor of 4

			//add mapping
			mode.KeyMap.Add(map);
		}

		//start mode
		ScriptService::ProcessScript(mode.StartingScriptId, ParameterBlock(), &mode);
		_Modes.Add(mode);
	}

	void ModeService::EndLastMode()
	{
		_Modes.rbegin()->MarkedForDelete = true;
	}

	void ModeService::EndLastSpecificMode(int modeId)
	{
		for (auto it = _Modes.rbegin(); it != _Modes.rend(); it++)
			if (it->ModeId() == modeId)
			{
				it->MarkedForDelete = true;
				break;
			}
	}

	void ModeService::EndAllSpecificMode(int modeId)
	{
		for each(auto mode in _Modes)
			if (mode.ModeId() == modeId)
				mode.MarkedForDelete = true;
	}

	int ModeService::Count()
	{
		return _Modes.Count();
	}

	ModeKeyMap* ModeService::findKeyMap(Mode& mode, int keyId)
	{
		//search for a key map
		for (auto map : mode.KeyMap)
			if (map.KeyId == keyId)
				return &map;

		//default value
		return null;
	}

	//override
	void ModeService::KeyBoardAction(KeyData action)
	{
		//go top down
		for (int i = _Modes.Count() - 1; i >= 0; i--)
		{
			//local mode
			Mode mode = _Modes[i];

			//check for delete
			if (mode.MarkedForDelete)
			{
				//call mode end script
				ScriptService::ProcessScript(mode.StartingScriptId, ParameterBlock(), &mode);

				//remove
				_Modes.DeleteAt(i);
				continue;
			}

			//defaults
			bool stop = false;
			ModeKeyMap *data = findKeyMap(mode, action.Id);

			//apply action if found and start script in a new task
			if (data != null)
			{
				switch (action.Action)
				{
				case KeyAction::KeyDown:
					stop = data->KeyDownInhibit;

					break;
				case KeyAction::KeyHeld:
					stop = data->KeyHeldInhibit;

					break;
				case KeyAction::KeyUp:
					stop = data->KeyUpInhibit;

					break;
				}
			}

			//check for stop
			if (stop)
				break;
		}
	}
}