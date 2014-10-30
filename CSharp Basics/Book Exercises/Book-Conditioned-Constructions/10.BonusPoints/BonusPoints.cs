using System;

class BonusPoints
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the points:");
        int points = int.Parse(Console.ReadLine());
        if (points == 0 || points > 9)
        {
            throw new IndexOutOfRangeException("Allowed range is 1 to 9.");
		}
        else if (points >= 1 && points <= 3)
        {
            points *= 10;
        }
        else if (points >= 4 && points <= 6)
        {
            points *= 100;
        }
        else // 7, 8, 9
        {
            points *= 1000;
        }
        Console.WriteLine("New points : {0}.", points);
    }
}