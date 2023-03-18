using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserGames
    {
        public UserGame blitz { get; set; } = new UserGame();
        public UserGame classical { get; set; } = new UserGame();
        public UserGame chess960 { get; set; } = new UserGame();
    }
}
