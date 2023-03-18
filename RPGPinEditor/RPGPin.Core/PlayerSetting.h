#pragma once
#include <string>
#include "GameSetting.h"

using namespace std;
using namespace GameAdmin;

namespace GameService
{
	class PlayerSetting : public GameSetting
	{
	public:
		PlayerSetting(int index, int settingCount);
	};
}