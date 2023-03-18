using Connect4.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Console
{
    interface IPlayer
    {
        string Type { get; }
        void PreGame();
        sbyte MakeMove(Board board);
    }
}
