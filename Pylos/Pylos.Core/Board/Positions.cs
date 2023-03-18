using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Board
{
	[Flags]
	public enum Positions : int
	{
		//Level 0
		L0R0C0 = 0x00000001,
		L0R0C1 = 0x00000002,
		L0R0C2 = 0x00000004,
		L0R0C3 = 0x00000008,
		L0R1C0 = 0x00000010,
		L0R1C1 = 0x00000020,
		L0R1C2 = 0x00000040,
		L0R1C3 = 0x00000080,
		L0R2C0 = 0x00000100,
		L0R2C1 = 0x00000200,
		L0R2C2 = 0x00000400,
		L0R2C3 = 0x00000800,
		L0R3C0 = 0x00001000,
		L0R3C1 = 0x00002000,
		L0R3C2 = 0x00004000,
		L0R3C3 = 0x00008000,

		//Level 1
		L1R0C0 = 0x00010000,
		L1R0C1 = 0x00020000,
		L1R0C2 = 0x00040000,
		L1R1C0 = 0x00080000,
		L1R1C1 = 0x00100000,
		L1R1C2 = 0x00200000,
		L1R2C0 = 0x00400000,
		L1R2C1 = 0x00800000,
		L1R2C2 = 0x01000000,

		//Level 2
		L2R0C0 = 0x02000000,
		L2R0C1 = 0x04000000,
		L2R1C0 = 0x08000000,
		L2R1C1 = 0x10000000,

		//Level 3
		L3R0C0 = 0x20000000,
	}
}
