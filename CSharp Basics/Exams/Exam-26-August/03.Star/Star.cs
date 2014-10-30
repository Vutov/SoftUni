using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Star
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        //int n = 8;
        int width = 2 * n + 1;
        int hight = (n * 2 - (n / 2 - 1));
        int top = n / 2; //Top and middle height;
        int legHeight = n / 2 + 1;
        char star = '*';
        char dot = '.';
        //Top;
        Console.WriteLine("{0}{1}{0}", new string(dot, n), star);
        //Rest of the top;
        for (int i = 0; i < top - 1; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", new string(dot, n - 1 - i), star, new string(dot, 1 + 2 * i));
        }
        //Middle's top;
        Console.WriteLine("{0}{1}{0}", new string(star, (width - (n - 1)) / 2), new string(dot, n - 1));
        //Middle;
        for (int i = 0; i < top - 1; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", new string(dot, 1 + i), star,
                new string(dot, width - 2 - 2 * (1 + i)));
        }
        //Top of the legs;
        Console.WriteLine("{0}{1}{2}{1}{2}{1}{0}",
            new string(dot, n / 2), star, new string(dot, n / 2 - 1));
        //Legs;
        for (int i = 0; i < legHeight - 2; i++)
        {
            Console.WriteLine("{0}{1}{3}{1}{2}{1}{3}{1}{0}", new string(dot, (n / 2 - 1) - i), star,
                new string(dot, 1 + 2 * i), new string(dot, (n / 2 - 1)));
        }
        //Bottom of the legs;
        Console.WriteLine("{0}{1}{0}",new string(star, n / 2 + 1), new string(dot, width - 2 * (n / 2 + 1)));
    }
}