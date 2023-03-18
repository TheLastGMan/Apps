using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiChessAPI.Core;

namespace LiChessAPI.Core.Model
{
    public class Tournament
    {
        public string id { get; set; } = String.Empty;
        public string createdBy { get; set; } = String.Empty;
        public string system { get; set; } = String.Empty;
        public int minutes { get; set; }
        public Clock clock { get; set; } = new Clock();
        public bool rated { get; set; }
        public string fullName { get; set; } = String.Empty;
        [JsonProperty("nbPlayers")]
        public int numberOfPlayers { get; set; }
        [JsonProperty("private")]
        public bool isPrivate { get; set; }
        public Variant variant { get; set; }
        public int secondsToStart { get; set; }
        [JsonProperty("startsAt")]
        public long startAtEpochMilliseconds { get; set; }
        [JsonProperty("finishesAt")]
        public long finishesAsEpochMilliseconds { get; set; }
        public string status { get; set; } = String.Empty;
        public Position position { get; set; } = new Position();
        public Schedule schedule { get; set; } = new Schedule();
        public Winner winner { get; set; } = new Winner();
        public TournamentInfo perf { get; set; } = new TournamentInfo();

        [JsonIgnore]
        public DateTimeOffset StartsAt { get { return new DateTimeOffset(startAtEpochMilliseconds.ToDateTimeMilliseconds()); } }
        [JsonIgnore]
        public DateTimeOffset FinishedAt { get { return new DateTimeOffset(finishesAsEpochMilliseconds.ToDateTimeMilliseconds()); } }
    }
}
