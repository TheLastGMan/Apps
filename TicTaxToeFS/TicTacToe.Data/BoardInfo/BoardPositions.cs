using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Data.BoardInfo
{
	[Flags]
	public enum BoardPositions : int
	{
		UPR_L = 0x100,
		UPR_C = 0x080,
		UPR_R = 0x040,
		MID_L = 0x020,
		MID_C = 0x010,
		MID_R = 0x008,
		LOW_L = 0x004,
		LOW_C = 0x002,
		LOW_R = 0x001,
		NONE = 0
	}
}
