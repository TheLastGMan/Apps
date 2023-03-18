#pragma once
#include "ISettingProvider.h"
#include "BasicCollection.h"

using namespace DataType;

namespace GameAdmin
{
	class GameSetting : public ISettingProvider
	{
	private:
		BasicCollection<int> _Values = BasicCollection<int>();
		string _Name = "N/A";
	public:
		GameSetting(string name);
		~GameSetting() { Dispose(); }
		string Name() { return _Name; }

		//basic operations
		int Get(int index);
		void Set(int index, int value);
		int Add(int index, int value);
		int AddNew(int value);
		void AddLast(int value);
		int Count();
		void ClearAll();
		void Dispose();
	};
}