using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzerRunner
{
	public class AnalyzerModel
	{
		public FileInfo PgnInfo { get; set; }
		public FileInfo EcoInfo { get; set; }
		public FileInfo ArenaInfo { get; set; }
		public FileInfo AnlysCli { get; set; }
		public int SecondsPerMove { get; set; }
	}
}
