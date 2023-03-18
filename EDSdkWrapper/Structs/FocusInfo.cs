using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct FocusInfo
	{
		public Rect imageRect;
		public uint pointNumber;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public FocusPoint[] focusPoint;
		public uint executeMode;
	}
}
