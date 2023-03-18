using ArenaChessGameAnalyzer.Data.ReportAnalysis;
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
	public class ArenaAnalysisPgn
	{
		public static void SaveArenaAnalysisAsPgn(EngineAnalysisReport report, FileInfo pgnInput, FileInfo pgnOutput)
		{
			//validate
			if (report == null)
				throw new ArgumentNullException("report", "must be set");
			if (pgnInput == null)
				throw new ArgumentNullException("pgnInput", "must be set");
			if (pgnOutput == null)
				throw new ArgumentNullException("pgnOutput", "must be set");

			//create directory if one doesn't exist
			if (!Directory.Exists(pgnOutput.DirectoryName))
				Directory.CreateDirectory(pgnOutput.DirectoryName);

			//write output PGN
			var headerLines = File.ReadAllLines(pgnInput.FullName).TakeWhile(f => f.StartsWith("[")).ToList();
			using (var sw = new StreamWriter(pgnOutput.FullName))
			{
				//header
				headerLines.ForEach(line => sw.WriteLine(line));
				sw.WriteLine();

				//PGN (we do one move sequence per line)
				for (int i = 0; i < report.Moves.Count; i++)
				{
					//setup
					var move = report.Moves[i];
					int moveNumber = (move.PlyDepth / 2) + 1;

					decimal result = 0;
					string convertedValue = move.BestPrettyEval;
					if (decimal.TryParse(convertedValue, out result))
						convertedValue = result.ToString("0.00");

					//notation logic
					if (i == 0 && move.Player == Data.MoveType.BLACK)
					{
						//start offset
						sw.WriteLine($"{ moveNumber }. ... { generateAlgebraicNotation(move.FriendlyMoveNotation, move.Comment, move.BestContinuation, convertedValue, move.Depth, "0", move.Variant) }");
					}
					else if (move.Player == Data.MoveType.WHITE)
					{
						//write move number and notation
						sw.Write($"{ moveNumber }. {  generateAlgebraicNotation(move.FriendlyMoveNotation, move.Comment, move.BestContinuation, convertedValue, move.Depth, "0", move.Variant) } ");
					}
					else
					{
						//append notation with new line
						sw.WriteLine(generateAlgebraicNotation(move.FriendlyMoveNotation, move.Comment, move.BestContinuation, convertedValue, move.Depth, "0", move.Variant));
					}
				}

				//check for mate
				if (report.Moves.Last().FriendlyMoveNotation.Contains("#"))
					if (report.Moves.Last().Player == Data.MoveType.BLACK)
						sw.WriteLine("1-0");
					else
						sw.Write("0-1");

				//simulate black if we ended on white
				if (report.Moves.Last().Player == Data.MoveType.WHITE)
					sw.WriteLine();

				//trailer
				sw.WriteLine();
			}
		}

		private static string generateAlgebraicNotation(string move, string comment, string bestLine, string value, string depth, string seconds, string variant)
		{
			if (String.IsNullOrEmpty(comment))
				comment = String.Empty;
			if (String.IsNullOrEmpty(bestLine))
				bestLine = String.Empty;
			if (String.IsNullOrEmpty(value) || value == "0")
				value = "0.00";
			if (String.IsNullOrEmpty(depth))
				depth = "0";
			if (String.IsNullOrEmpty(seconds))
				seconds = "0";

			//output format selection
			string pgnCode = "";
			if (depth == "0")
				if (String.IsNullOrEmpty(comment))
					pgnCode = move;
				else
					pgnCode = $"{ move } {{{comment}}}";
			else if (String.IsNullOrEmpty(comment))
				if (String.IsNullOrEmpty(bestLine))
					pgnCode = $"{ move } {{{ value }/{ depth } { seconds }}}";
				else
					pgnCode = $"{ move } {{({ bestLine }) { value }/{ depth } { seconds }}}";
			else if (String.IsNullOrEmpty(bestLine))
				pgnCode = $"{ move } {{{comment} { value }/{ depth } { seconds }}}";
			else
				pgnCode = $"{ move } {{{comment} | Continuation: ({ bestLine }) { value }/{ depth } { seconds }}}";

			//add in variant
			if (!String.IsNullOrEmpty(variant))
				pgnCode += $" ({ variant })";

			return pgnCode;
		}
	}
}
