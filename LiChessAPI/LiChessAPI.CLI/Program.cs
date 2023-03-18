using LiChessAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new API("https://www.lichess.org");
            //var user = api.GetUser("pepse25a");
            //System.Threading.Thread.Sleep(1500);
            //var user1 = api.GetUser("pepse25");
            //System.Threading.Thread.Sleep(1500);
            //var pepse25aGames = api.UserGames("pepse25", 2);
            //var tournaments = api.Tournaments(); //8c1NQLAT
            //var tournament = api.GetTournament("8c1NQLAT");
            //var activity = api.UserActivity("sparklehorse");
        }
    }
}
