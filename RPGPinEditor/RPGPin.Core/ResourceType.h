#pragma once

namespace Resource
{
	enum class ResourceType : int
	{
		SCRIPT = 0x01,
		AUDIO = 0x02,
		VIDEO = 0x04,
		GRAPHIC = 0x08,
		ANIMATION = 0x10,
		MODE = 0x20,

		ADMIN = 0x2000, //?
		PLAYER = 0x4000, //?

		SYSTEM = 0x100000, //Custom Editor
		GAME = 0x200000, //Game Folder
		UNK = -1
	};
}