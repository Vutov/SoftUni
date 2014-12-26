using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PiggyBank
{
    static void Main(string[] args)
    {
        int tankPrice = int.Parse(Console.ReadLine());
        int partyDays = int.Parse(Console.ReadLine());

        int monthDays = 30;
        int yearMonths = 12;
        int normalDays = monthDays - partyDays;
        double savedMoney = normalDays * 2d - (partyDays * 5d);
        if (savedMoney > 0)
        {
            double totalMonths = tankPrice / savedMoney;
            double neededMonths = Math.Ceiling(totalMonths % yearMonths);
            int neededYears = (int)(totalMonths / yearMonths);
            if (neededMonths == 12)
            {
                neededMonths = 0;
                neededYears++;
            }
            Console.WriteLine("{0} years, {1} months", neededYears, neededMonths);
        }
        else
        {
            Console.WriteLine("never");
        }



    }
}
