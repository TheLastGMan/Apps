using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Camera
{
	public enum DriveMode : int
	{
		Single_Frame = 0,
		Continous = 1,
		Video = 2,

		High_Speed_Continous = 4,
		Low_Speed_Continous = 5,
		Silent_Single_Frame = 6,
		Timer_10s_Continous = 7,
		Timer_10s = 16,
		Timer_2s = 17
	}
}
