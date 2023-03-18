using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class Clock
    {
        /// <summary>
        /// same as initial?
        /// </summary>
        public int limit { get; set; }
        /// <summary>
        /// Initial Time (in seconds)
        /// </summary>
        public int initial { get; set; }
        /// <summary>
        /// Increment Time (in seconds)
        /// </summary>
        public int increment { get; set; }
        /// <summary>
        /// Total Time Estimate (initial + 40 * increment)
        /// </summary>
        public int totalTime { get; set; }
    }
}
