using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct ImageInfo
	{
		public uint Width;                  // image width 
		public uint Height;                 // image height

		public uint NumOfComponents;        // number of color components in image.
		public uint ComponentDepth;         // bits per sample.  8 or 16.

		public Rect EffectiveRect;       // Effective rectangles except 
											// a black line of the image. 
											// A black line might be in the top and bottom
											// of the thumbnail image. 

		public uint reserved1;
		public uint reserved2;
	}
}
