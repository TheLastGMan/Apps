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
    public class Heuristic
    {
        private static PositionOffsets[] levelOffsets = { PositionOffsets.LEVEL_0_OFFSET, PositionOffsets.LEVEL_1_OFFSET, PositionOffsets.LEVEL_2_OFFSET, PositionOffsets.LEVEL_3_OFFSET };
        private static PositionOffsets[] rowSizes = { PositionOffsets.LEVEL_0_SIZE, PositionOffsets.LEVEL_1_SIZE, PositionOffsets.LEVEL_2_SIZE, PositionOffsets.LEVEL_3_SIZE };

        public static Positions MyPieces(TableInfo table, PieceType player)
        {
            if (player == PieceType.Black)
                return table.Pieces;
            else
                return ~table.Pieces & table.BallMask;
        }

        public static Positions OpponentsPieces(TableInfo table, PieceType player)
        {
            if (player == PieceType.Black)
                return ~table.Pieces & table.BallMask;
            else
                return table.Pieces;
        }

        public static short Evalulate(PositionInfo info, bool allowLines)
        {
            //last move, mine/opp pieces
            Positions lastMove = info.MoveHistory.Last().ActionsApplied.First(f => f.Action == MoveAction.Place).Position;
            Positions myPieces = info.Board.Table.Pieces;
            Positions oppPieces = info.Board.Table.BallMask & ~info.Board.Table.Pieces;
            if (info.Player == PieceType.White)
            {
                Positions tmp = myPieces;
                myPieces = oppPieces;
                oppPieces = tmp;
            }
            var prettyMove = MoveConverter.PositionToMove(lastMove, info.Player);

            //scoring
            short score = (short)((short)Points.Ball * (info.Player == PieceType.White ? info.Board.Balls.WhiteBalls : info.Board.Balls.BlackBalls));
            if (info.Player == PieceType.White && info.Board.Balls.WhiteBalls == 0
                || info.Player == PieceType.Black && info.Board.Balls.BlackBalls == 0)
            {
                //losing position
                return -1 * (short)Points.Win;
            }
            if (info.Player == PieceType.White && info.Board.Balls.BlackBalls == 0
                || info.Player == PieceType.Black && info.Board.Balls.WhiteBalls == 0)
            {
                //winning position
                return (short)Points.Win;
            }

            //if we have the same number of balls as our opponent, we are winning
            if (info.Board.Balls.WhiteBalls == info.Board.Balls.BlackBalls)
                score += (short)Points.BallAhead;

            //different conditions
            score += CenterSpot(lastMove);
            score += OuterRimSpot(lastMove);
            score += CornerSpot(lastMove);
            score += BlockSquare(lastMove, oppPieces);
            score += SquarePotential(lastMove, myPieces, oppPieces);
            score += (short)((short)Points.Raise_Ball * prettyMove.Level);
            if (allowLines)
            {
                score += BlockLine(lastMove, oppPieces);
                score += LinePotential(lastMove, myPieces, oppPieces);
            }

            score -= (short)((short)Points.Ball * (info.Player == PieceType.White ? info.Board.Balls.BlackBalls : info.Board.Balls.WhiteBalls));
            return score;
        }

        public static short CenterSpot(Positions movePosition)
        {
            byte centerPieces = CountBits(
                    ((int)movePosition & (int)LevelPositionMask.LEVEL_0_CTR) |
                    ((int)movePosition & (int)LevelPositionMask.LEVEL_1_CTR)
                );
            return (short)(centerPieces * (short)Points.Center);
        }

        public static short OuterRimSpot(Positions movePosition)
        {
            byte outerRims = CountBits(
                    ((int)movePosition & (int)LevelPositionMask.LEVEL_0_RIM) |
                    ((int)movePosition & (int)LevelPositionMask.LEVEL_1_RIM)
                );
            return (short)(outerRims * (short)Points.Outer_Rim_NonCorner);
        }

        public static short CornerSpot(Positions movePosition)
        {
            byte corners = CountBits(
                    ((int)movePosition & (int)LevelPositionMask.LEVEL_0_CNR) |
                    ((int)movePosition & (int)LevelPositionMask.LEVEL_1_CNR)
                );
            return (short)(corners * (short)Points.Corner);
        }

        public static short BlockSquare(Positions movePosition, Positions opponentBoardPieces)
        {
            return (short)(MoveService.SquaresMade(movePosition, opponentBoardPieces) * (short)Points.Block_Square);
        }

        public static short BlockLine(Positions movePosition, Positions opponentBoardPieces)
        {
            return (short)(MoveService.HLinesMade(movePosition, opponentBoardPieces) + MoveService.VLinesMade(movePosition, opponentBoardPieces) * (short)Points.Block_Line);
        }

        public static short SquarePotential(Positions movePosition, Positions playerPieces, Positions oppPieces)
        {
            return 0;
        }

        public static short LinePotential(Positions movePosition, Positions playerPieces, Positions oppPieces)
        {
            return 0;
        }

        public static byte CountBits(int value)
        {
            //setup
            byte count = 0;

            //count the number of bits set
            for (uint mask = 1; mask != 0; mask <<= 1)
                if ((mask & value) != 0)
                    count += 1;

            //give result
            return count;
        }
    }
}
