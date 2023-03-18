using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data.ReportAnalysis
{
	public enum EngineMoveType : int
	{
		BOOK,
		BEST,
		GOOD,
		DISADVANTAGE,
		INACCURATE,
		MISTAKE,
		BLUNDER,
		UNKNOWN
	}
}
