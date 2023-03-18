using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Interop
{
	[StructLayout(LayoutKind.Explicit)]
	public struct SDKResponse
	{
		[FieldOffset(0)]
		public uint RAW;

		[FieldOffset(0)]
		public EDSDKResponseCode Code;

		[FieldOffset(2)]
		public byte Reserved;

		[FieldOffset(3)]
		private byte SpecificComponent;

		public SDKResponseComponent Component
		{
			get { return (SDKResponseComponent)(SpecificComponent & 0x3F); }
			set
			{
				SpecificComponent &= 0x80;
				SpecificComponent += (byte)value;
			}
		}

		public bool IsSpecific
		{
			get { return (SpecificComponent & 0x80) > 0; }
			set
			{
				if (value)
					SpecificComponent |= 0x80;
				else
					SpecificComponent &= 0x3F;
			}
		}
	}
}
