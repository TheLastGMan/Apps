using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	[Flags]
	public enum Access : int
	{
		Unknown = 0,
		Read = 1,
		Write = 2
	}
}
