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
	public class MoveService
	{
		//Pyramid Information

		private class PyramidInfo
		{
			public readonly LevelMask LevelMask;
			public readonly LevelMask UpperLevelMask;
			public readonly SquareMask SqMask;
			public readonly Positions[] Positions;

			public PyramidInfo(LevelMask levelMask, LevelMask upperLevelMask, SquareMask squareMask, Positions[] positions)
			{
				LevelMask = levelMask;
				UpperLevelMask = upperLevelMask;
				SqMask = squareMask;
				Positions = positions;
			}
		}

		private static Positions[] pyramidSqMaps = { (Positions)SquareMask.LEVEL_0, (Positions)SquareMask.LEVEL_1, (Positions)SquareMask.LEVEL_2 };
		private static Positions[] pyramidMap_Level0 = { (Positions)((int)pyramidSqMaps[0] << 0) | Positions.L1R0C0, (Positions)((int)pyramidSqMaps[0] << 1) | Positions.L1R0C1, (Positions)((int)pyramidSqMaps[0] << 2) | Positions.L1R0C2,
														 (Positions)((int)pyramidSqMaps[0] << 4) | Positions.L1R1C0, (Positions)((int)pyramidSqMaps[0] << 5) | Positions.L1R1C1, (Positions)((int)pyramidSqMaps[0] << 6) | Positions.L1R1C2,
														 (Positions)((int)pyramidSqMaps[0] << 8) | Positions.L1R2C0, (Positions)((int)pyramidSqMaps[0] << 9) | Positions.L1R2C1, (Positions)((int)pyramidSqMaps[0] << 10) | Positions.L1R2C2 };
		private static Positions[] pyramidMap_Level1 = { (Positions)((int)pyramidSqMaps[1] << 0) | Positions.L2R0C0, (Positions)((int)pyramidSqMaps[1] << 1) | Positions.L2R0C1,
														 (Positions)((int)pyramidSqMaps[1] << 3) | Positions.L2R1C0, (Positions)((int)pyramidSqMaps[1] << 4) | Positions.L2R1C1 };
		private static Positions[] pyramidMap_Level2 = { pyramidSqMaps[2] | Positions.L3R0C0 };

		private static PyramidInfo[] pyramidMaps = { new PyramidInfo(LevelMask.LEVEL_0, LevelMask.LEVEL_1, SquareMask.LEVEL_0, pyramidMap_Level0),
													 new PyramidInfo(LevelMask.LEVEL_1, LevelMask.LEVEL_2, SquareMask.LEVEL_1, pyramidMap_Level1),
													 new PyramidInfo(LevelMask.LEVEL_2, LevelMask.LEVEL_3, SquareMask.LEVEL_2, pyramidMap_Level2)};

		// Positioning

		public static Positions[] OpenPositions(Positions ballMask)
		{
			//setup and load open positions
			Positions availableMoves = 0;

			//add in level zero positions
			Positions openPositions = ~ballMask & (Positions)LevelMask.ALL;
			for (int level0Mask = 1; level0Mask != (int)PositionOffsets.LEVEL_1_OFFSET; level0Mask <<= 1)
				if ((level0Mask & (int)openPositions) > 0)
					availableMoves |= (Positions)level0Mask;

			//upper level masks
			foreach (var pm in pyramidMaps)
			{
				Positions levelMask = ballMask & (Positions)pm.LevelMask;
				Positions openMask = openPositions & (Positions)pm.UpperLevelMask;
				Positions mapMask = levelMask | openMask;
				foreach (var pos in pm.Positions)
					if ((pos & mapMask) == pos)
						availableMoves |= (pos & (Positions)pm.UpperLevelMask);
			}

			return MoveConverter.SplitPositions(availableMoves);
		}

		public static byte SquaresMade(Positions movePosition, Positions myBoardPieces)
		{
			movePosition = MoveConverter.SingularPosition(movePosition);
			int position = (int)movePosition;
			int board = (int)myBoardPieces;
			int sqMask = 0;
			byte boundaryMod = 0;
			byte iterations = 0;
			byte sqCount = 0;

			//level 0
			if ((position & (int)LevelMask.LEVEL_0) > 0)
			{
				sqMask = (int)SquareMask.LEVEL_0;
				boundaryMod = 4;
				iterations = 11;
			}
			else if ((position & (int)LevelMask.LEVEL_1) > 0)
			{
				sqMask = (int)SquareMask.LEVEL_1;
				boundaryMod = 3;
				iterations = 5;
			}
			else if ((position & (int)LevelMask.LEVEL_2) > 0)
			{
				sqMask = (int)SquareMask.LEVEL_2;
				boundaryMod = 2;
				iterations = 1;
			}
			else
				return 0;

			//check for squares
			for (byte i = 1; i <= iterations; i++)
			{
				//check boundary overlap
				if (i % boundaryMod == 0)
					continue;

				//check that a square doesn't already exist
				//and that we made a square
				if (
					(board & sqMask) != sqMask
					&& ((board | position) & sqMask) == sqMask
					)
					sqCount += 1;

				//if ware a part of this mask, we didn't make a square
				if ((position & sqMask) > 0)
					break;


				//update mask
				sqMask <<= 1;
			}

			//number of squares made
			return sqCount;
		}

		public static bool MakeSquare(Positions movePosition, Positions myBoardPieces)
		{
			return SquaresMade(movePosition, myBoardPieces) > 0;
		}

		public static bool MakeLine(Positions movePosition, Positions myBoardPieces)
		{
			return LinesMade(movePosition, myBoardPieces) > 0;
		}

		public static byte LinesMade(Positions movePosition, Positions myBoardPieces)
		{
			return (byte)(HLinesMade(movePosition, myBoardPieces) + VLinesMade(movePosition, myBoardPieces));
		}

		public static byte HLinesMade(Positions movePosition, Positions myBoardPieces)
		{
			movePosition = MoveConverter.SingularPosition(movePosition);
			int position = (int)movePosition;
			int board = (int)myBoardPieces;
			int mask = 0;
			byte iterations = 0;
			byte hlineCount = 0;

			//level 0
			if ((position & (int)LevelMask.LEVEL_0) > 0)
			{
				mask = (int)LineMask.LEVEL_0H;
				iterations = 4;
			}
			else if ((position & (int)LevelMask.LEVEL_1) > 0)
			{
				mask = (int)LineMask.LEVEL_1H;
				iterations = 3;
			}
			else if ((position & (int)LevelMask.LEVEL_2) > 0)
			{
				mask = (int)LineMask.LEVEL_2H;
				iterations = 2;
			}
			else
				return 0;

			//check for squares
			for (byte i = 1; i <= iterations; i++)
			{
				//check that a square doesn't already exist
				//and that we made a square
				if (
					(board & mask) != mask
					&& ((board | position) & mask) == mask
					)
					hlineCount += 1;

				//if ware a part of this mask, we didn't make a square
				if ((position & mask) > 0)
					continue;

				//update mask
				mask <<= iterations;
			}

			//no line
			return hlineCount;
		}

		public static bool MakeHLine(Positions movePosition, Positions myBoardPieces)
		{
			return HLinesMade(movePosition, myBoardPieces) > 0;
		}

		public static byte VLinesMade(Positions movePosition, Positions myBoardPieces)
		{
			movePosition = MoveConverter.SingularPosition(movePosition);
			int position = (int)movePosition;
			int board = (int)myBoardPieces;
			int mask = 0;
			byte iterations = 0;
			byte vlineCount = 0;

			//level 0
			if ((position & (int)LevelMask.LEVEL_0) > 0)
			{
				mask = (int)LineMask.LEVEL_0V;
				iterations = 4;
			}
			else if ((position & (int)LevelMask.LEVEL_1) > 0)
			{
				mask = (int)LineMask.LEVEL_1V;
				iterations = 3;
			}
			else if ((position & (int)LevelMask.LEVEL_2) > 0)
			{
				mask = (int)LineMask.LEVEL_2V;
				iterations = 2;
			}
			else
				return 0;

			//check for squares
			for (byte i = 1; i <= iterations; i++)
			{
				//check that a square doesn't already exist
				//and that we made a square
				if (
					(board & mask) != mask
					&& ((board | position) & mask) == mask
					)
					vlineCount += 1;

				//if ware a part of this mask, we didn't make a square
				if ((position & mask) > 0)
					continue;

				//update mask
				mask <<= iterations;
			}

			//no line
			return vlineCount;
		}

		public static bool MakeVLine(Positions movePosition, Positions myBoardPieces)
		{
			return VLinesMade(movePosition, myBoardPieces) > 0;
		}

		/// <summary>
		/// Elevated positions above the specified position
		/// </summary>
		/// <param name="ballMask">Ball position</param>
		/// <param name="movePosition">Position to check elevation</param>
		/// <returns>Positions of allowed elevated positions</returns>
		public static Positions ElevatedPositions(Positions ballMask, Positions movePosition)
		{
			movePosition = MoveConverter.SingularPosition(movePosition);
			Positions elevatedPositions = 0;

			//find spots above the level of the specified position
			LevelMask[] offsets = { LevelMask.LEVEL_0, LevelMask.LEVEL_1, LevelMask.LEVEL_2, LevelMask.LEVEL_3, LevelMask.ALL };
			Positions openPositions = MoveConverter.CombinePositions(OpenPositions(ballMask));
			LevelMask levelMask = 0;
			foreach(LevelMask lm in offsets)
			{
				//add level filter and check if the position is at this level
				levelMask |= lm;
				if(((Positions)lm & movePosition) > 0)
				{
					//at this level, grab everything else
					elevatedPositions = (Positions)(~levelMask & LevelMask.ALL);
				}
			}

			return 0;
		}

		/// <summary>
		/// Balls with no balls higher than them in the pyramid chain
		/// </summary>
		/// <param name="ballMask">Table Info</param>
		/// <returns>Combined positions of non locked balls</returns>
		public static Positions NonLockedBalls(Positions ballMask)
		{
			//locked balls have a ball higher than them on the pyramid
			Positions lockedBalls = 0;

			//so, union the locked balls then inverse the selection
			foreach (var pm in pyramidMaps)
				foreach (var pos in pm.Positions)
					if ((ballMask & pos) == pos)
						lockedBalls |= (pos & (Positions)pm.LevelMask);

			//inverse and match against ball positions
			Positions nonLockedBalls = ~lockedBalls & ballMask;
			return nonLockedBalls;
		}
	}
}
