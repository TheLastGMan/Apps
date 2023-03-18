using ArenaChessGameAnalyzer.Data;
using ArenaChessGameAnalyzer.Data.Report;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Core
{
	public class ArenaReportReader
	{
		public static ReportLog ReadReport(FileInfo reportFile)
		{
			if (!reportFile.Exists)
				throw new Exception("report file must exist");

			var report = new ReportLog();
			using (var sr = new StreamReader(reportFile.FullName))
			{
				//skip unused header
				Enumerable.Range(1, 5).Select(f => sr.ReadLine()).ToList();

				//date time
				string createdDate = sr.ReadLine();
				report.CreatedAt = DateTime.Parse(createdDate.Substring(0, createdDate.IndexOf("Level") - 1));

				//source
				sr.ReadLine();

				//moves in report
				string moves = sr.ReadLine();
				//report.WhiteMoves = moves.Contains("White moves=True");
				//report.BlackMoves = moves.Contains("Black moves=True");

				string cLine = String.Empty;
				while (!(cLine = sr.ReadLine()).StartsWith("   Comment ")) { };
				report.Comment = cLine.Substring(cLine.IndexOf(':') + 1).Trim();

				var movesMade = new List<string>(256);
				while (true)
				{
					cLine = sr.ReadLine();
					if (cLine.StartsWith(" "))
					{
						movesMade.Add(cLine);
						continue;
					}
					else if (cLine.IndexOf('.') > 0)
					{
						string moveNum = cLine.Substring(0, cLine.IndexOf('.')).Trim();
						int moveId = 0;
						if (int.TryParse(moveNum, out moveId))
						{
							movesMade.Add(cLine);
							continue;
						}
					}

					break;
				}

				//skip number of matching moves, load finished
				cLine = sr.ReadLine();
				report.FinishedAt = DateTime.Parse(cLine.Substring(0, cLine.IndexOf(',')));

				//map moves made to report moves
				report.Moves = mapRawReportMoves(movesMade);
			}

			return report;
		}

		private static List<ReportMove> mapRawReportMoves(IList<string> moves)
		{
			var rptMoves = new List<ReportMove>(256);
			int lastMoveNumber = 0;
			foreach (var m in moves)
			{
				//setup
				var rptMove = new ReportMove();
				var parts = m.Split(' ').Select(f => f.Trim()).Where(f => !String.IsNullOrEmpty(f)).ToList();

				//check for move number
				if (parts[0].EndsWith("."))
				{
					lastMoveNumber = int.Parse(parts[0].Substring(0, parts[0].Length - 1));
					rptMove.Player = MoveType.WHITE;
					parts.RemoveAt(0);
				}
				else
				{
					rptMove.Player = MoveType.BLACK;
				}

				rptMove.MoveNumber = lastMoveNumber;

				//check for black piece only that was attached to a move number
				if (parts[0].Contains("."))
				{
					rptMove.Player = MoveType.BLACK;
					parts.RemoveAt(0);
				}

				//moves
				rptMove.Move = parts[0];
				rptMove.BestMove = parts[1];

				//best move
				rptMove.IsBestMove = parts.Count > 2 && parts[2].Equals("*");

				//check for engine
				if (parts[parts.Count - 1].StartsWith("("))
					rptMove.Engine = parts[parts.Count - 1].Replace("(", "").Replace(")", "");

				//at move
				rptMoves.Add(rptMove);
			}
			return rptMoves;
		}
	}
}
