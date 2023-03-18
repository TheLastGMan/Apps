using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingLoader
{
    public class ReadingResult
    {
        public string Header { get; set; } = string.Empty;
        public string Verse { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool Found { get; set; }
    }
}
