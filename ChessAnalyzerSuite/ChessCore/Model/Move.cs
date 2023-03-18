using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Model
{
    public struct Move
    {
        public const byte Size = 4;

        //square moving from
        public ColoredPiece FromPiece;
        public ColoredPiece ToPiece;

        //used to denote square of en-passant captures (only with pawns)
        public Square EnPassantSquare; //the square a pawn can capture

        //square moving to
        public Square FromSquare;
        public Square ToSquare;

        /// <summary>
        /// Parses data stream to move format
        /// FromPiece:4 | ToPiece:4  | EnPassantSquare:8 | FromSquare:8 | ToSquare:8
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                byte[] data = new byte[4];
                data[0] = (byte)((byte)FromPiece << 4);
                data[0] += (byte)ToPiece;
                data[1] = (byte)EnPassantSquare;
                data[2] = (byte)FromSquare;
                data[2] = (byte)ToSquare;
                return data;
            }
            set
            {
                FromPiece = (ColoredPiece)(value[0] >> 4);
                ToPiece = (ColoredPiece)(value[0] & 0x0F);
                EnPassantSquare = (Square)(value[1]);
                FromSquare = (Square)(value[2]);
                ToSquare = (Square)(value[3]);
            }
        }
    }
}
