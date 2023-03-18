using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core.Heuristics
{
    public class Win : IHeuristic
    {
        public ushort Priority
        {
            get { return 30000; }
        }

        public short PositionValue(Board board, byte col, byte row, PieceType piece)
        {
            bool isWin = WinningPosition(board, col, row, piece);
            return (short)(isWin ? short.MaxValue : 0);
        }

        public bool WinningPosition(Board board, byte col, byte row, PieceType piece)
        {
            if (board.GetPiece(row, col) == PieceType.NA)
                return false;

            //load board
            var counter = new DirectionCounts(board);

            //adjacent search
            byte pr = counter.PiecesRow(col, row, piece);
            byte pc = counter.PiecesColumn(col, row, piece);
            byte pullr = counter.PiecesDiagLLUR(col, row, piece);
            byte pllur = counter.PiecesDiagULLR(col, row, piece);
            byte max = Math.Max(Math.Max(Math.Max(pr, pc), pullr), pllur);
            return max >= 4;
        }
    }
}
