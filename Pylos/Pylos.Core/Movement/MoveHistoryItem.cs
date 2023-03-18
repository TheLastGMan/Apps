using Pylos.Core.Board;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Movement
{
	public class MoveHistoryItem : ICloneable
	{
		public PieceType Player;
		public short Evaluation;
		public List<MoveType> ActionsApplied = new List<MoveType>(4);

		public object Clone()
		{
			var ret = new MoveHistoryItem();
			ret.Player = Player;
			ret.Evaluation = Evaluation;
			ret.ActionsApplied.AddRange(ActionsApplied);
			return ret;
		}
	}
}
