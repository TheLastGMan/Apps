using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.Analysis
{
	public class BestMoveInfo : PositionInfo
	{
		public string Engine { get; set; } = String.Empty;

		public string EngineMoveNotation { get; set; } = String.Empty;

		public string Line { get; set; } = String.Empty;

		public string Depth { get; set; } = "1";

		public TimeSpan SearchTime { get; set; } = new TimeSpan(0);
	}
}
