namespace Application2.Core
{
    public class Score
    {
        public Score()
        {
            this.CurrentScore = 0;
        }

        public Score(string name, int currentScore)
        {
            this.PlayerName = name;
            this.CurrentScore = currentScore;
        }

        public string PlayerName { get; set; }

        public int CurrentScore { get; set; }
    }
}
