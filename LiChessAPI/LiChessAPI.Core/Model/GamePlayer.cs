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
    public class GamePlayer
    {
        public string userId { get; set; } = String.Empty;
        public string name { get; set; } = String.Empty;
        public string rating { get; set; } = String.Empty;
        public string ratingDiff { get; set; } = String.Empty;
        public GamePlayerAnalysis analysis { get; set; } = new GamePlayerAnalysis();

        [JsonProperty("moveCentis")]
        public int[] moveTimeCentiSeconds { get; set; } = new int[] { };
    }
}
