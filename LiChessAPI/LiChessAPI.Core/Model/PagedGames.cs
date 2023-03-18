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
    public class PagedGames
    {
        public int currentPage { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int previousPage { get; set; }
        public int nextPage { get; set; }
        public int maxPerPage { get; set; }
        [JsonProperty("nbPages")]
        public int numberOfPages { get; set; }
        [JsonProperty("nbResults")]
        public int numberOfResults { get; set; }
        [JsonProperty("currentPageResults")]
        public Game[] Games { get; set; } = new Game[] { };
    }
}
