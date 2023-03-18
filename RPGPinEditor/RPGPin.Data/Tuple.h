#pragma once

namespace System
{
	template<typename T1>
	class Tuple
	{
	private:
		T1 _Item1;
	public:
		Tuple(T1 item1) { _Item1 = item1; }
		T1 Item1() { return _Item1; }
	};

	template<typename T1, typename T2>
	class Tuple2 : public Tuple<T1>
	{
	private:
		T2 _Item2;
	public:
		Tuple(T1 item1, T2 item2) : Tuple<T1>(item1)
		{
			_Item2 = item2;
		}
		T2 Item2() { return _Item2; }
	};

	template<typename T1, typename T2, typename T3>
	class Tuple3 : public Tuple2<T1, T2>
	{
	private:
		T3 _Item3;
	public:
		Tuple(T1 item1, T2 item2, T3 item3) : Tuple<T1, T2>(item1, item2)
		{
			_Item3 = item3;
		}
		T3 Item3() { return _Item3; }
	};

	template<typename T1, typename T2, typename T3, typename T4>
	class Tuple4 : public Tuple3<T1, T2, T3>
	{
	private:
		T4 _Item4;
	public:
		Tuple(T1 item1, T2 item2, T3 item3, T4 item4) : Tuple<T1, T2, T3>(item1, item2, item3)
		{
			_Item4 = item4;
		}
		T4 Item4() { return _Item4; }
	};
}