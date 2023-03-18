using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core
{
    public class AIMoveSummary
    {
        public AIMoveState State = AIMoveState.TIE;
        public MoveInfo[] MoveHistory = new MoveInfo[18];
        public MoveInfo Move
        {
            get { return MoveHistory[0]; }
        }
    }
}
