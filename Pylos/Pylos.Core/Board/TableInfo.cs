using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Board
{
	public struct TableInfo
	{
		public Positions BallMask;
		public Positions Pieces;
	}

	public class TableInfoComparer : IEqualityComparer<TableInfo>
	{
		public bool Equals(TableInfo x, TableInfo y)
		{
			return x.BallMask == y.BallMask && x.Pieces == y.Pieces;
		}

		public int GetHashCode(TableInfo obj)
		{
			return obj.GetHashCode();
		}
	}
}
