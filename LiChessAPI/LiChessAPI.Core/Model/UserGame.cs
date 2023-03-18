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
    public class UserGame
    {
        public int win { get; set; }
        public int loss { get; set; }
        public int draw { get; set; }
        [JsonProperty("rp")]
        public UserRatingPoint RatingInfo { get; set; } = new UserRatingPoint();
    }
}
