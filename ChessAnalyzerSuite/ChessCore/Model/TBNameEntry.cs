using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Model
{
    public class TBNameEntry
    {
        public Piece[] White { get; set; }
        public Piece[] Black { get; set; }
        public string PrettyPrint
        {
            get { return TBNameGenerator.PiecesToString(White) + TBNameGenerator.PiecesToString(Black); }
        }
    }
}
