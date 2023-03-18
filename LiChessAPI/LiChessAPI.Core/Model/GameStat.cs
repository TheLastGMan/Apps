using Newtonsoft.Json;

namespace LiChessAPI.Core.Model
{
    public class GameStat
    {
        /// <summary>
        /// number of rated games played
        /// </summary>
        public int games { get; set; }
        /// <summary>
        /// Glicko2 rating
        /// </summary>
        public short rating { get; set; }
        /// <summary>
        /// Glicko2 rating deviation
        /// </summary>
        [JsonProperty("rd")]
        public short ratingDeviation { get; set; }
        /// <summary>
        /// progress over the last 12 games
        /// </summary>
        [JsonProperty("prog")]
        public short progress { get; set; }
    }
}
