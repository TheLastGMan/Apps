#pragma once
#include <memory>
#include "Types.h"

#ifndef Int32MaxValue
#define Int32MaxValue 0x7FFFFFFF
#endif

#ifndef Int32MinValue
#define Int32MinValue 0x80000000
#endif

namespace HAL
{
	class Random
	{
	private:
		const int _MSEED = 0x09A4EC86; // 161803398;
		const int _MZ = 0;
		int _INext = 0;
		int _INextP = 0;
		unique_ptr<int[]> _SeedArray = unique_ptr<int[]>(new int[56]);
		double sampleForLargeRange();
	public:
		Random();
		Random(int Seed);

		virtual int Id();
		virtual int Next();
		virtual int Next(int maxValueExclusive);
		virtual int Next(int minValueInclusive, int maxValueExclusive);
		virtual void NextBytes(byte buffer[], int size);
		virtual double NextDouble();
	};
}