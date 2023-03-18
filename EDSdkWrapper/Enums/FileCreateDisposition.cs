using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum FileCreateDisposition : int
	{
		CreateNew,
		CreateAlways,
		OpenExisting,
		OpenAlways,
		TruncateExsisting,
	}
}
