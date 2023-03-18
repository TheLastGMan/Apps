using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core
{
    public class AIMoveInfo
    {
        public Board Board = null;
        public List<MoveInfo> MoveHistory = new List<MoveInfo>();
        public MoveInfo Move
        {
            get { return MoveHistory.LastOrDefault(); }
        }

        public IEnumerable<MoveInfo> PreviousMoveHistory
        {
            get { return MoveHistory.Take(MoveHistory.Count - 1); }
        }

        public string MoveHistoryCSV
        {
            get { return String.Join(",", MoveHistory.Select(f => f.Column)); }
        }

        public string MoveHistoryPreviousNodeCSV
        {
            get { return String.Join(",", MoveHistory.Take(MoveHistory.Count - 1).Select(f => f.Column)); }
        }

        private int randId = -1;
        private int lastDepth = 0;
        public int RandomId(int max, int depth)
        {
            return (randId == -1 || lastDepth != depth) ? new Random().Next(max) : randId;
        }
    }
}
