using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LiChessAPI.Core.Model
{
    public class TournamentSheet
    {
        //public List<int[]> scores { get; set; } = new List<int[]>();
        [JsonProperty("game")]
        public int gameCount { get; set; }
        public bool fire { get; set; }
    }
}
