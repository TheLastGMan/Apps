using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data
{
	public class EcoData : IEquatable<EcoData>
	{
		public string Code { get; set; } = String.Empty;
		public string Name { get; set; } = String.Empty;
		public List<string> Moves { get; set; } = new List<string>();

		public bool AreSame(List<string> othrMoves)
		{
			return EcoEqualityComparer.AreSame(Moves, othrMoves);
		}

		public bool Equals(EcoData other)
		{
			return Equals(this, other);
		}
	}
}
