using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct Capacity
	{
		public int NumberOfFreeClusters;
		public int BytesPerSector;
		public int Reset;
	}
}
