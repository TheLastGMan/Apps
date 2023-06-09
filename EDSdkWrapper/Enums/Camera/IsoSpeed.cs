﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Camera
{
	public enum IsoSpeed : int
	{
		Invalid = -1,
		ISO_Auto = 0x00,
		ISO_50 = 0x40,
		ISO_100 = 0x48,
		ISO_125 = 0x4b,
		ISO_160 = 0x4d,
		ISO_200 = 0x50,
		ISO_250 = 0x53,
		ISO_320 = 0x55,
		ISO_400 = 0x58,
		ISO_500 = 0x5b,
		ISO_640 = 0x5d,
		ISO_800 = 0x60,
		ISO_1000 = 0x63,
		ISO_1250 = 0x65,
		ISO_1600 = 0x68,
		ISO_2000 = 0x6b,
		ISO_2500 = 0x6d,
		ISO_3200 = 0x70,
		ISO_4000 = 0x73,
		ISO_5000 = 0x75,
		ISO_6400 = 0x78,
		ISO_8000 = 0x7b,
		ISO_10000 = 0x7d,
		ISO_12800 = 0x80,
		ISO_25600 = 0x88,
		ISO_51200 = 0x90,
		ISO_102400 = 0x98
	}
}
