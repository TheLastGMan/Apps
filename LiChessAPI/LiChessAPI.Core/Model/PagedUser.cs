using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class PagedUser
    {
        public int currentPage { get; set; }
        public int previousPage { get; set; }
        public int nextPage { get; set; }
        public int maxPerPage { get; set; }
        [JsonProperty("nbPages")]
        public int numberOfPages { get; set; }
        [JsonProperty("nbResults")]
        public int numberOfResults { get; set; }
        [JsonProperty("currentPageResults")]
        public User[] Users { get; set; } = new User[] { };
    }
}
