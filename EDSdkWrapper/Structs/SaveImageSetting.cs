using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct SaveImageSetting
	{
		public uint JPEGQuality;
		IntPtr iccProfileStream;
		public uint reserved;
	}
}
