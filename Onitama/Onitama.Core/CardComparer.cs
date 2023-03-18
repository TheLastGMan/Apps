using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class CardComparer : IEqualityComparer<Card[]>
    {
        public bool Equals(Card[] x, Card[] y)
        {
            x = sortCards(x);
            y = sortCards(y);
            for (int i = 0; i < 5; i++)
                if (x[i].Title != y[i].Title)
                    return false;

            return true;
        }

        private Card[] sortCards(Card[] cards)
        {
            Card[] cs = new Card[cards.Length];
            cs[4] = cards[4];

            //player one's two cards
            if(cards[0].Title.CompareTo(cards[1].Title) <= 0)
            {
                cs[0] = cards[0];
                cs[1] = cards[1];
            }
            else
            {
                cs[0] = cards[1];
                cs[1] = cards[0];
            }

            //player two's cards
            if (cards[2].Title.CompareTo(cards[3].Title) <= 0)
            {
                cs[2] = cards[2];
                cs[3] = cards[3];
            }
            else
            {
                cs[2] = cards[3];
                cs[3] = cards[2];
            }

            return cs;
        }

        public int GetHashCode(Card[] obj)
        {
            return String.Join("|", obj.Select(f => f.Title).ToArray()).GetHashCode();
        }
    }
}
