using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	[Flags]
	public enum ImageFormat : int
	{
		Unknown		= 0,
		Jpeg		= 1,
		CRW			= 2,
		RAW			= 4,
		CR2			= 6
	}
}
