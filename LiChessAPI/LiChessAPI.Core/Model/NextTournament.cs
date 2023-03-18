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
    public class NextTournament
    {
        [JsonProperty("finishesAt")]
        public DateTime? finishesAtUTC { get; set; }
        [JsonProperty("startsAt")]
        public DateTime? startsAtUTC { get; set; }
        public string id { get; set; } = String.Empty;
        [JsonProperty("nbPlayers")]
        public int numberOfPlayers { get; set; }
        public TournamentInfo perf { get; set; } = new TournamentInfo();

        public DateTimeOffset StartsAt
        {
            get { return new DateTimeOffset(startsAtUTC ?? new DateTime()); }
        }
        public DateTimeOffset FinishesAt
        {
            get { return new DateTimeOffset(finishesAtUTC ?? new DateTime()); }
        }
    }
}
