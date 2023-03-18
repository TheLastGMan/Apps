using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class Evaluate
    {
        private static readonly short PawnValue = 100;
        private static readonly short[] SquareBonus = new short[] { 0, 0, 0, 0, 0, 0, 3, 3, 3, 0, 1, 3, 5, 3, 1, 0, 3, 3, 3, 0, 0, 0, 0, 0, 0 };
        private static readonly short KingDistanceValue = 10;
        private static readonly short PawnRankValue = 2;

        private static short pawnValue(Position pos, Color player)
        {
            return (short)(pos.PieceCount[(int)player, (int)PieceType.Pawn] * PawnValue);
        }

        private static short pawnDistance(Position pos, Color player)
        {
            short value = 0;
            Rank backRank = player == Color.Red ? Rank.Five : Rank.One;
            foreach (Square sq in Position.GetSquares(pos.ByColorBB[(int)player]))
                if (Position.GetPieceType(pos.Board[(int)sq]) == PieceType.Pawn)
                    value += (short)(PawnRankValue * ((int)Rank.UB - 2) - Math.Abs((int)backRank - (int)Position.RankOf(sq)));

            return value;
        }

        private static short squareBonus(Position pos, Color player)
        {
            short value = 0;
            foreach (Square sq in Position.GetSquares(pos.ByColorBB[(int)player]))
                if (Position.GetPieceType(pos.Board[(int)sq]) == PieceType.Pawn)
                    value += SquareBonus[(int)sq];

            return value;
        }

        private static short kingDistance(Position pos, Color player)
        {
            Square keySquare = player == Color.Red ? Square.C5 : Square.C1;
            Square[] kingSquares = Position.GetSquares(pos.ByTypeBB[(int)PieceType.Master]);
            Square kingSquare = Position.GetPieceColor(pos.Board[(int)kingSquares[0]]) == Color.Red ? kingSquares[0] : kingSquares[1];
            int rankDist = Math.Abs((int)Position.RankOf(keySquare) - (int)Position.RankOf(kingSquare));
            int fileDist = Math.Abs((int)Position.FileOf(keySquare) - (int)Position.FileOf(kingSquare));
            int distMin = Math.Min(rankDist, fileDist);
            rankDist -= distMin;
            fileDist -= distMin;
            return (short)((4 - (rankDist + fileDist)) * KingDistanceValue);
        }

        private static bool kingOnWinningSquare(Position pos, Color player)
        {
            Square keySquare = player == Color.Red ? Square.C5 : Square.C1;
            Square[] kingSquares = Position.GetSquares(pos.ByTypeBB[(int)PieceType.Master]);
            Square kingSquare = kingSquares[0];
            if (Position.GetPieceColor(pos.Board[(int)kingSquare]) != player)
            {
                if (kingSquares.Length != 2)
                    return false;
                else
                    kingSquare = kingSquares[1];
            }

            return kingSquare == keySquare;
        }

        public static bool GameOver(Position pos)
        {
            if (pos.PieceCount[(int)Color.Red, (int)PieceType.Master] == 0 || pos.PieceCount[(int)Color.Blue, (int)PieceType.Master] == 0)
                return true;

            if (kingOnWinningSquare(pos, Color.Red) || kingOnWinningSquare(pos, Color.Blue))
                return true;

            return false;
        }

        private static short isWin(Position pos, Color player)
        {
            if (pos.PieceCount[(int)(player == Color.Red ? Color.Blue : Color.Red), (int)PieceType.Master] == 0)
                return 30000;
            if (kingOnWinningSquare(pos, player))
                return 30000;

            if (pos.PieceCount[(int)player, (int)PieceType.Master] == 0)
                return -30000;
            if (kingOnWinningSquare(pos, player == Color.Red ? Color.Blue : Color.Red))
                return -30000;

            return 0;
        }

        private static short colorEval(Position pos, Color player)
        {
            short value = pawnValue(pos, player);
            value += squareBonus(pos, player);
            value += pawnDistance(pos, player);
            return value;
        }

        public static short EvalulatePosition(Position pos, Color player)
        {
            short win = isWin(pos, player);
            if (Math.Abs(win) == 30000)
                return win;

            return (short)(kingDistance(pos, player) + (colorEval(pos, player) - colorEval(pos, player == Color.Red ? Color.Blue : Color.Red)));
        }
    }
}
