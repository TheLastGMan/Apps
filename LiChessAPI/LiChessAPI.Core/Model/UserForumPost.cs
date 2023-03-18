using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserForumPost
    {
        public string topicUrl { get; set; } = String.Empty;
        public string topicName { get; set; } = String.Empty;
        public UserPost[] posts { get; set; } = new UserPost[] { };
    }
}
