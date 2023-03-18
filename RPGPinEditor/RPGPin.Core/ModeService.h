#pragma once
#include <string>
#include <memory>
#include "BasicCollection.h"
#include "Mode.h"
#include "IKeyBoardListener.h"
#include "Tuple.h"

using namespace std;
using namespace System;
using namespace DataType;
using namespace HAL::IO;

namespace GameService
{
	class ModeService : public IKeyBoardListener
	{
	private:
		static unique_ptr<ModeService> _Instance;
		static string _Name;
		static BasicCollection<Mode> _Modes;
		ModeService() {};
		static ModeKeyMap* findKeyMap(Mode& mode, int keyId);
	public:
		//instance
		static ModeService* Instance();

		//methods
		static void StartMode(int modeId);
		static void EndLastMode();
		static void EndLastSpecificMode(int modeId);
		static void EndAllSpecificMode(int modeId);
		static int Count();

		//override
		int Id() { return 1; }
		void KeyBoardAction(KeyData action);
	};
}