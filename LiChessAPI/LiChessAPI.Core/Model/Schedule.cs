using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class Schedule
    {
        public string freq { get; set; } = String.Empty;
        public string speed { get; set; } = String.Empty;
    }
}
