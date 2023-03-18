using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum WhiteBalance : int
	{
		Click		= -1,
		Auto		= 0,
		Daylight	= 1,
		Cloudy		= 2,
		Tungsten	= 3,
		Flourescent	= 4,
		Strobe		= 5,
		WhitePaper	= 6,
		Shade		= 8,
		ColorTemp	= 9,
		PCSet1		= 10,
		PCSet2		= 11,
		PCSet3		= 12
	}
}
