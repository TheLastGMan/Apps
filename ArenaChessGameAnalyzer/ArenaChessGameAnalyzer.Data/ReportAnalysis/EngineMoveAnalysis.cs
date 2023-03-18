using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.ReportAnalysis
{
	public class EngineMoveAnalysis
	{
		public int PlyDepth { get; set; }
		public MoveType Player { get; set; }

		public string FriendlyMoveNotation { get; set; } = String.Empty;
		public string FriendlyBestMoveNotation { get; set; } = String.Empty;

		public string EngineMoveNotation { get; set; } = String.Empty;
		public string EngineBestMoveNotation { get; set; } = String.Empty;
		public string EngineBestMoveValue { get; set; } = String.Empty;

		public bool IsBestMove { get; set; }
		public string BestContinuation { get; set; } = String.Empty;
		public string Variant { get; set; } = String.Empty;
		public string Comment { get; set; } = String.Empty;
		public string Depth { get; set; } = String.Empty;
		public string PrettyEval { get; set; } = String.Empty;
		public string BestPrettyEval { get; set; } = String.Empty;

		public EngineMoveType MoveClassification { get; set; } = EngineMoveType.UNKNOWN;
		public decimal BestMoveDifference { get; set; }
	}
}
