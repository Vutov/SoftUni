using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ConsoleGraphics
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());

        char star = '*';
        char empty = ' ';
        char wave = '~';
        int width = 2 * input;
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("{0}", new string(star, width));
        }
        for (int i = 0; i < input - 1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string(star, input / 2 + 1), 
                new string(empty, width - (input / 2 + 1) * 2));
        }
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("{0}", new string(wave, width));
        }
    }
}
