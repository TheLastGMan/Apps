using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserCorrespondenceOpponent
    {
        public string user { get; set; }
        public int rating { get; set; }
    }
}
