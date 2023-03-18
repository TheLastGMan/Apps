using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct FocusPoint
	{
		public uint valid;
		public uint selected;
		public uint justFocus;
		public Rect rect;
		public uint reserved;
	}
}
