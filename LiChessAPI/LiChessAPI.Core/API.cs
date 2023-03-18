using LiChessAPI.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core
{
    public class API
    {
        private readonly string _BaseURL;

        public API(string baseURL)
        {
            _BaseURL = baseURL;
        }

        private static bool deserializeJSON<T>(string data, out T parsed)
        {
            try
            {
                parsed = JsonConvert.DeserializeObject<T>(data);
                return true;
            }
            catch (Exception ex)
            {
                parsed = default(T);
                return false;
            }
        }

        private bool makeRequest(string action, IDictionary<string, string> parameters, out string result)
        {
            string url = $"{ _BaseURL }/api/{ action }{ (parameters != null ? $"?{ String.Join("&", parameters.Select(f => $"{ f.Key }={ f.Value }").ToArray()) }" : "") }";
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.UserAgent = "LiChess API Client";
            using (HttpWebResponse resp = (HttpWebResponse)webReq.GetResponse())
            {
                result = String.Empty;
                if ((int)resp.StatusCode == 429)
                    return false;

                var dataStream = resp.GetResponseStream();
                using (var sr = new StreamReader(dataStream))
                    result = sr.ReadToEnd();

                return true;
            }
        }

        private string boolToString(bool value)
        {
            return value ? "1" : "0";
        }

        public User GetUser(string userName)
        {
            string content;
            makeRequest($"user/{ userName }", null, out content);
            User user;
            deserializeJSON(content, out user);
            return user;
        }

        public PagedUser GetTeam(string team, int usersPerPage = 10, int page = 1)
        {
            string content;
            makeRequest($"user", new Dictionary<string, string>() { { "team", team }, { "nb", usersPerPage.ToString() }, { "page", page.ToString() } }, out content);
            PagedUser users;
            deserializeJSON(content, out users);
            return users;
        }

        public UserStatus[] UserStatuses(string[] users)
        {
            string content;
            makeRequest($"users/status", new Dictionary<string, string>() { { "ids", String.Join(",", users) } }, out content);
            UserStatus[] userStatuses;
            deserializeJSON(content, out userStatuses);
            return userStatuses;
        }

        public UserActivity[] UserActivity(string userName)
        {
            string content;
            makeRequest($"user/{ userName }/activity", null, out content);
            UserActivity[] activity;
            deserializeJSON(content, out activity);
            return activity;
        }

        public PagedGames UserGames(string userName, int gamesPerPage = 10, int page = 1, bool withAnalysis = true, bool withMoves = true, bool withOpening = true, bool withMoveTimes = true, bool onlyRated = false, bool inProgress = false)
        {
            string content;
            makeRequest($"user/{ userName }/games", new Dictionary<string, string>()
            {
                { "nb", gamesPerPage.ToString() },
                { "page", page.ToString() },
                { "with_analysis", boolToString(withAnalysis) },
                { "with_moves", boolToString(withMoves) },
                { "with_opening", boolToString(withOpening) },
                { "with_movetimes", boolToString(withMoveTimes) },
                { "rated", boolToString(onlyRated) },
                { "playing", boolToString(inProgress) }
            }, out content);
            PagedGames games;
            deserializeJSON(content, out games);
            return games;
        }

        public PagedGames UserGamesBetween(string userName, string opponentUserName, int gamesPerPage = 10, int page = 1, bool withAnalysis = true, bool withMoves = true, bool withOpening = true, bool withMoveTimes = true, bool onlyRated = false, bool inProgress = false)
        {
            string content;
            makeRequest($"games/vs/{ userName }/{ opponentUserName }", new Dictionary<string, string>()
            {
                { "nb", gamesPerPage.ToString() },
                { "page", page.ToString() },
                { "with_analysis", boolToString(withAnalysis) },
                { "with_moves", boolToString(withMoves) },
                { "with_opening", boolToString(withOpening) },
                { "with_movetimes", boolToString(withMoveTimes) },
                { "rated", boolToString(onlyRated) },
                { "playing", boolToString(inProgress) }
            }, out content);
            PagedGames games;
            deserializeJSON(content, out games);
            return games;
        }

        public PagedGames TeamGames(string teamName, int gamesPerPage = 10, int page = 1, bool withAnalysis = true, bool withMoves = true, bool withOpening = true, bool withMoveTimes = true, bool onlyRated = false, bool inProgress = false)
        {
            string content;
            makeRequest($"games/team/{ teamName }", new Dictionary<string, string>()
            {
                { "nb", gamesPerPage.ToString() },
                { "page", page.ToString() },
                { "with_analysis", boolToString(withAnalysis) },
                { "with_moves", boolToString(withMoves) },
                { "with_opening", boolToString(withOpening) },
                { "with_movetimes", boolToString(withMoveTimes) },
                { "rated", boolToString(onlyRated) },
                { "playing", boolToString(inProgress) }
            }, out content);
            PagedGames games;
            deserializeJSON(content, out games);
            return games;
        }

        public Game GetGame(string id, bool withAnalysis = true, bool withMoves = true, bool withOpening = true, bool withMoveTimes = true, bool withFenCode = true)
        {
            string content;
            makeRequest($"game/{ id }", new Dictionary<string, string>()
            {
                { "with_analysis", boolToString(withAnalysis) },
                { "with_moves", boolToString(withMoves) },
                { "with_opening", boolToString(withOpening) },
                { "with_movetimes", boolToString(withMoveTimes) },
                { "with_fens", boolToString(withFenCode) }
            }, out content);
            Game game;
            deserializeJSON(content, out game);
            return game;
        }

        public string GamePGN(string id)
        {
            string content;
            makeRequest($"game/export/{ id }.pgn", null, out content);
            return content;
        }

        public TournamentList Tournaments()
        {
            string content;
            makeRequest("tournament", null, out content);
            TournamentList tourneys;
            deserializeJSON(content, out tourneys);
            return tourneys;
        }

        public TournamentDetail GetTournament(string id, int standingsPage = 1)
        {
            string content;
            makeRequest($"tournament/{ id }", new Dictionary<string, string>() { { "page", standingsPage.ToString() } }, out content);
            TournamentDetail tourneyDetails;
            deserializeJSON(content, out tourneyDetails);
            return tourneyDetails;
        }
    }
}
