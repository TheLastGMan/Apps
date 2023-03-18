using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core.Heuristics
{
    public class DirectionCounts
    {
        private Board _Board;

        public DirectionCounts(Board board)
        {
            _Board = board;
        }
        
        

        #region Full Direction Sums

        public byte PiecesRow(byte col, byte row, PieceType piece)
        {
            return (byte)(piecesLeft(col, row, piece) + piecesRight(col, row, piece) + 1);
        }

        public byte PiecesColumn(byte col, byte row, PieceType piece)
        {
            return (byte)(piecesUp(col, row, piece) + piecesDown(col, row, piece) + 1);
        }

        public byte PiecesDiagULLR(byte col, byte row, PieceType piece)
        {
            return (byte)(piecesToUL(col, row, piece) + piecesToLR(col, row, piece) + 1);
        }

        public byte PiecesDiagLLUR(byte col, byte row, PieceType piece)
        {
            return (byte)(piecesToLL(col, row, piece) + piecesToUR(col, row, piece) + 1);
        }

        #endregion

        #region Direction Sums

        public byte piecesLeft(byte col, byte row, PieceType piece)
        {
            byte count = 0;
            while (col != 0)
                if (_Board.GetPiece(row, --col) == piece)
                    count += 1;
                else
                    break;
            return count;
        }

        public byte piecesRight(byte col, byte row, PieceType piece)
        {
            byte count = 0;
            while (++col != Board.BoardColumns)
                if (_Board.GetPiece(row, col) == piece)
                    count += 1;
                else
                    break;
            return count;
        }

        public byte piecesUp(byte col, byte row, PieceType piece)
        {
            byte count = 0;
            while (++row != Board.BoardRows)
                if (_Board.GetPiece(row, col) == piece)
                    count += 1;
                else
                    break;
            return count;
        }

        public byte piecesDown(byte col, byte row, PieceType piece)
        {
            byte count = 0;
            while (row != 0)
                if (_Board.GetPiece(--row, col) == piece)
                    count += 1;
                else
                    break;
            return count;
        }

        public byte piecesToUR(byte col, byte row, PieceType piece)
        {
            byte count = 0;
            while (++row != Board.BoardRows && ++col != Board.BoardColumns)
                if (_Board.GetPiece(row, col) == piece)
                    count += 1;
                else
                    break;
            return count;
        }

        public byte piecesToLR(byte col, byte row, PieceType piece)
        {
            byte count = 0;
            while (row != 0 && ++col != Board.BoardColumns)
                if (_Board.GetPiece(--row, col) == piece)
                    count += 1;
                else
                    break;
            return count;
        }

        public byte piecesToUL(byte col, byte row, PieceType piece)
        {
            byte count = 0;
            while (++row != Board.BoardRows && col != 0)
                if (_Board.GetPiece(row, --col) == piece)
                    count += 1;
                else
                    break;
            return count;
        }

        public byte piecesToLL(byte col, byte row, PieceType piece)
        {
            byte count = 0;
            while (row != 0 && col != 0)
                if (_Board.GetPiece(--row, --col) == piece)
                    count += 1;
                else
                    break;
            return count;
        }

        #endregion

    }
}
