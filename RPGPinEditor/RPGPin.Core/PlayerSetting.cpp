#include "PlayerSetting.h"
#include "Logger.h"

using namespace Logging;

namespace GameService
{
	PlayerSetting::PlayerSetting(int index, int settingCount) : GameSetting("Player " + to_string(index + 1))
	{
		while (settingCount-- > 0)
			AddLast(0);
	}
}