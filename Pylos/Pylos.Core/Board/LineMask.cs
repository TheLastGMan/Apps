using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Board
{
	public enum LineMask : int
	{
		LEVEL_0H = 0x0000000F,	//4 iterations, each shift left 4
		LEVEL_0V = 0x00001111,  //4 iterations, shift left 1
		LEVEL_1H = 0x00070000,  //3 iterations, each shift left 3
		LEVEL_1V = 0x00490000,  //3 iterations, shift left 1
		LEVEL_2H = 0x06000000,	//2 iterations, each shift left 2
		LEVEL_2V = 0x0A000000,	//2 iterations, shift left 1
		LEVEL_3 = Positions.L3R0C0
	}
}
