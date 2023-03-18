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
    public class Podium
    {
        public string name { get; set; } = String.Empty;
        public int rank { get; set; }
        public int rating { get; set; }
        public int score { get; set; }
        public int ratingDiff { get; set; }
        public TournamentSheet sheet { get; set; } = new TournamentSheet();
        [JsonProperty("nb")]
        public PodiumInfo info { get; set; } = new PodiumInfo();
        public int performance { get; set; }
    }
}
