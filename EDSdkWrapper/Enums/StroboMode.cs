using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum StroboMode : int
	{
        Internal		= 0,
        ExternalETTL	= 1,
		ExternalATTL	= 2,
        ExternalTTL		= 3,
        ExternalAuto	= 4,
        ExternalManual	= 5,
        Manual			= 6,
	}
}
