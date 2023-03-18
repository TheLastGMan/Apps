using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public struct Move
    {
        public Square From;
        public Square To;
        public Piece CapturedPiece;
        public Color PieceColor;
        public PieceType PieceType;
        public Card Card;

        public Move(Square from, Square to, Color c, PieceType pt, Card card, Piece capture = Piece.None)
        {
            From = from;
            To = to;
            PieceColor = c;
            PieceType = pt;
            Card = card;
            CapturedPiece = capture;
        }
    }
}
