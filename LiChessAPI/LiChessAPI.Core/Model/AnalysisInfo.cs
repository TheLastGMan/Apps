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
    public class AnalysisInfo
    {
        [JsonProperty("eval")]
        public string centiPawnEval { get; set; } = String.Empty;
        public string move { get; set; } = String.Empty;
        public string variation { get; set; } = String.Empty;
    }
}
