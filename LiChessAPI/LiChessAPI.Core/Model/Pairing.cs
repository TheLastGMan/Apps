using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class Pairing
    {
        public string id { get; set; } = String.Empty;
        public string s { get; set; } = String.Empty;
        public string[] u { get; set; } = new string[2];
    }
}
