using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Data
{
	public class LastEcoMove
	{
		public int PlyNumber { get; set; } = 0;
		public EcoData LastEco { get; set; } = new EcoData() { Code = "U00", Name = "Unknown" };
	}
}
