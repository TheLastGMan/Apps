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
    public class FEN
    {
        public Position BoardPosition { get; private set; } = new Position();
        public string FromPosition { get; private set; }
        public short HalfMoves { get; private set; }
        public short MoveNumber { get; private set; }
        public Color SideToMove { get; private set; }
        public Square EnPassantSquare { get { return BoardPosition.EnPassantSquare; } }
        public Castling CastlingRights { get; private set; }

        public static FEN FromFEN(string fen)
        {
            //split and validate
            string[] rows = fen.Split('/', ' ');
            if (rows.Length != 13)
                throw new Exception("Invalid FEN, expecting 13 parts, found only " + rows.Length);

            //starts at A8
            var fenInfo = new FEN();
            fenInfo.BoardPosition = new Position();
            fenInfo.FromPosition = String.Join("/", rows.Take(8));
            Square fenSq = Square.A8;
            foreach (string rank in fenInfo.FromPosition.Split('/'))
            {
                foreach (var ch in rank)
                {
                    //check for square skips
                    if (isNumeric(ch))
                    {
                        byte squares = byte.Parse(ch.ToString());
                        fenSq += squares;
                        continue;
                    }

                    //set piece
                    Color color = fenColor(ch);
                    Piece piece = fenPiece(ch);
                    fenInfo.BoardPosition.PutPiece(color, piece, fenSq);
                    fenSq += 1;
                }
                fenSq -= 16;
            }

            string[] fenParts = fen.Split(' ');
            //side to move
            fenInfo.SideToMove = fenParts[1] == "w" ? Color.White : Color.Black;

            //castles rights
            Castling cRights = new Castling();
            foreach (var ch in fenParts[2])
                switch (ch)
                {
                    case 'K':
                        cRights.White_Short = true;
                        break;
                    case 'Q':
                        cRights.White_Long = true;
                        break;
                    case 'k':
                        cRights.Black_Short = true;
                        break;
                    case 'q':
                        cRights.Black_Long = true;
                        break;
                    default:
                        break;
                }
            fenInfo.CastlingRights = cRights;

            //en-passant square
            string epSqCode = fenParts[3].ToLower();
            if (epSqCode.Length == 2)
            {
                int file = (epSqCode[0] - 'a');
                int rank = int.Parse(epSqCode[1].ToString()) - 1;
                fenInfo.BoardPosition.EnPassantSquare = (Square)(file + (rank * 8));
            }

            //full move number
            fenInfo.MoveNumber = short.Parse(fenParts[4]);

            //half moves
            fenInfo.HalfMoves = short.Parse(fenParts[5]);

            return fenInfo;
        }

        private static Color fenColor(char ch)
        {
            return ch >= 'a' && ch <= 'z' ? Color.Black : Color.White;
        }

        private static Piece fenPiece(char ch)
        {
            switch (ch.ToString().ToLower()[0])
            {
                case 'r':
                    return Piece.Rook;
                case 'n':
                    return Piece.Knight;
                case 'b':
                    return Piece.Bishop;
                case 'q':
                    return Piece.Queen;
                case 'k':
                    return Piece.King;
                default:
                    return Piece.Pawn;
            }
        }

        private static bool isNumeric(char value)
        {
            int v;
            return int.TryParse(value.ToString(), out v);
        }
    }
}
