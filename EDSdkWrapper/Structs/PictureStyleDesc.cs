using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Enums.Image;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct PictureStyleDesc
	{
		public Scaling Contrast;
		public Sharpness Sharpness;
		public Scaling Saturation;
		public Scaling ColorTone;
		public FilterEffect FilterEffect;
		public ToningEffect ToningEffect;
		public uint SharpFineness;
		public uint SharpThreshold;
	}
}
