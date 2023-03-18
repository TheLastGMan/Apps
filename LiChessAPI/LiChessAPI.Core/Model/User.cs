using Newtonsoft.Json;
using System;

namespace LiChessAPI.Core.Model
{
    public class User
    {
        public string username { get; set; } = String.Empty;
        /// <summary>
        /// chess title like FM or LM (lichess master)
        /// </summary>
        public string title { get; set; } = String.Empty;
        public string url { get; set; } = String.Empty;
        /// <summary>
        /// is the player currently using lichess
        /// </summary>
        public bool online { get; set; }
        /// <summary>
        /// game being played, if any
        /// </summary>
        public string playing { get; set; } = String.Empty;
        /// <summary>
        /// true if user is known to use an engine
        /// </summary>
        public bool engine { get; set; }
        public string language { get; set; } = String.Empty;
        public Profile profile { get; set; } = new Profile();
        [JsonProperty("perfs")]
        public Performance performance { get; set; } = new Performance();
    }
}
