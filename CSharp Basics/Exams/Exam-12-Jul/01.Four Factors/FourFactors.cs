namespace _01.Four_Factors
{
    using System;

    public class FourFactors
    {
        public static void Main(string[] args)
        {
            long fieldGoals = long.Parse(Console.ReadLine());
            long fieldGoalAttemps = long.Parse(Console.ReadLine());
            long treePointGoals = long.Parse(Console.ReadLine());
            long turnovers = long.Parse(Console.ReadLine());
            long offensiveRebounds = long.Parse(Console.ReadLine());
            long opponentDefRebounds = long.Parse(Console.ReadLine());
            long freeThrows = long.Parse(Console.ReadLine());
            long freeThrowAttempts = long.Parse(Console.ReadLine());

            double shootingFactor = (fieldGoals + (0.5d * treePointGoals)) / fieldGoalAttemps;
            double turnoverFactor = turnovers / (fieldGoalAttemps + (0.44d * freeThrowAttempts) + turnovers);
            double reboundFactor = offensiveRebounds / (double)(offensiveRebounds + opponentDefRebounds);
            double freeThrowFactor = freeThrows / (double)fieldGoalAttemps;

            Console.WriteLine("eFG% {0:F3}", shootingFactor);
            Console.WriteLine("TOV% {0:F3}", turnoverFactor);
            Console.WriteLine("ORB% {0:F3}", reboundFactor);
            Console.WriteLine("FT% {0:F3}", freeThrowFactor);
        }
    }
}
