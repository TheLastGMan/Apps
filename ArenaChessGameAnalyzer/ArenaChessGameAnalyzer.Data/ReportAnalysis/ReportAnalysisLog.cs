using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.ReportAnalysis
{
	public class ReportAnalysisLog
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime FinishedAt { get; set; } = DateTime.Now;
		public TimeSpan TotalTime
		{ get { return FinishedAt.Subtract(CreatedAt); } }

		public bool HasWhiteMoves
		{ get { return Moves.Any(f => f.Player == MoveType.WHITE); } }
		public bool HasBlackMoves
		{ get { return Moves.Any(f => f.Player == MoveType.BLACK); } }

		public string Comment { get; set; } = String.Empty;
		public List<ReportAnalysisMove> Moves { get; set; } = new List<ReportAnalysisMove>(256);
	}
}
