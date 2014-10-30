using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int width = 3 * N;
        int height = 3 * N / 2 - 1;
        int roofHeight = N / 2; //body height;
        int wheelsHeight = N / 2 - 1;
        char dot = '.';
        char star = '*';
        //Roof top;
        for (int i = 0; i < width; i++)
        {
            if (i >= N && i < 2 * N)
            {
                Console.Write(star);
            }
            else
            {
                Console.Write(dot);
            }
        }
        Console.WriteLine();
        //Windows;
        for (int roof = 0; roof < roofHeight; roof++)
        {
            for (int i = 0; i < width; i++)
            {
                if (roof < roofHeight - 1)
                {
                    if (i == N - roof - 1 || i == 2 * N + roof)
                    {
                        Console.Write(star);
                    }
                    else
                    {
                        Console.Write(dot);
                    }
                }//Body top;
                else
                {
                    if (i <= N - roof - 1 || i >= 2 * N + roof)
                    {
                        Console.Write(star);
                    }
                    else
                    {
                        Console.Write(dot);
                    }
                }
                
            }
            Console.WriteLine();
        }
        //Middle part of the car;
        for (int i = 0; i < roofHeight - 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", star, new string(dot, width - 2));
        }
        //Body bottom;
        Console.WriteLine(new string(star, width));
        //Wheels;
        for (int i = 0; i < wheelsHeight - 1; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{3}{1}{2}{1}{0}", new string(dot, N / 2), star, new string(dot, (N / 2 + 1) - 2),
                new string(dot, width - (2 * (N / 2) + (2 * (N / 2 + 1)))));
        }
        Console.WriteLine("{0}{1}{2}{1}{0}", new string(dot, N / 2), new string(star, N / 2 + 1),
                new string(dot, width - (2 * (N / 2) + (2 * (N / 2 + 1)))));
    }
}