using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class GamePlayers
    {
        public GamePlayer white { get; set; } = new GamePlayer();
        public GamePlayer black { get; set; } = new GamePlayer();
    }
}
