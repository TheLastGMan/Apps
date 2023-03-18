using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core.Heuristics
{
    public class Blocking : IHeuristic
    {
        public ushort Priority
        {
            get { return 28000; }
        }

        public short PositionValue(Board board, byte col, byte row, PieceType piece)
        {
            bool isBlocking = BlockingPosition(board, col, row, piece);
            return (short)(isBlocking ? 32000 : 0);
        }
        public bool BlockingPosition(Board board, byte col, byte row, PieceType piece)
        {
            if (piece == PieceType.NA)
                return false;

            //win checking
            PieceType other = (piece == PieceType.P1) ? PieceType.P2 : PieceType.P1;
            bool otherWins = new Win().WinningPosition(board, col, row, other);
            return otherWins;
        }
    }
}
