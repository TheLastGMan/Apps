using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Model
{
    public struct Castling
    {
        public bool White_Short;
        public bool White_Long;
        public bool Black_Short;
        public bool Black_Long;
    }
}
