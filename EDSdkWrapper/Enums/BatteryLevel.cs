using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum BatteryLevel : int
	{
		AC		= -1,
		Empty	= 1,
		Low		= 30,
		Half	= 50,
		Normal	= 80
	}
}
