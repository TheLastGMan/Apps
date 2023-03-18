#include "Mouse.h"
#include "Logger.h"
#include "Types.h"

using namespace Logging;

namespace HAL
{
	namespace IO
	{
		unique_ptr<IMouseListener> Mouse::_Provider = null;
		BasicCollection<MouseData> Mouse::_Events = BasicCollection<MouseData>();
		string Mouse::_Name = "Mouse: ";

		void Mouse::Provide(IMouseListener* provider)
		{
			_Provider.reset((provider != null) ? provider : new IMouseListener());
			Logger::LogDebug(_Name + "Provide: " + to_string(_Provider->Id()));
		}

		IMouseListener* Mouse::Retrieve()
		{
			//check if provider should be set
			if (_Provider.get() == null)
				Provide(null);

			//provide instance
			Logger::LogDebug(_Name + "Retrieve: " + to_string(_Provider->Id()));
			return _Provider.get();
		}

		bool Mouse::AddEvent(MouseData data)
		{
			Logger::LogDebug(_Name + "AddEvent: Id: " + to_string(data.Id) + " | Action: " + to_string((byte)data.Action));
			return _Events.Add(data);
		}

		void Mouse::ProcessEvents()
		{
			Logger::LogDebug(_Name + "ProcessEvents");

			//pass events off to be processed
			while (_Events.Any())
				_Provider->MouseAction(_Events.Dequeue());
		}

		void Mouse::ClearEvents()
		{
			_Events.Clear();
		}
	}
}