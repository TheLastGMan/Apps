using ChessCore.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    public class MoveFinder
    {
        public Move[] MovesFromFEN(string fen)
        {
            FEN fenData = FEN.FromFEN(fen);
            return MovesFromPosition(fenData.BoardPosition, fenData.SideToMove, fenData.CastlingRights);
        }

        public Move[] MovesFromPosition(Position pos, Color sideToMove, Castling castlingRights)
        {
            return new Move[] { };
        }
    }
}
