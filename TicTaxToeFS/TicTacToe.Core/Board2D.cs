using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
	public class Board2D
	{
		public string UL { get; set; } = "1";
		public string UC { get; set; } = "2";
		public string UR { get; set; } = "3";
		public string ML { get; set; } = "4";
		public string MC { get; set; } = "5";
		public string MR { get; set; } = "6";
		public string LL { get; set; } = "7";
		public string LC { get; set; } = "8";
		public string LR { get; set; } = "9";
	}
}
