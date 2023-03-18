using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Time
	{
		public int Year;
		public Month Month;
		public int Day;
		public int Hour;
		public int Minute;
		public int Second;
		public int Milliseconds;
	}
}
