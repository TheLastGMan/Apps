using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCore.Model;

namespace ChessCore
{
    public class Position
    {
        public long[] BBMask = new long[(int)Square.ALL];
        public ColoredPiece[] BBSquares = new ColoredPiece[(int)Square.ALL];
        public Square EnPassantSquare = Square.ALL;

        public Position(Square enPassantSquare = Square.ALL)
        {
            //set square to check for pawn captures
            EnPassantSquare = enPassantSquare;

            //populate mask
            long mask = 1;
            for (Square sq = Square.A1; sq < Square.ALL; sq++)
            {
                //populate mask
                BBMask[(int)sq] = mask;
                mask <<= 1;

                //set default value
                BBSquares[(int)sq] = ColoredPiece.NONE;
            }
        }

        public long SquareBitmap(Square square)
        {
            return BBMask[(int)square];
        }

        public long SquareBitmap(Square[] squares)
        {
            long bitmap = 0;
            foreach (var sq in squares)
                bitmap |= BBMask[(int)sq];
            return bitmap;
        }

        public static ColoredPiece MakePiece(Color color, Piece piece)
        {
            return (ColoredPiece)((int)color | (int)piece);
        }

        public static Color PieceColor(ColoredPiece cPiece)
        {
            return (Color)((int)cPiece & (int)Color.Black);
        }

        public static Piece PieceType(ColoredPiece cPiece)
        {
            return (Piece)((int)cPiece & 0x7);
        }

        public Square[] ByColor(Color color)
        {
            var pieces = new LinkedList<Square>();
            for (Square sq = Square.A1; sq < Square.ALL; sq++)
                if (PieceColor(BBSquares[(int)sq]) == color)
                    pieces.AddLast(sq);
            return pieces.ToArray();
        }

        public Square[] ByPiece(Piece piece)
        {
            var pieces = new LinkedList<Square>();
            for (Square sq = Square.A1; sq < Square.ALL; sq++)
                if (PieceType(BBSquares[(int)sq]) == piece)
                    pieces.AddLast(sq);
            return pieces.ToArray();
        }

        public Square[] ByColorPiece(Color color, Piece piece)
        {
            var pieces = new LinkedList<Square>();
            for (Square sq = Square.A1; sq < Square.ALL; sq++)
                if (PieceColor(BBSquares[(int)sq]) == color && PieceType(BBSquares[(int)sq]) == piece)
                    pieces.AddLast(sq);
            return pieces.ToArray();
        }

        public void PutPiece(Color color, Piece piece, Square sq)
        {
            ColoredPiece cPiece = (ColoredPiece)((int)color | (int)piece);
            BBSquares[(int)sq] = cPiece;
        }

        public void PutPiece(ColoredPiece piece, Square sq)
        {
            BBSquares[(int)sq] = piece;
        }

        public void RemoveSquare(Square sq)
        {
            BBSquares[(int)sq] = ColoredPiece.NONE;
        }

        public void MakeMove(Move move)
        {
            RemoveSquare(move.FromSquare);
            RemoveSquare(move.ToSquare);
            if (move.ToSquare == move.EnPassantSquare)
            {
                Square advPiece = EnPassantPieceSquare(move.EnPassantSquare);
                RemoveSquare(advPiece); //remove advanced pawn
            }
            PutPiece(move.FromPiece, move.ToSquare);
        }

        public void UndoMove(Move move)
        {
            RemoveSquare(move.FromSquare);
            RemoveSquare(move.ToSquare);
            PutPiece(move.FromPiece, move.FromSquare);

            Square lastSquare = move.FromSquare;
            if(move.ToSquare == move.EnPassantSquare)
            {
                //en-passant logic
                lastSquare = EnPassantPieceSquare(move.EnPassantSquare);
            }
            PutPiece(move.ToPiece, lastSquare);
        }

        public Square EnPassantPieceSquare(Square sq)
        {
            if (sq >= Square.A3 && sq <= Square.H3)
                return sq - 8;
            if (sq >= Square.A5 && sq <= Square.H5)
                return sq + 8;
            return Square.ALL;
        }

        public static ColoredPiece CharToPiece(char notation)
        {
            Piece piece = Piece.Pawn;
            switch(notation.ToString().ToLower()[0])
            {
                case 'r':
                    piece = Piece.Rook;
                    break;
                case 'b':
                    piece = Piece.Rook;
                    break;
                case 'n':
                    piece = Piece.Knight;
                    break;
                case 'q':
                    piece = Piece.Queen;
                    break;
                case 'k':
                    piece = Piece.King;
                    break;
                default:
                    piece = Piece.Pawn;
                    break;
            }

            ColoredPiece cPiece = (ColoredPiece)((int)piece | (int)(notation >= 'a' && notation <= 'z' ? Color.Black : Color.White));
            return cPiece;
        }

        public string GenerateFenCode()
        {
            var sb = new StringBuilder(128);
            int spaces = 0;
            for(int i = 1; i <=64; i++)
            {
                ColoredPiece piece = BBSquares[i - 1];
                if (piece == ColoredPiece.NONE)
                    spaces += 1;
                else
                {
                    //add in remaining spaces
                    if (spaces != 0)
                    {
                        sb.Append(spaces.ToString());
                        spaces = 0;
                    }

                    string pieceCode = "";
                    switch(PieceType(piece))
                    {
                        case Piece.Bishop:
                            pieceCode = "B";
                            break;
                        case Piece.King:
                            pieceCode = "K";
                            break;
                        case Piece.Knight:
                            pieceCode = "N";
                            break;
                        case Piece.Queen:
                            pieceCode = "Q";
                            break;
                        case Piece.Rook:
                            pieceCode = "R";
                            break;
                        default:
                            pieceCode = "P";
                            break;
                    }

                    if (PieceColor(piece) == Color.Black)
                        pieceCode = pieceCode.ToLower();

                    sb.Append(pieceCode);
                }

                //check for end of rank
                if (i % 8 == 0)
                {
                    if (spaces != 0)
                    {
                        sb.Append(spaces.ToString());
                        spaces = 0;
                    }
                    sb.Append("/");
                }
            }

            //flip so top rank is first
            string[] rankFlip = sb.ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            string flipped = String.Join("/", rankFlip);
            return flipped;
        }
    }
}
