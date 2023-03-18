using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Interop
{
	public enum SDKResponseComponent : byte
	{
		UNKNOWN = 0,
		CLIENT,
        LLSDK,
        HLSDK,
	}
}
