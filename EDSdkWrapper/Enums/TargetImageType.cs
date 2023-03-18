using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum TargetImageType : int
	{
		Unknown = 0,
		Jpeg = 1,
		TIFF = 7,
		TIFF16 = 8,
		RGB = 9,
		RGB16 = 10,
	}
}
