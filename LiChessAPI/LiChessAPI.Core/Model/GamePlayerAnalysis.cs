using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class GamePlayerAnalysis
    {
        public int blunder { get; set; }
        public int inaccuracy { get; set; }
        public int mistake { get; set; }
    }
}
