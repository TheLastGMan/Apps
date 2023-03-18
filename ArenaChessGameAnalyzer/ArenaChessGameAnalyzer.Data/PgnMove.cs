using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data
{
	public class PgnMove
	{
		public int PlyDepth { get; set; } = 0;
		public string Notation { get; set; } = String.Empty;
	}
}
