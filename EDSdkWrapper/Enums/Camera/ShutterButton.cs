using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Camera
{
	[Flags]
	public enum ShutterButton : int
	{
		OFF				= 0,
		No_AutoFocus	= 0x10000,
		Halfway			= 0x00001,
		Completely		= 0x00010
	}
}
