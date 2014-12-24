using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Headphones
{
    static void Main(string[] args)
    {
        int diameter = int.Parse(Console.ReadLine());

        int width = 2 * diameter + 1;
        char dash = '-';
        char star = '*';
        int outterDash = diameter / 2;
        int innerDash = diameter;
        int innerStar = 1;

        Console.WriteLine("{0}{1}{0}", new string(dash, outterDash), new string(star, diameter + 2));
        for (int i = 0; i < diameter - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string(dash, outterDash), new string(dash, innerDash));
        }
        for (int i = 0; i < diameter; i++)
        {
            if (i < diameter / 2)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string(dash, outterDash), new string(star, innerStar), new string(dash, innerDash));
                outterDash--;
                innerStar += 2;
                innerDash -= 2;
            }
            else
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string(dash, outterDash), new string(star, innerStar), new string(dash, innerDash));
                outterDash++;
                innerStar -= 2;
                innerDash += 2;
            }
        }
    }
}
