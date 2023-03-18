using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	[Flags]
	public enum FileAttribute : int
	{
		Normal = 0,
		ReadOnly = 1,
		Hidden = 2,
		System = 4,
		Archive = 32,
	}
}
