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
    public class TournamentDetail
    {
        public Clock clock { get; set; } = new Clock();
        public string createdBy { get; set; } = String.Empty;
        public string fullName { get; set; } = String.Empty;
        public string id { get; set; } = String.Empty;
        public bool isFinished { get; set; }
        public bool isStarted { get; set; }
        public int minutes { get; set; }
        [JsonProperty("nbPlayers")]
        public int numberOfPlayers { get; set; }
        public NextTournament next { get; set; } = new NextTournament();
        [JsonProperty("startsAt")]
        public DateTime startsAtUTC { get; set; }
        public string system { get; set; } = String.Empty;
        public string variant { get; set; } = String.Empty;
        //verdicts
        public Pairing[] pairings { get; set; } = new Pairing[] { };
        public TournamentInfo perf { get; set; } = new TournamentInfo();
        public Podium podium { get; set; } = new Podium();
        public Schedule schedule { get; set; } = new Schedule();
        //standing

        public DateTimeOffset StartsAt
        {
            get { return new DateTimeOffset(startsAtUTC); }
        }
    }
}
