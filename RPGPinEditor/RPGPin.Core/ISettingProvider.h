#pragma once
#include "IDisposable.h"

namespace GameAdmin
{
	class ISettingProvider : public System::IDisposable
	{
	public:
		virtual int Get(int index) { return 0; }
		virtual void Set(int index, int value) {}
		virtual int Add(int index, int value) { return 0; }
		virtual int AddNew(int value) { return 0; }
		virtual int Count() { return 0; }
		virtual void Dispose() {}
	};
}