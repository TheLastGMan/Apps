using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum TransferOption : int
	{
		ByDirectTransfer = 1,
		ByRelease = 2,
		ToDesktop = 0x100,
	}
}
