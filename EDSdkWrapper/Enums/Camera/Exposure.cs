using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Camera
{
	public enum Exposure : int
	{
		Invalid = -1,
		p3 = 0x18,
		p2_2d3 = 0x15,
		p2_1d2 = 0x14,
		p2_1d3 = 0x13,
		p2 = 0x10,
		p1_2d3 = 0x0D,
		p1_1d2 = 0x0C,
		p1_1d3 = 0x0B,
		p1 = 0x08,
		p2d3 = 0x05,
		p1d2 = 0x04,
		p1d3 = 0x03,
		Zero = 0,
		n1d3 = 0xFD,
		n1d2 = 0xFC,
		n2d3 = 0xFB,
		n1 = 0xF8,
		n1_1d3 = 0xF5,
		n1_1d2 = 0xF4,
		n1_2d3 = 0xF3,
		n2 = 0xF0,
		n2_1d3 = 0xED,
		n2_1d2 = 0xEC,
		n2_2d3 = 0xEB,
		n3 = 0xE8
	}
}
