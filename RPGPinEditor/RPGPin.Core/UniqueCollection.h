#pragma once
#include "BasicCollection.h"

namespace DataType
{
	template<typename T>
	class UniqueCollection : public BasicCollection<T>
	{
	public:
		bool Add(T value, Predicate2(IEqualityComparer, T o1, T o2));
		bool Delete(T value, Predicate2(IEqualityComparer, T o1, T o2));
	};

	template<typename T>
	bool UniqueCollection<T>::Add(T value, Predicate2(IEqualityComparer, T o1, T o2))
	{
		//check for a match, don't add if we already have one
		for each(auto itm in _Values)
			if (IEqualityComparer(itm, value))
				return false;

		//add item
		return BasicCollection<T>::Add(value);
	}

	template<typename T>
	bool UniqueCollection<T>::Delete(T value, Predicate2(IEqualityComparer, T o1, T o2))
	{
		for(auto itm = _Values.begin(); itm != _Values.end(); itm++)
			if (IEqualityComparer(*itm, value))
			{
				_Values.erase(itm);
				return true;
			}

		return false;
	}
}