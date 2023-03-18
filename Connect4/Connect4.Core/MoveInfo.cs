using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core
{
    public struct MoveInfo
    {
        public byte Column;
        public PieceType Piece;
        public short PositionValue;
    }
}
