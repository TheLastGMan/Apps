using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Data.BoardInfo
{
	public enum BoardMasks : int
	{
		//Table
		TABLE = 0x1FF,

		//Directions
		ROW = BoardPositions.LOW_L | BoardPositions.LOW_C | BoardPositions.LOW_R, //only first, iterate <<= 3, 2 more times
		COL = BoardPositions.LOW_R | BoardPositions.MID_R | BoardPositions.UPR_R, //only first, iterate <<= 1, 2 more times
		DIAG_URLL = BoardPositions.UPR_R | BoardPositions.MID_C | BoardPositions.LOW_L,
		DIAG_ULLR = BoardPositions.UPR_L | BoardPositions.MID_C | BoardPositions.LOW_R,

		//Other
		UNK = 0
	}
}
