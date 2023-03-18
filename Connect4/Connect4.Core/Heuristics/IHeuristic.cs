using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core.Heuristics
{
    public interface IHeuristic
    {
        ushort Priority { get; }
        short PositionValue(Board board, byte col, byte row, PieceType piece);
    }
}
