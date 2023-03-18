using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Cord
	{
		[FieldOffset(0)]
		public uint RAW;

		[FieldOffset(0)]
		public ushort YPosition;

		[FieldOffset(2)]
		public ushort XPosition;
	}
}
