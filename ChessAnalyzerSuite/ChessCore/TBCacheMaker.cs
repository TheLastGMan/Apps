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
    public class TBCacheMaker
    {
        public static byte[] TBEntryIndexFromPosition(Position pos)
        {
            byte[] data = new byte[32]; //4 bits a square, 64 squares, 256bits = 32 bytes
            int offset = 0;
            for(int i = 0; i < pos.BBSquares.Length; i += 2)
            {
                data[offset] = (byte)pos.BBSquares[i];
                data[offset] <<= 4;
                data[offset] += (byte)pos.BBSquares[i + 1];
                offset += 1;
            }

            return data;
        }
    }
}
