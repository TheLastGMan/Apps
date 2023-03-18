using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserCorrespondenceGame
    {
        public string id { get; set; } = String.Empty;
        public PlayerColor color { get; set; } = PlayerColor.unknown;
        public string url { get; set; } = String.Empty;
        public string variant { get; set; } = String.Empty;
        public string speed { get; set; } = String.Empty;
        public string perf { get; set; } = String.Empty;
        public bool rated { get; set; }
        public UserCorrespondenceOpponent opponent { get; set; } = new UserCorrespondenceOpponent();
    }
}
