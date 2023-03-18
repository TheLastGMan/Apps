using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    [Flags]
    public enum BitBoard : int
    {
        None = 0,
        A1 = 0x00000001,
        B1 = 0x00000002,
        C1 = 0x00000004,
        D1 = 0x00000008,
        E1 = 0x00000010,
        A2 = 0x00000020,
        B2 = 0x00000040,
        C2 = 0x00000080,
        D2 = 0x00000100,
        E2 = 0x00000200,
        A3 = 0x00000400,
        B3 = 0x00000800,
        C3 = 0x00001000,
        D3 = 0x00002000,
        E3 = 0x00004000,
        A4 = 0x00008000,
        B4 = 0x00010000,
        C4 = 0x00020000,
        D4 = 0x00040000,
        E4 = 0x00080000,
        A5 = 0x00100000,
        B5 = 0x00200000,
        C5 = 0x00400000,
        D5 = 0x00800000,
        E5 = 0x01000000
    }
}
