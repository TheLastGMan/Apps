using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core
{
    public static class Epoch
    {
        private static readonly DateTime _Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTimeMilliseconds(this long ms)
        {
            return _Epoch.AddMilliseconds(ms);
        }

        public static DateTime ToDateTimeSeconds(this long s)
        {
            return _Epoch.AddSeconds(s);
        }
    }
}
