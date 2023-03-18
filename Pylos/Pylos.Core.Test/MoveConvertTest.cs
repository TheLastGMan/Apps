using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pylos.Core.Board;
using Pylos.Core.Movement;

namespace Pylos.Core.Test
{
	[TestClass]
	public class MoveConvertTest
	{
		[TestMethod]
		public void MoveToPositionTest1()
		{
			Positions expected = Positions.L0R0C0;
			Positions actual = MoveConverter.MoveToPosition(0, 0, 0);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void MoveToPositionTest2()
		{
			Positions expected = Positions.L2R1C1;
			Positions actual = MoveConverter.MoveToPosition(2, 1, 1);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PositionToMoveTest1()
		{
			Movement.MovePositionPretty expected;
			expected.Piece = PieceType.White;
			expected.Level = 0;
			expected.Row = 0;
			expected.Column = 0;

			Movement.MovePositionPretty actual = MoveConverter.PositionToMove(Positions.L0R0C0, PieceType.White);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PositionToMoveTest2()
		{
			Movement.MovePositionPretty expected;
			expected.Piece = PieceType.Black;
			expected.Level = 2;
			expected.Row = 1;
			expected.Column = 1;

			Movement.MovePositionPretty actual = MoveConverter.PositionToMove(Positions.L2R1C1, PieceType.Black);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void SplitPositionsTest()
		{
			Positions[] expected = { Positions.L1R0C1, Positions.L1R0C2 };
			Positions combined = Positions.L1R0C1 | Positions.L1R0C2;
			var actual = MoveConverter.SplitPositions(combined);
			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		[TestMethod]
		public void CombinePositionsTest()
		{
			Positions expected = Positions.L1R0C1 | Positions.L1R0C2;
			Positions[] split = { Positions.L1R0C1, Positions.L1R0C2 };
			var joined = MoveConverter.CombinePositions(split);
			Assert.AreEqual(expected, joined);
		}
	}
}
