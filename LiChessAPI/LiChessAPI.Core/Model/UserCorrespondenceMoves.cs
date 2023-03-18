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
    public class UserCorrespondenceMoves
    {
        [JsonProperty("nb")]
        public int Count { get; set; }
        public UserCorrespondenceGame[] games { get; set; } = new UserCorrespondenceGame[] { };
    }
}
