#pragma once
#include "KeyData.h"

namespace HAL
{
	namespace IO
	{
		class IKeyBoardListener
		{
		public:
			virtual int Id() { return -1; }
			virtual void KeyBoardAction(KeyData action) {}
		};
	}
}