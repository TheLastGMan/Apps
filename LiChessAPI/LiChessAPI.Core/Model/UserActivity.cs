using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserActivity
    {
        public UserInterval interval { get; set; } = new UserInterval();
        public UserGames games { get; set; } = new UserGames();
        public UserGame puzzles { get; set; } = new UserGame();
        public UserTournaments tournaments { get; set; } = new UserTournaments();
        public UserCorrespondenceMoves correspondenceMoves { get; set; } = new UserCorrespondenceMoves();
        public UserFollow follows { get; set; } = new UserFollow();
        public UserForumPost[] posts { get; set; } = new UserForumPost[] { };
    }
}
