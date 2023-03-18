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
    public class UserTournament
    {
        public UserTournamentInfo tournament { get; set; } = new UserTournamentInfo();
        [JsonProperty("nbGames")]
        public int GameCount { get; set; }
        public int score { get; set; }
        public int rank { get; set; }
        public int rankPercent { get; set; }
    }
}
