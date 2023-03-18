#pragma once
#include "MouseData.h"

namespace HAL
{
	namespace IO
	{
		class IMouseListener
		{
		public:
			virtual int Id() { return -1; }
			virtual void MouseAction(MouseData action) {}
		};
	}
}