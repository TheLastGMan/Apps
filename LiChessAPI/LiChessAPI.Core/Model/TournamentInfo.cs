using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class TournamentInfo
    {
        public string icon { get; set; } = String.Empty;
        public string key { get; set; } = String.Empty;
        public string name { get; set; } = String.Empty;
    }
}
