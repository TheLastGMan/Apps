using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Image
{
	public enum Orientation : int
	{
#warning Unknown Mode Usage "Orientation"
		Landscape,
		Portrait90CW, //default?
		Landscape180,
		Portrait270CW
	}
}
