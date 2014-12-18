using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Beer
{
    static void Main(string[] args)
    {
        int beers = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            string[] data = input.Split(' ');
            if (data[1] == "stacks")
            {
                beers += int.Parse(data[0]) * 20;
            }
            else
            {
                beers += int.Parse(data[0]);
            }
        }
        int stacks = beers / 20;
        int bearsLeft = beers % 20;

        Console.WriteLine("{0} stacks + {1} beers", stacks, bearsLeft);
    }
}

