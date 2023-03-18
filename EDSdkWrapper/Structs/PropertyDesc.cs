using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct PropertyDesc
	{
		public int Form;
		public Access Access;
		public int NumElements;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public int[] PropDesc;
	}
}
