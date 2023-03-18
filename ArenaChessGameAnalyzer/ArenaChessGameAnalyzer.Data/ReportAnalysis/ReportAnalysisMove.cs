using ArenaChessGameAnalyzer.Data.Report;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.ReportAnalysis
{
	public class ReportAnalysisMove : ReportMove
	{
		public ReportAnalysisMove()
		{
		}

		public ReportAnalysisMove(ReportMove move)
		{
			//my properties
			var myProps = this.GetType().GetProperties().ToList();

			//map properties
			foreach (var prop in move.GetType().GetProperties())
			{
				var myProp = myProps.FirstOrDefault(f => f.Name.Equals(prop.Name));
				if (myProp != null)
				{
					try
					{
						//update ours with the input
						myProp.SetValue(this, prop.GetValue(move, null));
					}
					catch
					{
						//do nothing if unable, don't care about those
					}
				}
			}
		}

		public string PgnMoveNotationBest { get; set; } = String.Empty;

		public string BestContinuation { get; set; } = String.Empty;

		public string Depth { get; set; } = "1";

		public string PrettyEvaluation { get; set; } = "0";
	}
}
