using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserInterval
    {
        public long start { get; set; }
        public long end { get; set; }

        [JsonIgnore]
        public DateTime Starts { get { return new DateTimeOffset(start.ToDateTimeSeconds()).LocalDateTime; } }
        [JsonIgnore]
        public DateTime Ends { get { return new DateTimeOffset(end.ToDateTimeSeconds()).LocalDateTime; } }
    }
}
