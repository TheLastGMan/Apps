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
    public class Game
    {
        public string id { get; set; } = String.Empty;
        public string initialFen { get; set; } = String.Empty; // with_fens flag
        public string variant { get; set; } = String.Empty; //standard/chess960/fromPosition/kingOfTheHill/threeCheck
        public string speed { get; set; } = String.Empty; //bullet/blitz/classical/unlimited
        public string perf { get; set; } = String.Empty; //bullet/blitz/classical/chess960/kingOfTheHill/threeCheck
        public bool rated { get; set; }
        public string status { get; set; } = String.Empty;
        public Clock clock { get; set; } = new Clock();
        [JsonProperty("createdAt")]
        public long createdAtEpochMilliseconds { get; set; }
        [JsonProperty("lastMoveAt")]
        public long lastMoveAtEpochMilliseconds { get; set; }
        public short turns { get; set; }
        [JsonProperty("color")]
        public PlayerColor colorToMove { get; set; } = PlayerColor.unknown;
        public string url { get; set; } = String.Empty;
        public PlayerColor winner { get; set; } = PlayerColor.unknown;
        public GamePlayers players { get; set; } = new GamePlayers();
        public AnalysisInfo[] analysis { get; set; } = new AnalysisInfo[] { }; //(with_anlysis flag)
        public string moves { get; set; } = "N/A"; //with_moves flag
        public GameOpening opening { get; set; } = new GameOpening(); //(with_opening flag)
        public string[] fens { get; set; } = new string[] { }; //(with_fens) flag

        private static readonly DateTime _Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public DateTime CreatedAt
        {
            get { return new DateTimeOffset(_Epoch.AddMilliseconds(createdAtEpochMilliseconds)).LocalDateTime; }
        }
        public DateTime LastMoveAt
        {
            get { return new DateTimeOffset(_Epoch.AddMilliseconds(lastMoveAtEpochMilliseconds)).LocalDateTime; }
        }
    }
}
