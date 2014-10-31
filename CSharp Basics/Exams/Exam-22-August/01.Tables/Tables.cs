using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tables
{
    static void Main(string[] args)
    {
        long bundle1 = long.Parse(Console.ReadLine());
        long bundle2 = long.Parse(Console.ReadLine());
        long bundle3 = long.Parse(Console.ReadLine());
        long bundle4 = long.Parse(Console.ReadLine());
        long totalLegs = bundle1 + 2 * bundle2 + 3 * bundle3 + 4 * bundle4;
        long tops = long.Parse(Console.ReadLine());
        long tablesToBeMade = long.Parse(Console.ReadLine());

        long tablesMade = Math.Min((totalLegs / 4), tops);
        long tablesleft = tablesMade - tablesToBeMade;
        long legsNeeded = totalLegs - tablesToBeMade * 4;
        if (tablesMade < tablesToBeMade)
        {
            if (legsNeeded > 0)
            {
                legsNeeded = 0;
            }
            Console.WriteLine("less: {0}", tablesleft);
            Console.WriteLine("tops needed: {0}, legs needed: {1}",
                Math.Abs(tops - tablesToBeMade),
                Math.Abs(legsNeeded));
        }
        else if (tablesMade > tablesToBeMade)
        {
            Console.WriteLine("more: {0}", Math.Abs(tablesMade - tablesToBeMade));
            Console.WriteLine("tops left: {0}, legs left: {1}",
                Math.Abs(tops - tablesToBeMade),
                Math.Abs(legsNeeded));
        }
        else
        {
            Console.WriteLine("Just enough tables made: {0}", tablesMade);
        }
        
    }
}