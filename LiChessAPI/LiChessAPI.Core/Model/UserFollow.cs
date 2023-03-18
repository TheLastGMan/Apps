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
    public class UserFollow
    {
        [JsonProperty("in")]
        public UserFollowInfo Followers { get; set; } = new UserFollowInfo();
        [JsonProperty("out")]
        public UserFollowInfo Follows { get; set; } = new UserFollowInfo();
    }
}
