using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.Analysis
{
	public class AnalysisLog
	{
		public AnalysisType AnalysisType { get; set; } = AnalysisType.BOTH;

		public string Description { get; set; } = String.Empty;

		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public List<string> Engines { get; set; } = new List<string>(4);

		public List<MoveInfo> BestMoves { get; set; } = new List<MoveInfo>(256);
	}
}
