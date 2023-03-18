using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.Report
{
	public class ReportMove
	{
		public int MoveNumber { get; set; }

		public MoveType Player { get; set; } = MoveType.WHITE;

		public int PlyDepth
		{ get { return ((MoveNumber - 1) * 2) + 1 + (int)Player; } }

		public string Move { get; set; } = String.Empty;

		public string BestMove { get; set; } = String.Empty;

		//this is specified as best move could be aligned with a check ,giving a different notation
		public bool IsBestMove { get; set; } = false;

		public string Engine { get; set; } = String.Empty;
	}
}
