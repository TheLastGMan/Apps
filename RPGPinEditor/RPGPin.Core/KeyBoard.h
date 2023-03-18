#pragma once
#include "IKeyBoardListener.h"
#include "BasicCollection.h"
#include <memory>
#include <string>

using namespace std;
using namespace DataType;

namespace HAL
{
	namespace IO
	{
		class KeyBoard
		{
		private:
			KeyBoard() {}
			static unique_ptr<IKeyBoardListener> _Provider;
			static BasicCollection<KeyData> _Events;
			static string _Name;
		public:
			static void Provide(IKeyBoardListener* provider);
			static IKeyBoardListener* Retrieve();
			static bool AddEvent(KeyData data);
			static void ProcessEvents();
			static void ClearEvents();
		};
	}
}