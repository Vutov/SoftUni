namespace Scoreboard
{
    public class Game
    {
        public Game(string gameName, string password)
        {
            this.GameName = gameName;
            this.Password = password;
        }

        public string GameName { get; set; }

        public string Password { get; set; }
    }
}
