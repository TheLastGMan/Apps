using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	[Flags]
	public enum Bracket : int
	{
		Unknown	= -1,
		None	= 0,
		AE		= 1,
		ISO		= 2,
		WB		= 4,
		FE		= 8,
	}
}
