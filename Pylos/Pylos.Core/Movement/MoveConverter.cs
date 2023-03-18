using Pylos.Core.Board;
using Pylos.Core.Position;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Movement
{
    public class MoveConverter
    {
        public static Positions MoveToPosition(byte level, byte row, byte column)
        {
            string format = $"L{level}R{row}C{column}";
            Positions p = ((Positions[])Enum.GetValues(typeof(Positions))).FirstOrDefault(f => f.ToString() == format);
            return p;
        }

        public static MovePositionPretty PositionToMove(Positions info, PieceType piece)
        {
            //setup
            MovePositionPretty mi;
            mi.Piece = piece;

            //convert to format
            string format = info.ToString();
            mi.Level = byte.Parse(format.Substring(1, 1));
            mi.Row = byte.Parse(format.Substring(3, 1));
            mi.Column = byte.Parse(format.Substring(5, 1));

            return mi;
        }

        public static Positions SingularPosition(Positions position)
        {
            //find first valid position
            for (uint mask = 1; mask != 0; mask <<= 1)
                if (((uint)position & mask) > 0)
                    return (Positions)mask;

            //position not found
            return 0;
        }

        public static Positions[] SplitPositions(Positions position)
        {
            var positions = new List<Positions>();

            //go through all possibilities
            for (uint mask = 1; mask != 0; mask <<= 1)
                if (((int)position & mask) > 0)
                    positions.Add((Positions)mask);

            //convert to array
            return positions.ToArray();
        }

        public static Positions CombinePositions(Positions[] positions)
        {
            if (!positions.Any())
                return 0;

            //short hand combine of positions
            return positions.Aggregate((current, next) => current |= next);
        }

        public static void SetPosition(ref TableInfo board, Positions move, PieceType piece)
        {
            board.BallMask |= move;
            board.Pieces |= (Positions)((int)piece * (int)move);
        }

        public static void ClearPosition(ref TableInfo board, Positions move)
        {
            board.BallMask = board.BallMask & ~move;
            board.Pieces = board.Pieces & ~move;
        }

        public static int CountBalls(TableInfo board)
        {
            return Heuristic.CountBits((int)board.BallMask);
        }

        public static int CountPlayerBalls(TableInfo board, PieceType player)
        {
            if (player == PieceType.White)
                return Heuristic.CountBits((int)(~board.Pieces & board.BallMask));
            else
                return Heuristic.CountBits((int)board.Pieces);
        }
    }
}
