using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Diamonds
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        char dash = '-';
        char star = '*';
        int outerDash = size / 2;
        int innerDash = 1;

        Console.WriteLine("{0}{1}{0}", new string(dash, outerDash), star);
        outerDash--;
        int innerSize = size - 2;
        for (int i = 0; i <= innerSize / 2; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}",
            new string(dash, outerDash), star, new string(dash, innerDash));
            outerDash--;
            innerDash += 2;
        }
        outerDash = 1;
        innerDash = size - 4; // 2 stars and 2 dashes;
        for (int i = 0; i < innerSize / 2; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}",
            new string(dash, outerDash), star, new string(dash, innerDash));
            outerDash++;
            innerDash -= 2;
        }
        outerDash = size / 2;
        Console.WriteLine("{0}{1}{0}", new string(dash, outerDash), star);
    }
}
