using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum PictureStyle : int
	{
		Standard     = 0x81,
        Portrait     = 0x82,
        Landscape    = 0x83,
        Neutral      = 0x84,
        Faithful     = 0x85,
        Monochrome   = 0x86,
        Auto         = 0x87,
        FineDetail   = 0x88,
        User1        = 0x21,
        User2        = 0x22,
        User3        = 0x23,
        PC1          = 0x41,
        PC2          = 0x42,
        PC3          = 0x43
	}
}
