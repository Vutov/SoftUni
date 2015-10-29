namespace Scoreboard
{
    using System;

    class ProgramMain
    {
        static void Main(string[] args)
        {
            var game = new GameCollection();
            var line = Console.ReadLine();

            while (line != "End")
            {
                var tokens = line.Split(' ');
                if (tokens.Length == 0)
                {
                    continue;
                }

                var command = tokens[0];
                switch (command)
                {
                    case "RegisterUser":
                        game.RegisterUser(tokens[1], tokens[2]);
                        break;
                    case "RegisterGame":
                        game.RegisterGame(tokens[1], tokens[2]);
                        break;
                    case "AddScore":
                        game.AddScore(tokens[1], tokens[2], tokens[3], tokens[4], int.Parse(tokens[5]));
                        break;
                    case "ShowScoreboard":
                        game.ShowScoreboard(tokens[1]);
                        break;
                    case "DeleteGame":
                        game.DeleteGame(tokens[1], tokens[2]);
                        break;
                    case "ListGamesByPrefix":
                        game.GameByPrefix(tokens[1]);
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}

namespace Scoreboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class GameCollection
    {
        private int nextNumber = 0;

        private Dictionary<string, string> usersByUsername;
        private Dictionary<string, string> gamesByName;
        private Dictionary<string, SortedSet<Score>> scoreboard;
        private OrderedSet<string> prefixes;

        public GameCollection()
        {
            this.usersByUsername = new Dictionary<string, string>();
            this.gamesByName = new Dictionary<string, string>();
            this.scoreboard = new Dictionary<string, SortedSet<Score>>();
            this.prefixes = new OrderedSet<string>();
        }

        public void RegisterUser(string username, string password)
        {
            if (this.usersByUsername.ContainsKey(username))
            {
                Console.WriteLine("Duplicated user");
                return;
            }

            this.usersByUsername.Add(username, password);
            Console.WriteLine("User registered");
        }

        public void RegisterGame(string gamename, string password)
        {
            if (this.gamesByName.ContainsKey(gamename))
            {
                Console.WriteLine("Duplicated game");
                return;
            }

            this.gamesByName.Add(gamename, password);
            this.scoreboard.Add(gamename, new SortedSet<Score>());
            this.prefixes.Add(gamename);
            Console.WriteLine("Game registered");
        }

        public void AddScore(string username, string userPassword, string gamename,
            string gamePassword, int score)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                Console.WriteLine("Cannot add score");
                return;
            }

            if (this.usersByUsername[username] != userPassword)
            {
                Console.WriteLine("Cannot add score");
                return;
            }

            if (!this.gamesByName.ContainsKey(gamename))
            {
                Console.WriteLine("Cannot add score");
                return;
            }

            if (this.gamesByName[gamename] != gamePassword)
            {
                Console.WriteLine("Cannot add score");
                return;
            }

            var currentScore = new Score(username, score, this.nextNumber);
            this.nextNumber++;
            this.scoreboard[gamename].Add(currentScore);
            Console.WriteLine("Score added");
        }

        public void ShowScoreboard(string gameName)
        {
            if (!this.gamesByName.ContainsKey(gameName))
            {
                Console.WriteLine("Game not found");
                return;
            }

            var scoreboardLen = this.scoreboard[gameName].Count;
            if (scoreboardLen == 0)
            {
                Console.WriteLine("No score");
                return;
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
                Console.WriteLine("Cannot delete game");
                return;
            }

            if (this.gamesByName[gameName] != gamePassword)
            {
                Console.WriteLine("Cannot delete game");
                return;
            }

            this.gamesByName.Remove(gameName);
            this.scoreboard.Remove(gameName);
            this.prefixes.Remove(gameName);
            Console.WriteLine("Game deleted");
        }

        public void GameByPrefix(string prefix)
        {
            var foundGames = this.prefixes
                .Range(prefix, true, prefix + "z", false)
            .Where(g => g.StartsWith(prefix)).Take(10);
            if (!foundGames.Any())
            {
                Console.WriteLine("No matches");
                return;
            }

            Console.WriteLine(string.Join(", ", foundGames));
        }
    }
}
namespace Scoreboard
{
    using System;

    public class Score : IComparable<Score>
    {
        public Score(string username, int scorePoint, int nextNumber)
        {
            this.Username = username;
            this.ScorePoint = scorePoint;
            this.UniqueNumber = nextNumber;
        }

        public string Username { get; set; }

        public int ScorePoint { get; set; }

        public int UniqueNumber { get; set; }

        public int CompareTo(Score other)
        {
            if (this.ScorePoint != other.ScorePoint)
            {
                return other.ScorePoint.CompareTo(this.ScorePoint);
            }

            if (this.Username != other.Username)
            {
                return string.CompareOrdinal(this.Username, other.Username);
            }

            return this.UniqueNumber.CompareTo(other.UniqueNumber);
        }
    }
}