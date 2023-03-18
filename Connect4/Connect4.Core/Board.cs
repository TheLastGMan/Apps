using Connect4.Core.Heuristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core
{
    public class Board : ICloneable
    {
        public const byte BoardRows = 6;
        public const byte BoardColumns = 7;
        private PieceType[,] _BoardLayout = new PieceType[BoardRows, BoardColumns];

        public object Clone()
        {
            Board b = (Board)this.MemberwiseClone();
            b._BoardLayout = (PieceType[,])_BoardLayout.Clone();
            return b;
        }

        public bool IsEmpty
        {
            get
            {
                //check for empty first row
                for (byte i = 0; i < BoardColumns; i++)
                    if (GetPiece(0, i) != PieceType.NA)
                        return false;

                //all empty
                return true;
            }
        }

        public PieceType GetPiece(byte row, byte col)
        {
            return _BoardLayout[row, col];
        }

        public sbyte PutPiece(byte col, PieceType piece)
        {
            //check if column is available
            if (ColumnAvailable(col))
                //determine where to put piece
                for (sbyte row = 0; row < BoardRows; row++)
                    if (GetPiece((byte)row, col) == PieceType.NA)
                    {
                        //assign piece to board
                        _BoardLayout[row, col] = piece;
                        return row;
                    }
            return -1;
        }

        public bool ColumnsAvailable
        {
            get
            {
                return Enumerable.Range(0, BoardColumns).Any(f => ColumnAvailable((byte)f));
            }
        }

        public bool ColumnAvailable(byte col)
        {
            return GetPiece(BoardRows - 1, col) == PieceType.NA;
        }

        List<IHeuristic> _Heuristics = new List<IHeuristic>() { new Heuristics.Win(), new Heuristics.Blocking()};
        public short PositionValue(byte col, byte row, PieceType piece)
        {
            short value = 0;
            foreach(var logic in _Heuristics)
            {
                short pval = logic.PositionValue(this, col, row, piece);
                value += pval;

                if (pval >= 32000)
                    return pval;
            }

            return value;
        }
    }
}
