using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Model
{
    public struct TBaseMoveInfo
    {
        public Move[] WhiteMoves;
        public Move[] BlackMoves;

        /// <summary>
        /// Size:32 | BlackMoveOffset:32 | WhiteMoves:32*w | BlackMoves:32*b
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                byte[] data = new byte[8 + WhiteMoves.Length * Move.Size + BlackMoves.Length * Move.Size];
                int offset = WhiteMoves.Length * Move.Size;
                Array.Copy(BitConverter.GetBytes(data.Length), data, 4);
                Array.Copy(BitConverter.GetBytes(offset), 0, data, 4, 4);
                var whiteBytes = WhiteMoves.SelectMany(f => f.Bytes).ToArray();
                Array.Copy(whiteBytes, 0, data, 8, whiteBytes.Length);
                var blackBytes = BlackMoves.SelectMany(f => f.Bytes).ToArray();
                Array.Copy(blackBytes, 0, data, 8 + whiteBytes.Length, blackBytes.Length);
                return data;
            }
            set
            {
                int size = BitConverter.ToInt32(value, 0);
                int blackMoveOffset = BitConverter.ToInt32(value, 4);
                WhiteMoves = new Move[blackMoveOffset / Move.Size];
                BlackMoves = new Move[(size - blackMoveOffset - 8) / Move.Size];

                int pos = 8;
                for (int i = 0; i <= WhiteMoves.Length; i++, pos += Move.Size)
                {
                    byte[] data = new byte[Move.Size];
                    Array.Copy(value, pos, data, 0, data.Length);
                    var move = new Move();
                    move.Bytes = data;
                    WhiteMoves[i] = move;
                }

                for(int i = 0; i < BlackMoves.Length; i++, pos += Move.Size)
                {
                    byte[] data = new byte[Move.Size];
                    Array.Copy(value, pos, data, 0, data.Length);
                    var move = new Move();
                    move.Bytes = data;
                    BlackMoves[i] = move;
                }
            }
        }
    }
}
