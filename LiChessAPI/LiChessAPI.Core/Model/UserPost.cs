using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserPost
    {
        public string url { get; set; } = String.Empty;
        public string text { get; set; } = String.Empty;
    }
}
