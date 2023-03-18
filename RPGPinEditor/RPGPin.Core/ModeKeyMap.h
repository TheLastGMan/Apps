#pragma once

namespace GameService
{
	struct ModeKeyMap
	{
		//main key id
		int KeyId;

		//action script ids
		int KeyDownScriptId;
		int KeyHeldScriptId;
		int KeyUpScriptId;

		//action inhibit
		//should key event stop further processing in other modes
		bool KeyDownInhibit;
		bool KeyHeldInhibit;
		bool KeyUpInhibit;
	};
}