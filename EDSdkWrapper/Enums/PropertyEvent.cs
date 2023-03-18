using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum PropertyEvent : int
	{
		All = 0x100,
		Changed = 0x101,
		DescriptionChanged = 0x102
	}
}
