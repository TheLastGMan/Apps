using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Board
{
	public enum PositionOffsets : int
	{
		//Offsets
		LEVEL_0_OFFSET = Positions.L0R0C0,
		LEVEL_1_OFFSET = Positions.L1R0C0,
		LEVEL_2_OFFSET = Positions.L2R0C0,
		LEVEL_3_OFFSET = Positions.L3R0C0,
		LEVEL_ALL_OFFSET = LEVEL_3_OFFSET << 1,

		//Row Sizes
		LEVEL_0_SIZE = 4,
		LEVEL_1_SIZE = 3,
		LEVEL_2_SIZE = 2,
		LEVEL_3_SIZE = 1
	}
}
