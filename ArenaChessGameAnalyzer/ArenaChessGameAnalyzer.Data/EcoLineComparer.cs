using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data
{
	public class EcoLineComparer : IEqualityComparer<EcoData>
	{
		public bool Equals(EcoData x, EcoData y)
		{
			return x.Moves.SequenceEqual(y.Moves);
		}

		public int GetHashCode(EcoData obj)
		{
			return String.Join(" ", obj.Moves).GetHashCode();
		}
	}
}
