using System;

class Volleyball
{
    static void Main(string[] args)
    {
        string year = Console.ReadLine(); // leap or normal
        int p = int.Parse(Console.ReadLine()); // number of holidays in year
        int h = int.Parse(Console.ReadLine()); // times in hometown
        float numGames = (p * 2f / 3f) + ((48 - h) * 3f / 4f) + h;
        // 2/3 of holidays + 3/4 of normal days + homedays
        if (year == "leap")
        {
            numGames *= 1.15f;
        }
        Console.WriteLine((int)numGames);
    }
}