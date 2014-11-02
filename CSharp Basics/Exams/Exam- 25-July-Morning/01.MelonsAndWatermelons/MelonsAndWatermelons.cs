using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MelonsAndWatermelons
{
    static void Main(string[] args)
    {
        int startingDay = int.Parse(Console.ReadLine());
        int totalDays = int.Parse(Console.ReadLine());

        int wholeWeeks = totalDays / 7;
        int remainingDays = totalDays % 7;
        int watermelonsCount = wholeWeeks * 7;
        int melonsCount = wholeWeeks * 7;

        for (int startDay = startingDay; startDay < remainingDays + startingDay; startDay++)
        {
            int currentDay = startDay % 7;
            switch (currentDay)
            {
                case 1: watermelonsCount++; break; //Monday
                case 2: melonsCount += 2; break; //Tuesday
                case 3: watermelonsCount++; melonsCount++; break; //Wednesday
                case 4: watermelonsCount += 2; break; //Thursday
                case 5: watermelonsCount += 2; melonsCount += 2; break; //Friday
                case 6: watermelonsCount++; melonsCount += 2; break; //Saturday
                //0 is Sunday - nothing happens then;
            }
        }
        if (melonsCount < watermelonsCount)
        {
            Console.WriteLine("{0} more watermelons", watermelonsCount - melonsCount);
        }
        else if (melonsCount > watermelonsCount)
        {
            Console.WriteLine("{0} more melons", melonsCount - watermelonsCount);
        }
        else
        {
            Console.WriteLine("Equal amount: {0}", melonsCount);
        }
    }
}
