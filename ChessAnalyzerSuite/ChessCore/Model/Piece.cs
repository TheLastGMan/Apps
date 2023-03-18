using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Model
{
    public enum Piece : byte
    {
        Pawn = 0,
        Rook,
        Knight,
        Bishop,
        Queen,
        King,
        All
    }
}
