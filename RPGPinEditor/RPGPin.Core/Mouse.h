#pragma once
#include "IMouseListener.h"
#include "BasicCollection.h"
#include <memory>

using namespace DataType;

namespace HAL
{
	namespace IO
	{
		class Mouse
		{
		private:
			Mouse() {}
			static unique_ptr<IMouseListener> _Provider;
			static BasicCollection<MouseData> _Events;
			static string _Name;
		public:
			static void Provide(IMouseListener* provider);
			static IMouseListener* Retrieve();
			static bool AddEvent(MouseData data);
			static void ProcessEvents();
			static void ClearEvents();
		};
	}
}