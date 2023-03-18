using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.Analysis
{
	public class PositionInfo
	{
		public string Notation { get; set; } = String.Empty;
		public string Value { get; set; } = "0";
	}
}
