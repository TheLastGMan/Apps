using ArenaChessGameAnalyzer.Data;
using ArenaChessGameAnalyzer.Data.Analysis;
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
	public class ArenaAnalysisReader
	{
		public static AnalysisLog ReadLog(FileInfo analysisFile)
		{
			if (!analysisFile.Exists)
				throw new Exception("analysis file must exist");

			//read file
			var log = new AnalysisLog();
			using (var sr = new StreamReader(analysisFile.FullName))
			{
				//first line, analysis type
				AnalysisType anlsType = AnalysisType.BOTH;
				Enum.TryParse(sr.ReadLine(), true, out anlsType);
				log.AnalysisType = anlsType;

				//spacer
				sr.ReadLine();

				//description
				var descInfo = Enumerable.Range(0, 2).Select(f => sr.ReadLine());
				log.Description = String.Join(" | ", descInfo);

				//time
				string timeLine = sr.ReadLine();
				timeLine = timeLine.Substring(0, timeLine.IndexOf("Level:"));
				log.CreatedAt = DateTime.Parse(timeLine);

				//engines
				string engines = sr.ReadLine();
				engines = engines.Substring(engines.IndexOf(":") + 2);
				log.Engines = engines.Split(',').Select(f => f.Trim()).ToList();

				//best move analysis
				while (!sr.EndOfStream)
				{
					int moveNumber = -1;
					string cLine = sr.ReadLine();

					//keep reading until we reach a move number
					if (String.IsNullOrEmpty(cLine) || cLine.Contains("/") || !int.TryParse(cLine[0].ToString(), out moveNumber))
						continue;

					//setup with move number
					var move = new MoveInfo();
					move.MoveNumber = int.Parse(cLine.Substring(0, cLine.IndexOf('.'))); ;
					move.Player = cLine.Contains(". ..") ? MoveType.BLACK : MoveType.WHITE;
					move.Move = cLine.Split(' ')[1].TrimStart('.').Trim();

					//engine moves
					foreach(var e in log.Engines)
					{
						var bestMove = bestEngineMove(sr, move.Player);
						move.BestMoves.Add(bestMove);
					}

					log.BestMoves.Add(move);
				}
			}

			return log;
		}

		private static BestMoveInfo bestEngineMove(StreamReader sr, MoveType player)
		{
			var bestMove = new BestMoveInfo();

			//load section
			var lines = new List<string>();
			string line = String.Empty;
			while (!String.IsNullOrEmpty((line = sr.ReadLine())))
				lines.Add(line);

			//best move
			string[] bestMoveOutput = lines[lines.Count - 2].Split('\t').Select(f => f.Trim()).ToArray();
			bestMove.Engine = lines[0].Substring(lines[0].IndexOf('(') + 1, lines[0].IndexOf(')') - lines[0].IndexOf('(') - 1);
			bestMove.EngineMoveNotation = lines[0].Substring(lines[0].IndexOf(':') + 1).Trim();
			bestMove.Depth = bestMoveOutput[0];
			bestMove.Line = bestMoveOutput.Last();
			bestMove.SearchTime = TimeSpan.Parse("00:" + bestMoveOutput[1]);

			//load best move value, check for mate notation
			if (!bestMoveOutput[4].Contains("M"))
				//format
				bestMove.Value = decimal.Parse(bestMoveOutput[4]).ToString("0.00");
			else
				bestMove.Value = bestMoveOutput[4];

			//best move
			string[] bestMoves = bestMove.Line.Split(' ');
			if (bestMoves[0].EndsWith("."))
			{
				//black, ignore first two
				bestMove.Notation = bestMoves[2];
			}
			else
			{
				//white, take after period
				bestMove.Notation = bestMoves[0].Substring(bestMoves[0].IndexOf('.') + 1);
			}

			return bestMove;
		}
	}
}
