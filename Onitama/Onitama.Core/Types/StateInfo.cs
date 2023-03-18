using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class StateInfo
    {
        public MoveExt MoveInfo;
        public StateInfo Previous;
        public short Value;
    }
}
