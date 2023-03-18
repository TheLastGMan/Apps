using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class TournamentList
    {
        public Tournament[] created { get; set; } = new Tournament[] { };
        public Tournament[] started { get; set; } = new Tournament[] { };
        public Tournament[] finished { get; set; } = new Tournament[] { };
    }
}
