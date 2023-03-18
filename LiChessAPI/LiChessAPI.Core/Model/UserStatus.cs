using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserStatus
    {
        public string id { get; set; } = String.Empty;
        public string name { get; set; } = String.Empty;
        public bool patron { get; set; }
        public bool online { get; set; }
        public bool playing { get; set; }
    }
}
