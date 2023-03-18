#include "KeyBoard.h"
#include "Logger.h"

using namespace Logging;

namespace HAL
{
	namespace IO
	{
		unique_ptr<IKeyBoardListener> KeyBoard::_Provider = unique_ptr<IKeyBoardListener>(new IKeyBoardListener());
		BasicCollection<KeyData> KeyBoard::_Events = BasicCollection<KeyData>();
		string KeyBoard::_Name = "KeyBoard: ";

		void KeyBoard::Provide(IKeyBoardListener* provider)
		{
			_Provider.reset((provider != null) ? provider : new IKeyBoardListener());
			Logger::LogDebug(_Name + "Provide: " + to_string(_Provider->Id()));
		}

		IKeyBoardListener* KeyBoard::Retrieve()
		{
			//check if provider should be set
			if (_Provider.get() == null)
				Provide(null);

			//provide instance
			Logger::LogDebug(_Name + "Retrieve: " + to_string(_Provider->Id()));
			return _Provider.get();
		}

		bool KeyBoard::AddEvent(KeyData data)
		{
			Logger::LogDebug(_Name + "AddEvent: Id: " + to_string(data.Id) + " | Action: " + to_string((byte)data.Action));
			return _Events.Add(data);
		}

		void KeyBoard::ClearEvents()
		{
			_Events.Clear();
		}

		void KeyBoard::ProcessEvents()
		{
			Logger::LogDebug(_Name + "ProcessEvents");

			//pass events off to be processed
			//use a count so we limit ourselves and don't race against an add event
			int count = _Events.Count();
			while (count-- > 0)
				_Provider->KeyBoardAction(_Events.Dequeue());
		}
	}
}