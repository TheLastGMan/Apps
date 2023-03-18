using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum StateEvent : int
	{
		All = 0x300,
		Shutdown = 0x301,
		JobStatusChanged = 0x302,
		WillSoonShutdown = 0x303,
		ShutdownTimerUpdated = 0x304,
		CaptureError = 0x305,
		InternalError = 0x306,
		AfResult = 0x309,
		BulbExposureTime = 0x310
	}
}
