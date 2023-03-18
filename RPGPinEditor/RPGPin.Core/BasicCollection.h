#pragma once
#include <vector>
#include "ArgumentOutOfRangeException.h"

using namespace std;
using namespace System;

namespace DataType
{
	template<typename T>
	class BasicCollection
	{
	private:
		const string _IndexStr = string("Index");
	protected:
		vector<T> _Values = vector<T>(0);
	public:
		~BasicCollection<T>() { Clear(); }
		virtual bool Add(T value);
		void AddRange(BasicCollection values);
		bool Any() { return !_Values.empty(); };
		void Clear();
		int Count();
		bool Delete(T value);
		void DeleteAt(int index);
		void Update(int index, T value);
		T Pop();
		T Last();
		T Dequeue();
		T First();
		T ValueAt(int index);

		//Operators
		T operator[](int index);

		//Forward Iterator
		typedef typename vector<T>::iterator iterator;
		typedef typename vector<T>::const_iterator const_iterator;
		iterator begin() { return _Values.begin(); }
		iterator end() { return _Values.end(); }
		const_iterator begin() const { return _Values.begin(); }
		const_iterator end() const { return _Values.end(); }

		//Reverse Iterator
		typedef typename vector<T>::reverse_iterator riterator;
		typedef typename vector<T>::const_reverse_iterator rconst_iterator;
		riterator rbegin() { return _Values.rbegin(); }
		riterator rend() { return _Values.rend(); }
		rconst_iterator rbegin() const { return _Values.rbegin(); }
		rconst_iterator rend() const { return _Values.rend(); }
	};

	template<typename T>
	bool BasicCollection<T>::Add(T value)
	{
		_Values.push_back(value);
		return true;
	}

	template<typename T>
	void BasicCollection<T>::AddRange(BasicCollection values)
	{
		for (auto it = values.begin(); it != values.end(); it++)
			Add(*it);
	}

	template<typename T>
	void BasicCollection<T>::Clear()
	{
		_Values.clear();
	}

	template<typename T>
	int BasicCollection<T>::Count()
	{
		return _Values.size();
	}

	template<typename T>
	bool BasicCollection<T>::Delete(T value)
	{
		bool removed = false;
		for (auto it = _Values.begin(); it != _Values.end(); it++)
		{
			if ((*it) == value)
			{
				_Values.erase(it);
				removed = true;
			}
		}
		return removed;
	}

	template<typename T>
	void BasicCollection<T>::DeleteAt(int index)
	{
		//validate
		if (index < 0 || index >= Count())
			throw new ArgumentOutOfRangeException(_IndexStr);

		//load iterator index
		auto it = _Values.begin();
		it += index;

		//delete
		_Values.erase(it);
	}

	template<typename T>
	T BasicCollection<T>::operator[](int index)
	{
		//validate
		if (index < 0 || index >= Count())
			throw new ArgumentOutOfRangeException(_IndexStr);

		//get value
		return _Values[index];
	}

	template<typename T>
	T BasicCollection<T>::ValueAt(int index)
	{
		return operator[](index);
	}

	template<typename T>
	void BasicCollection<T>::Update(int index, T value)
	{
		//validate
		if (index < 0 || index >= Count())
			throw new ArgumentOutOfRangeException(_IndexStr);

		//update value
		_Values[index] = value;
	}

	template<typename T>
	T BasicCollection<T>::Pop()
	{
		auto last = _Values.back();
		_Values.pop_back();
		return last;
	}

	template<typename T>
	T BasicCollection<T>::First()
	{
		return _Values.front();
	}

	template<typename T>
	T BasicCollection<T>::Dequeue()
	{
		auto first = _Values.front();
		_Values.erase(_Values.begin());
		return first;
	}

	template<typename T>
	T BasicCollection<T>::Last()
	{
		return _Values.back();
	}
}