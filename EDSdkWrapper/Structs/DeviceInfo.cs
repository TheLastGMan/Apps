using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceInfo
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = BaseSizes.MAX_NAME)]
		public string szPortName;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = BaseSizes.MAX_NAME)]
		public string szDeviceDescription;

		public DeviceType DeviceSubType;

		public uint reserved;
	}
}
