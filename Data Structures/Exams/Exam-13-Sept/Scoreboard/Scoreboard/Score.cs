namespace Scoreboard
{
    using System;

    public class Score: IComparable<Score>
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
