using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Electricity
{
    static void Main(string[] args)
    {
        int floors = int.Parse(Console.ReadLine());
        int flatsPerFloor = int.Parse(Console.ReadLine());
        string inputTime = Console.ReadLine();
        int[] time = Array.ConvertAll(inputTime.Split(':'), int.Parse);
        DateTime currentTime = new DateTime(2000, 1, 1, time[0], time[1], 0);

        decimal lampWatts = 100.53M;
        decimal computerWatts = 125.9M;

        decimal totalWatts = 0;

        if (currentTime >= new DateTime(2000, 1, 1, 14, 0, 0) &&
            currentTime < new DateTime(2000, 1, 1, 19, 0, 0))
        {
            totalWatts += 2 * lampWatts + 2 * computerWatts;
        }
        else if ((currentTime >= new DateTime(2000, 1, 1, 19, 0, 0) &&
            currentTime < new DateTime(2000, 1, 2, 0, 0, 0)))
        {
            totalWatts += 7 * lampWatts + 6 * computerWatts;
        }
        else if ((currentTime >= new DateTime(2000, 1, 1, 0, 0, 0) &&
            currentTime < new DateTime(2000, 1, 1, 9, 0, 0)))
        {
            totalWatts += 1 * lampWatts + 8 * computerWatts;
        }
        totalWatts *= floors * flatsPerFloor;
        Console.WriteLine("{0} Watts", (int)totalWatts);
    }
}
