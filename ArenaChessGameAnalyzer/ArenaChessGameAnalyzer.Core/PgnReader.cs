using ArenaChessGameAnalyzer.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Core
{
	public class PgnReader
	{
		public static IList<PgnMove> LoadPgn(FileInfo pgnFile)
		{
			var pgnFileData = File.ReadAllLines(pgnFile.FullName);
			var pgnMoves = PgnReader.PgnMoves(pgnFileData);
			var pgnPlys = PgnReader.ToPlys(pgnMoves);
			return pgnPlys;
		}

		public static string PgnMoves(string[] pgnLines)
		{
			string moves = String.Join(" ", pgnLines.SkipWhile(f => f.StartsWith("[")).Skip(1).TakeWhile(f => !String.IsNullOrEmpty(f))).Replace(" ", " ");

			//replace comments
			var regx = new Regex(@"{.*?}", RegexOptions.Compiled | RegexOptions.Multiline);
			while(regx.IsMatch(moves))
			{
				var match = regx.Match(moves);
				moves = moves.Remove(match.Index, match.Length);
			}

			//find numbers with trailing dots, add space after
			moves = ReplaceMultipleSpaces(moves);

			//replace multiple spaces
			regx = new Regex(@"\s\s+", RegexOptions.Compiled | RegexOptions.Multiline);
			while (regx.IsMatch(moves))
			{
				var match = regx.Match(moves);
				moves = moves.Remove(match.Index, match.Length);
				moves = moves.Insert(match.Index, " ");
			}

			//give result
			return moves;
		}

		public static string ReplaceMultipleSpaces(string line)
		{
			//replace multiple spaces
			var regx = new Regex(@"\s\s+", RegexOptions.Compiled | RegexOptions.Multiline);
			while (regx.IsMatch(line))
			{
				var match = regx.Match(line);
				line = line.Remove(match.Index, match.Length);
				line = line.Insert(match.Index, " ");
			}
			return line;
		}

		public static IList<PgnMove> ToPlys(string pgnMoves)
		{
			string[] parts = pgnMoves.Trim().Split(' ').Select(f => f.Trim()).ToArray();
			var moves = new List<PgnMove>(parts.Length);
			int lastMoveNumber = 0;
			foreach(string m in parts)
			{
				//check for move number
				if (m.EndsWith("."))
				{
					lastMoveNumber = int.Parse(m.Substring(0, m.Length - 1));
					lastMoveNumber = ((lastMoveNumber - 1) * 2) + 1;
					continue;
				}

				if((m[0] >= 'a' && m[0] <= 'z') || (m[0] >= 'A' && m[0] <= 'Z'))
				{
					//valid move
					moves.Add(new PgnMove() { PlyDepth = lastMoveNumber, Notation = m });
					lastMoveNumber += 1;
				}
			}
			return moves;
		}

		public static LastEcoMove LastBookPly(IList<PgnMove> plys, ILookup<EcoData, EcoData> ecoCodes)
		{
			var result = new LastEcoMove();

			for (int i = 1; i <= plys.Count; i++)
			{
				var moves = new EcoData() { Moves = plys.Take(i).Select(f => f.Notation).ToList() };
				var openings = ecoCodes[moves];
				if(openings.Any())
				{
					result.LastEco = openings.First();
					result.PlyNumber = i;
				}
			}

			return result;
		}
	}
}
