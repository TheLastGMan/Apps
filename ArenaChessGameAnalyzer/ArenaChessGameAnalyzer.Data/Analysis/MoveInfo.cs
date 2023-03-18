using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.Analysis
{
	public class MoveInfo : ICloneable
	{
		public int MoveNumber { get; set; } = 0;

		public MoveType Player { get; set; } = MoveType.WHITE;

		public string Move { get; set; } = String.Empty;

		public int PlyDepth
		{ get { return ((MoveNumber - 1) * 2) + 1 + (int)Player; } }

		public List<BestMoveInfo> BestMoves { get; set; } = new List<BestMoveInfo>();

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
