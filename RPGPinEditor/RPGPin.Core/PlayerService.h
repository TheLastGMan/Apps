#pragma once
#include <memory>
#include <string>
#include "Types.h"
#include "PlayerSetting.h"
#include "BasicCollection.h"

using namespace std;
using namespace DataType;

namespace GameService
{
	class PlayerService
	{
	private:
		PlayerService() {};
		static BasicCollection<PlayerSetting*> _Players;
		static string _Name;
	public:
		static byte Add(int settingCount);
		static void Remove();
		static int Count();
		static PlayerSetting* Player(int index);
		static void Clear();
	};
}