using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Camera
{
	public enum Metering : int
	{
		Invalid = -1,
		Spot = 1,
		Evaluative = 3,
		Partial = 4,
		Center_Weighted_Average = 5
	}
}
