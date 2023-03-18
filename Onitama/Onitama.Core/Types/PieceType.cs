﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public enum PieceType : byte
    {
        All,
        Pawn,
        Master,
        None,
        NB = None
    }
}
