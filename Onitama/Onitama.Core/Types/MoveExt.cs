using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public struct MoveExt
    {
        public Move Move;
        public int CardCacheIndex;

        public MoveExt(Move m, Card[] cards)
        {
            Move = m;
            CardCacheIndex = CardCache.GetIndex(cards);
        }
    }
}
