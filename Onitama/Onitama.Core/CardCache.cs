using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class CardCache
    {
        private static ConcurrentBag<Card[]> _CardCache = new ConcurrentBag<Card[]>();
        private static CardComparer _CardComp = new CardComparer();

        public static int GetIndex(Card[] cards)
        {
            int index = 0;
            foreach (Card[] cc in _CardCache)
                if (_CardComp.Equals(cards, cc))
                    return index;
                else
                    index += 1;

            _CardCache.Add(cards);
            return index;
        }

        public static Card[] GetCards(int index)
        {
            return _CardCache.ElementAt(index);
        }
    }
}
