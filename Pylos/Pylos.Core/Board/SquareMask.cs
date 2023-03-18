using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Board
{
	public enum SquareMask : int
	{
		LEVEL_0 = 0x000033, //11 times shift left, ignore iterations 4 and 8
		LEVEL_1 = 0x1B0000, //5 times shift left, ignore iteration 3
		LEVEL_2 = LevelMask.LEVEL_2
	}
}
