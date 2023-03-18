using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data
{
	public class EcoEqualityComparer : IEqualityComparer<EcoData>
	{
		public static bool AreSame(List<string> srcMoves, List<string> othrMoves)
		{
			var fstOrder = srcMoves.OrderBy(f => f.Length).ThenBy(f => f);
			var sndOrder = othrMoves.OrderBy(f => f.Length).ThenBy(f => f);
			return fstOrder.SequenceEqual(sndOrder);
		}

		public bool Equals(EcoData x, EcoData y)
		{
			return AreSame(x.Moves, y.Moves);
		}

		public int GetHashCode(EcoData obj)
		{
			return String.Join(",", obj.Moves.OrderBy(f => f.Length).ThenBy(f => f)).GetHashCode();
		}
	}
}
