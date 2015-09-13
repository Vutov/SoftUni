using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    using Wintellect.PowerCollections;

    public class GameCollection
    {
        private int nextNumber = 0;

        private Dictionary<string, User> usersByUsername;
        private Dictionary<string, Game> gamesByName;
        private Dictionary<string, SortedSet<Score>> scoreboard;
        private BigList<string> prefixes;

        public GameCollection()
        {
            this.usersByUsername = new Dictionary<string, User>();
            this.gamesByName = new Dictionary<string, Game>();
            this.scoreboard = new Dictionary<string, SortedSet<Score>>();
            this.prefixes = new BigList<string>();
        }

        public void RegisterUser(string username, string password)
        {
            if (this.usersByUsername.ContainsKey(username))
            {
                throw new InvalidOperationException("Duplicated user");
            }

            var user = new User(username, password);
            this.usersByUsername.Add(username, user);
        }

        public void RegisterGame(string gamename, string password)
        {
            if (this.gamesByName.ContainsKey(gamename))
            {
                throw new InvalidOperationException("Duplicated game");
            }

            var game = new Game(gamename, password);
            this.gamesByName.Add(gamename, game);
            this.scoreboard.Add(gamename, new SortedSet<Score>());
            this.prefixes.Add(gamename);
        }

        public void AddScore(string username, string userPassword, string gamename,
            string gamePassword, int score)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                throw new InvalidOperationException("Cannot add score");
            }

            if (this.usersByUsername[username].Password != userPassword)
            {
                throw new InvalidOperationException("Cannot add score");
            }

            if (!this.gamesByName.ContainsKey(gamename))
            {
                throw new InvalidOperationException("Cannot add score");
            }

            if (this.gamesByName[gamename].Password != gamePassword)
            {
                throw new InvalidOperationException("Cannot add score");
            }

            var currentScore = new Score(username, score, this.nextNumber);
            this.nextNumber++;
            this.scoreboard[gamename].Add(currentScore);
        }

        public void ShowScoreboard(string gameName)
        {
            if (!this.gamesByName.ContainsKey(gameName))
            {
                throw new InvalidOperationException("Game not found");
            }

            var scoreboardLen = this.scoreboard[gameName].Count;
            if (scoreboardLen == 0)
            {
                throw new InvalidOperationException("No score");
            }

            var gameScoreBoard = this.scoreboard[gameName];
            if (scoreboardLen > 10)
            {
                scoreboardLen = 10;
            }

            int number = 1;
            foreach (var score in gameScoreBoard)
            {
                Console.WriteLine("#{0} {1} {2}", number, score.Username, score.ScorePoint);
                number++;
                scoreboardLen--;
                if (scoreboardLen <= 0)
                {
                    break;
                }
            }
        }

        public void DeleteGame(string gameName, string gamePassword)
        {
            if (!this.gamesByName.ContainsKey(gameName))
            {
                throw new InvalidOperationException("Cannot delete game");
            }

            if (this.gamesByName[gameName].Password != gamePassword)
            {
                throw new InvalidOperationException("Cannot delete game");
            }

            this.gamesByName.Remove(gameName);
            this.scoreboard.Remove(gameName);
            this.prefixes.Remove(gameName);
        }

        public void GameByPrefix(string prefix)
        {
            var foundGames = this.prefixes.FindAll(p => p.StartsWith(prefix)).Take(10).OrderBy(g => g);
            if (!foundGames.Any())
            {
                throw new InvalidOperationException("No matches");
            }

            Console.WriteLine(string.Join(", ", foundGames));
        }
    }
}
