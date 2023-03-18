#include "Random.h"
#include "TimeService.h"
#include "ArgumentNullException.h"
#include "ArgumentOutOfRangeException.h"
#include "ResourceStrings.h"
#include <cstdlib>

using namespace System;

namespace HAL
{
	Random::Random() : Random(TimeService::Retrieve()->Now())
	{
	}

	//Modified from MSDN C# Code Reference
	//https://referencesource.microsoft.com/#mscorlib/system/random.cs
	Random::Random(int seed)
	{
		int ii;
		int mj, mk;

		//Initialize our Seed array.
		//This algorithm comes from Numerical Recipes in C (2nd Ed.)
		int subtraction = (seed == Int32MinValue) ? Int32MaxValue : abs(seed);
		mj = _MSEED - subtraction;
		_SeedArray[55] = mj;
		mk = 1;
		for (int i = 1; i<55; i++) {  //Apparently the range [1..55] is special (Knuth) and so we're wasting the 0'th position.
			ii = (21 * i) % 55;
			_SeedArray[ii] = mk;
			mk = mj - mk;
			if (mk<0) mk += Int32MaxValue;
			mj = _SeedArray[ii];
		}
		for (int k = 1; k<5; k++) {
			for (int i = 1; i<56; i++) {
				_SeedArray[i] -= _SeedArray[1 + (i + 30) % 55];
				if (_SeedArray[i]<0) _SeedArray[i] += Int32MaxValue;
			}
		}
		_INext = 0;
		_INextP = 21;
	}

	double Random::sampleForLargeRange()
	{
		// The distribution of double value returned by Sample
		// is not distributed well enough for a large range.
		// If we use Sample for a range [Int32.MinValue..Int32.MaxValue)
		// We will end up getting even numbers only.

		int result = Next();
		// Note we can't use addition here. The distribution will be bad if we do that.
		bool negative = (Next() & 1) ? false : true;  // decide the sign based on second sample
		if (negative) {
			result = -result;
		}
		double d = result;
		d += (Int32MaxValue - 1); // get a number in range [0 .. 2 * Int32.MaxValue - 1)
		d /= 2 * (uint)(Int32MaxValue - 1); //
		return d;
	}

	int Random::Id()
	{
		return 0;
	}

	int Random::Next()
	{
		int locINext = _INext;
		int locINextp = _INextP;

		if (++locINext >= 56)
			locINext = 1;
		if (++locINextp >= 56)
			locINextp = 1;

		int retVal = _SeedArray[locINext] - _SeedArray[locINextp];

		if (retVal == Int32MaxValue)
			retVal -= 1;
		if (retVal < 0)
			retVal += Int32MaxValue;

		_SeedArray[locINext] = retVal;

		_INext = locINext;
		_INextP = locINextp;

		return retVal;
	}

	int Random::Next(int maxValueExclusive)
	{
		if (maxValueExclusive < 0)
			throw new ArgumentOutOfRangeException("maxValue", ResourceString::ArgumentOutOfRange_NeedPosNum);

		return (int)(NextDouble()*maxValueExclusive);
	}

	int Random::Next(int minValueInclusive, int maxValueExclusive)
	{
		if (minValueInclusive > maxValueExclusive)
			throw new ArgumentOutOfRangeException("minValue", ResourceString::Argument_MinMaxValue);

		long range = (long)maxValueExclusive - minValueInclusive;
		if (range <= (long)Int32MaxValue)
			return ((int)(NextDouble() * range) + minValueInclusive);
		else
			return (int)((long)(sampleForLargeRange() * range) + minValueInclusive);
	}

	void Random::NextBytes(byte buffer[], int size)
	{
		if (buffer == null)
			throw new ArgumentNullException("buffer");

		for (int i = 0; i < size; i++) {
			buffer[i] = (byte)(Next() % 256); //Byte.MaxValue + 1
		}
	}

	double Random::NextDouble()
	{
		return (Next() * (1.0 / Int32MaxValue));
	}
}