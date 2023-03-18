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
	public enum LevelMask : int
	{
		ALL = LEVEL_0 | LEVEL_1 | LEVEL_2 | LEVEL_3,
		LEVEL_0 = 0x0000FFFF,
		LEVEL_1 = 0x01FF0000,
		LEVEL_2 = 0x1E000000,
		LEVEL_3 = Positions.L3R0C0
	}
}
