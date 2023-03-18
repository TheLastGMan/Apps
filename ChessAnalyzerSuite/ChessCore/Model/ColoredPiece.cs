using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Model
{
    public enum ColoredPiece : byte
    {
        NONE = Piece.All,
        White_Pawn = Color.White | Piece.Pawn,
        White_Rook = Color.White | Piece.Rook,
        White_Knight = Color.White | Piece.Knight,
        White_Bishop = Color.White | Piece.Bishop,
        White_Queen = Color.White | Piece.Queen,
        White_King = Color.White | Piece.King,
        Black_Pawn = Color.Black | Piece.Pawn,
        Black_Rook = Color.Black | Piece.Rook,
        Black_Knight = Color.Black | Piece.Knight,
        Black_Bishop = Color.Black | Piece.Bishop,
        Black_Queen = Color.Black | Piece.Queen,
        Black_King = Color.Black | Piece.King
    }
}
