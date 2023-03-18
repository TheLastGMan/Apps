using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.Analysis
{
	public class EngineInfo
	{
		public string Name { get; set; } = String.Empty;
		public List<MoveInfo> Moves { get; set; } = new List<MoveInfo>(128);
	}
}
