using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class Profile
    {
        public string bio { get; set; } = String.Empty;
        public string country { get; set; } = String.Empty;
        public string firstName { get; set; } = String.Empty;
        public string lastName { get; set; } = String.Empty;
        public string location { get; set; } = String.Empty;
    }
}
