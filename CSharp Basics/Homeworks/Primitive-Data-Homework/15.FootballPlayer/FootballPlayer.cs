using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class FootballPlayer
    {
        static void Main(string[] args)
        {
            string leap = Console.ReadLine();
            //if (leap != "t" && leap != "f")
            //{
            //    throw new ArgumentOutOfRangeException("Only t or f are accepted as input");
            //}
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int weekends = 52;
            int footballCount;
            int holidayCount = p / 2; // half of the holidays he will be playing
            int normalCount = weekends - h; // gets "normal" days
            int notTired = normalCount * 2 / 3; // the ones he will be playing
            footballCount = holidayCount + notTired + h; // finall count with homedays
            if (leap == "t") // if leap
            {
                footballCount += 3;
            }
            Console.WriteLine(footballCount);
        }
    }