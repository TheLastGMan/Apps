using Pylos.Core.Board;
using Pylos.Core.Movement;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Position
{
	public class PositionInfo : ICloneable, IComparable<PositionInfo>, IComparer<PositionInfo>
	{
		public PieceType Player;
		public BoardInfo Board;
		public List<MoveHistoryItem> MoveHistory = new List<MoveHistoryItem>(64);

		public short LastEvaluation
		{
			get { return MoveHistory.LastOrDefault()?.Evaluation ?? 0; }
			set
			{
				if (MoveHistory.Any())
					MoveHistory.Last().Evaluation = value;
			}
		}

		public object Clone()
		{
			var newInfo = new PositionInfo();
			newInfo.Player = Player;
			newInfo.Board = Board;
			newInfo.MoveHistory.AddRange(MoveHistory.Select(f => (MoveHistoryItem)f.Clone()));
			return newInfo;
		}

		public int CompareTo(PositionInfo other)
		{
			//put highest EVal first, then lowest History
			if (LastEvaluation > other.LastEvaluation)
				return -1;
			else if (LastEvaluation < other.LastEvaluation)
				return 1;
			else
				return MoveHistory.Count.CompareTo(other.MoveHistory.Count);
		}

		public int Compare(PositionInfo x, PositionInfo y)
		{
			return x.CompareTo(y);
		}
	}
}
