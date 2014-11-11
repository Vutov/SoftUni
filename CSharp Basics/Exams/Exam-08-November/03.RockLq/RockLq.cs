using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RockLq
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        int width = 3 * input;
        int height = 2 * input;

        char dot = '.';
        char star = '*';
        int innerDots = input;
        int outerDots = input;

        Console.WriteLine("{0}{1}{0}", new string(dot, outerDots), new string(star, innerDots));
        innerDots += 2;
        outerDots -= 2;
        for (int i = 0; i < input / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string(dot, outerDots), new string(dot, innerDots));
            innerDots += 4;
            outerDots -= 2;
        }
        innerDots = input;
        int middleDots = input - 2;
        Console.WriteLine("*{0}*{1}*{0}*", new string(dot, middleDots), new string(dot, innerDots));
        middleDots -= 2;
        int innerMidDots = 1;
        for (int i = 0; i < input / 2 - 1; i++)
        {
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string(dot, middleDots),
                new string(dot, innerMidDots), new string(dot, innerDots));
            middleDots -= 2;
            innerMidDots += 2;
        }
        outerDots = input - 1;
        for (int i = 0; i < input - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string(dot, outerDots), new string(dot, innerDots));
            outerDots--;
            innerDots += 2;
        }
        Console.WriteLine("{0}", new string(star, width));
    }
}