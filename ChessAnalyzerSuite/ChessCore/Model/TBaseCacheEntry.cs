using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Model
{
    /// <summary>
    /// Binary Size (38 bytes)
    /// Position:256 | IsLittleEndianFormat:1 | FileNumber:15 | FilePosition:32
    /// </summary>
    public struct TBaseCacheEntry
    {
        public const byte Size = 38;

        public byte[] Position;     //32 bytes a position
        public bool BlackToMove;    //MSB of FileNumber
        public short FileNumber;    //which file number data is int
        public int FilePosition;    //byte offset in the file for the full info

        public byte[] Bytes
        {
            get
            {
                byte[] data = new byte[Size];
                Array.Copy(Position, data, Position.Length);
                short numberWithEndian = (short)(FileNumber | (short)((BlackToMove ? 1 : 0) * 0x8000));
                Array.Copy(BitConverter.GetBytes(numberWithEndian), 0, data, 32, 2);
                Array.Copy(BitConverter.GetBytes(FilePosition), 0, data, 34, 4);
                return data;
            }
            set
            {
                Array.Copy(value, Position, 32);
                FileNumber = BitConverter.ToInt16(value, 32);
                FilePosition = BitConverter.ToInt32(value, 34);
                BlackToMove = (FileNumber & 0x8000) > 0;
                FileNumber = (short)(FileNumber & 0x7FFF);
            }
        }

        public static TBaseCacheEntry FromBytes(byte[] data)
        {
            var entry = new TBaseCacheEntry();
            entry.Bytes = data;
            return entry;
        }
    }
}
