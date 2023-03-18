using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Board
{
	public enum LevelPositionMask : int
	{
		//Center Spots
		LEVEL_0_CTR = Positions.L0R1C1 | Positions.L0R1C2 | Positions.L0R2C1 | Positions.L0R2C2,
		LEVEL_1_CTR = Positions.L1R1C1,

		//Rim Spots that are not corners
		LEVEL_0_RIM = Positions.L0R0C1 | Positions.L0R0C2 | Positions.L0R1C0 | Positions.L0R1C3 | Positions.L0R2C0 | Positions.L0R2C3 | Positions.L0R3C1 | Positions.L0R3C2,
		LEVEL_1_RIM = Positions.L1R0C1 | Positions.L1R1C0 | Positions.L1R1C2 | Positions.L1R2C1,

		//Corner Spots
		LEVEL_0_CNR = Positions.L0R0C0 | Positions.L0R0C3 | Positions.L0R3C0 | Positions.L0R3C3,
		LEVEL_1_CNR = Positions.L1R0C0 | Positions.L1R0C2 | Positions.L1R2C0 | Positions.L1R2C2
	}
}
