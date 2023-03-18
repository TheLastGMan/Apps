using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pylos.Core.Board;
using Pylos.Core.Movement;
using System.Diagnostics;
using Pylos.Core.Position;

namespace Pylos.Core.Test
{
	[TestClass]
	public class AITest
	{
		[TestMethod]
		public void AIInitTest()
		{
			var testAI = new AISolver(1024);
			var bi = new BoardInfo();
			bi.Balls.WhiteBalls = 15;
			bi.Balls.BlackBalls = 15;
			//bi.Table.BallMask = Positions.L0R0C0 | Positions.L0R0C1 | Positions.L0R1C0;
			var res = testAI.MakeMove(bi, PieceType.White, (bPos) => debugResult(bPos), (zPos) => exportResult(zPos), false, true, 35);
			exportResult(res);
		}

		private void exportResult(PositionInfo res)
		{
			Debug.WriteLine("===========================");
			Debug.WriteLine("EV: " + res.LastEvaluation);
			for (int i = 0; i < res.MoveHistory.Count; i++)
			{
				var history = res.MoveHistory[i];
				Debug.WriteLine("D: " + (i + 1) + " | P: " + history.Player.ToString() + " | EV: " + history.Evaluation + " | " + String.Join(" | ", history.ActionsApplied.Select(f => $"{f.Action.ToString()} - {f.Position.ToString()}")) + "| Balls: " + res.Board.Balls.WhiteBalls + "/" + res.Board.Balls.BlackBalls);
			}
		}

		Positions lastPosition = 0;
		byte lastD = 0;
		private void debugResult(PositionInfo bPos)
		{
			var lp = bPos.MoveHistory.First().ActionsApplied.First(f => f.Action == MoveAction.Place).Position;
			var ld = (byte)bPos.MoveHistory.Count;
			if (lp != lastPosition || (lp == lastPosition && lastD != ld))
			{
				lastPosition = lp;
				lastD = ld;
				Debug.WriteLine("D: " + bPos.MoveHistory.Count + " / EV: " + bPos.LastEvaluation + " @ " + bPos.MoveHistory.First().ActionsApplied[0].Position.ToString() + " > "
					+ String.Join(" -> ", bPos.MoveHistory.Select(f => String.Join(", ", f.ActionsApplied.Select(g => $"{g.Action.ToString()} {g.Position.ToString()}")))));
			}
		}
	}
}
