using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TravellerBob
{
    static void Main(string[] args)
    {
        string year = Console.ReadLine();
        int contractMonths = int.Parse(Console.ReadLine());
        int familyMonths = int.Parse(Console.ReadLine());

        int weeksPerMonth = 4;
        double contractTravels = contractMonths * (weeksPerMonth * 3);
        //Console.WriteLine(contractTravels);
        double familyTravels = familyMonths * 4; //2 weeks with 3 - 1 travels;
        //Console.WriteLine(familyTravels);
        double normalTravels = (12 - contractMonths - familyMonths) * (12 * 3 / 5d);
        //Console.WriteLine(normalTravels);
        double totalTravels = contractTravels + familyTravels + normalTravels;
        if (year == "leap")
        {
            totalTravels *= 1.05d;
        }

        Console.WriteLine((int) totalTravels);
    }
}
