using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ByteParty
{
    static void Main(string[] args)
    {
        int len = int.Parse(Console.ReadLine());
        int[] numbers = new int[len];
        for (int num = 0; num < len; num++)
        {
            numbers[num] = int.Parse(Console.ReadLine());
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "party over")
            {
                break;
            }
            string[] commands = input.Split(' ');
            int theCase = int.Parse(commands[0]);
            int possition = int.Parse(commands[1]);

            for (int num = 0; num < len; num++)
            {
                if (theCase == -1)
                {
                    numbers[num] = numbers[num] ^ (1 << possition);
                }
                else if (theCase == 0)
                {
                    numbers[num] = numbers[num] & ~(1 << possition);
                }
                else // == 1
                {
                    numbers[num] = numbers[num] | (1 << possition);
                }
            }
        }

        for (int num = 0; num < len; num++)
        {
            Console.WriteLine(numbers[num]);
        }
    }
}
