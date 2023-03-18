using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class PositionCache
    {
        private static Dictionary<int, TableEntry> _PositionCache = new Dictionary<int, TableEntry>(10000000);

        public static short Probe(Position pos, Card[] cards, int depth, short value)
        {
            var te = new TableEntry((Position)pos.Clone(), CardCache.GetIndex(cards), depth, value);
            int hashCode = te.GetHashCode();
            if (_PositionCache.ContainsKey(hashCode))
                return _PositionCache[hashCode].Eval;
            return 0;
        }

        public static bool Store(Position pos, Card[] cards, int depth, short value)
        {
            var te = new TableEntry((Position)pos.Clone(), CardCache.GetIndex(cards), depth, value);
            int hashCode = te.GetHashCode();
            if(_PositionCache.ContainsKey(hashCode))
            {
                te = _PositionCache[hashCode];
                if (te.Depth < depth)
                    return false; //notify no need to back search from a higher depth
                else
                {
                    //update
                    te = _PositionCache[hashCode];
                    te.Eval = value;
                    _PositionCache[hashCode] = te;
                    return true;
                }
            }
            else
            {
                _PositionCache.Add(hashCode, te);
                return true;
            }
        }

        private struct TableEntry
        {
            public Position Pos;
            public int CardCacheIndex;
            public int Depth;
            public short Eval;

            public TableEntry(Position p, int cardIdx, int d, short v)
            {
                Pos = p;
                CardCacheIndex = cardIdx;
                Depth = d;
                Eval = v;
            }
        }

        private class TEntryComparer : IEqualityComparer<TableEntry>
        {
            public bool Equals(TableEntry x, TableEntry y)
            {
                return x.CardCacheIndex == y.CardCacheIndex && x.Pos.Equals(y.Pos);
            }

            public int GetHashCode(TableEntry obj)
            {
                return (String.Join("|", obj.Pos.Board.Select(f => f.ToString())) + "|" + obj.CardCacheIndex.ToString()).GetHashCode();
            }
        }
    }
}
