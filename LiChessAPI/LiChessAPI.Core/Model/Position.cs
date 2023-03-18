using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class Position
    {
        public string eco { get; set; } = String.Empty;
        public string name { get; set; } = String.Empty;
        public string wikiPath { get; set; } = String.Empty;
        public string fen { get; set; } = String.Empty;
    }
}
