using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Position
{
    public enum Points : short
    {
        Ball = 100,
        BallAhead = 50,
        Win = 10000,

        //singular placement
        Center = 50,
        Outer_Rim_NonCorner = 25,
        Corner = 0,

        //blocking
        Block_Square = 75,
        Block_Line = 75,

        //potential
        Square_Potential = 75,
        Line_Potential = 75,

        //Elevation
        Raise_Ball = 0,

        TBD = 0
    }
}
