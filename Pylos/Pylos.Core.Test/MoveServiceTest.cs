using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pylos.Core.Board;
using Pylos.Core.Movement;
using System.Linq;

namespace Pylos.Core.Test
{
	[TestClass]
	public class MoveServiceTest
	{
		[TestMethod]
		public void OpenLevel0()
		{
			Positions expected = (Positions)LevelMask.LEVEL_0;
			Positions ballMask = 0;
			Positions actual = MoveService.OpenPositions(ballMask).Aggregate((current, next) => current | next);
			Assert.AreEqual(expected, actual, "Open spots for Level 0 are not accurate");
		}

		[TestMethod]
		public void OpenLevel1()
		{
			Positions expected = (Positions)LevelMask.LEVEL_1;
			Positions ballMask = (Positions)LevelMask.LEVEL_0;
			Positions actual = MoveService.OpenPositions(ballMask).Aggregate((current, next) => current | next);
			Assert.AreEqual(expected, actual, "Open spots for Level 1 are not accurate");
		}

		[TestMethod]
		public void OpenLevel2()
		{
			Positions expected = (Positions)LevelMask.LEVEL_2;
			Positions ballMask = (Positions)(LevelMask.LEVEL_1 | LevelMask.LEVEL_0);
			Positions actual = MoveService.OpenPositions(ballMask).Aggregate((current, next) => current | next);
			Assert.AreEqual(expected, actual, "Open spots for Level 2 are not accurate");
		}

		[TestMethod]
		public void OpenLevel2SmSqTest()
		{
			Positions expected = Positions.L2R0C0;
			Positions ballMask = Positions.L1R0C0 | Positions.L1R0C1 | Positions.L1R1C0 | Positions.L1R1C1 | (Positions)LevelMask.LEVEL_0;
			Positions actual = MoveService.OpenPositions(ballMask).Aggregate((current, next) => current | next);
			Positions actualContains = expected | (actual & (Positions)LevelMask.LEVEL_2);
			Assert.AreEqual(expected, actualContains, "Open spots for Level 2 Small Square are not accurate");
		}

		[TestMethod]
		public void OpenLevel3()
		{
			Positions expected = (Positions)LevelMask.LEVEL_3;
			Positions ballMask = (Positions)(LevelMask.LEVEL_2 | LevelMask.LEVEL_1 | LevelMask.LEVEL_0);
			Positions actual = MoveService.OpenPositions(ballMask).Aggregate((current, next) => current | next);
			Assert.AreEqual(expected, actual, "Open spots for Level 3 are not accurate");
		}

		[TestMethod]
		public void NonLockedBallsLvl2SqTest()
		{
			Positions expected = Positions.L1R1C2 | Positions.L1R0C2 | Positions.L2R0C0;
			Positions ballMask = (Positions)((int)LineMask.LEVEL_1H | (int)LineMask.LEVEL_1H << 3) | Positions.L2R0C0;
			Positions actual = MoveService.NonLockedBalls(ballMask);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ElevatedPositionsTest()
		{
			Positions expected = Positions.L1R0C1 | Positions.L1R0C2 ;
			Positions ballMask = (Positions)(LineMask.LEVEL_0H | (LineMask)((int)LineMask.LEVEL_0H << 4));
			Positions elevated = MoveService.ElevatedPositions(ballMask, Positions.L0R0C0);
			Assert.AreEqual(expected, elevated);
		}
	}
}
