using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Budget
{
    static void Main(string[] args)
    {
        int budget = int.Parse(Console.ReadLine());
        int goingOutDays = int.Parse(Console.ReadLine());
        int homeWeeks = int.Parse(Console.ReadLine());
        int rent = 150;
        int totalWeekDays = 30 - 2 * 4;//Without weekends;
        int normalDaysMoney = (totalWeekDays - goingOutDays) * 10;//When not going out;
        int goingOutMoneyPerDay = (int)(budget * 0.03d);
        int goingOutMoneyTotal = goingOutDays * goingOutMoneyPerDay + 10 * goingOutDays;
        int weekendsMoney = ((4 - homeWeeks) * 20) * 2;//2 weekend days in 1 week;
        int totalSpent = normalDaysMoney + weekendsMoney + goingOutMoneyTotal + rent;
        if (totalSpent > budget)
        {
            Console.WriteLine("No, not enough {0}.", Math.Abs(budget - totalSpent));
        }
        else if (totalSpent < budget)
        {
            Console.WriteLine("Yes, leftover {0}.", budget - totalSpent);
        }
        else
        {
            Console.WriteLine("Exact Budget.");
        }
    }
}