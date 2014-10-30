using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MagicDate
{
    static void Main(string[] args)
    {

        int startInput = int.Parse(Console.ReadLine());
        int endInput = int.Parse(Console.ReadLine());
        int magicWeight = int.Parse(Console.ReadLine());

        DateTime startDate = new DateTime(startInput, 1, 1);
        DateTime endDate = new DateTime(endInput, 12, 31);
        int count = 0;

        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1.0))
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            int d4Year = year % 10;
            int d3Year = (year / 10) % 10;
            int d2Year = (year / 100) % 10;
            int d1Year = (year / 1000) % 10;
            int d2Month = month % 10;
            int d1Month = (month / 10) % 10;
            int d2Day = day % 10;
            int d1Day = (day / 10) % 10;
            int sum =
            d1Day * d2Day + d1Day * d1Month + d1Day * d2Month + d1Day * d1Year +
            d1Day * d2Year + d1Day * d3Year + d1Day * d4Year + d2Day * d1Month +
            d2Day * d2Month + d2Day * d1Year + d2Day * d2Year + d2Day * d3Year +
            d2Day * d4Year + d1Month * d2Month + d1Month * d1Year + d1Month * d2Year +
            d1Month * d3Year + d1Month * d4Year + d2Month * d1Year + d2Month * d2Year +
            d2Month * d3Year + d2Month * d4Year + d1Year * d2Year + d1Year * d3Year +
            d1Year * d4Year + d2Year * d3Year + d2Year * d4Year + d3Year * d4Year;
            if (sum == magicWeight)
            {
                count++;
                Console.WriteLine("{0:00}-{1:00}-{2:00}", date.Day, date.Month, date.Year);
            }
        }
        if (count == 0)
        {
            Console.WriteLine("No");
        }
    }
}