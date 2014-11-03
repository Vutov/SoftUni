using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class House
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        int width = 2 * input - 1;
        int height = 2 * input + 2;
        int roofHeight = input;
        int houseBase = input + 2;
        int windowHight = input / 2;
        int windowWidth = input - 3;
        char dot = '.';
        char star = '*';


        //Top;
        Console.WriteLine("{0}{1}{0}", new string(dot, width / 2), star);
        for (int i = 0; i < roofHeight - 1; i++)
        {
             Console.WriteLine("{0}{1}{2}{1}{0}", new string(dot, width / 2 - i - 1), star,
                 new string(dot, 1 + 2 * i));
        }
        //Middle;
        Console.WriteLine("{0}", new string(star, width));
        //Above the window;
        for (int i = 0; i < (houseBase - 2) / 4; i++)
        {
            Console.WriteLine("{0}{1}{0}", star, new string(dot, width - 2));
        }
        //Window;
        for (int i = 0; i < windowHight; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", star, new string(dot, (width - windowWidth - 2) / 2),
            new string(star, windowWidth));
        }
        //Under the window;
        for (int i = 0; i < (houseBase - 2) / 4; i++)
        {
            Console.WriteLine("{0}{1}{0}", star, new string(dot, width - 2));
        }
        //Bottom;
        Console.WriteLine("{0}", new string(star, width));



    }
}
