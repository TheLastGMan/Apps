using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public enum Piece : byte
    {
        None = 0,
        Red_Pawn = 1,
        Red_Master = 2,
        Blue_Pawn = 5,
        Blue_Master = 6,
        Max = 5 //max five pieces per color
    }
}
