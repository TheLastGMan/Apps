using ChessCore.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    public class TBaseCacheEntryUtils : IComparer<TBaseCacheEntry>, IEqualityComparer<TBaseCacheEntry>
    {
        public int Compare(TBaseCacheEntry x, TBaseCacheEntry y)
        {
            //compare lengths
            if (x.Position.Length < y.Position.Length)
                return -1;
            if (x.Position.Length > y.Position.Length)
                return 1;

            //check position array
            for (int i = 0; i < x.Position.Length; i++)
            {
                int compareVal = x.Position[i].CompareTo(y.Position[i]);
                if (compareVal == 0)
                    continue;

                return compareVal;
            }

            //still equal, check move flag
            return x.BlackToMove.CompareTo(y.BlackToMove);
        }

        public bool Equals(TBaseCacheEntry x, TBaseCacheEntry y)
        {
            if (x.Position.Length != y.Position.Length)
                return false;

            for (int i = 0; i < x.Position.Length; i++)
                if (x.Position[i] != y.Position[i])
                    return false;

            return true;
        }

        public int GetHashCode(TBaseCacheEntry obj)
        {
            return (Encoding.ASCII.GetString(obj.Position) + (obj.BlackToMove ? "1" : "0")).GetHashCode();
        }
    }
}
