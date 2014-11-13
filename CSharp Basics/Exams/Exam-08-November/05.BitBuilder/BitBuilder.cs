using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitBuilder
{
    static void Main(string[] args)
    {
        //uint number = 11230;
        long number = long.Parse(Console.ReadLine());

        for (int commands = 0; commands < 30; commands++)
        {
            string command = Console.ReadLine();
            //string command = "15";
            int bit;
            if (command == "quit")
            {
                break;
            }
            else
            {
                bit = int.Parse(command);
            }
            //command = "remove";
            command = Console.ReadLine();
            switch (command)
            {
                case "flip": number = FlipCommand(number, bit); break;
                case "remove": number = RemoveCommand(number, bit); break;
                case "insert": number = InsertCommand(number, bit); break;
                case "skip": continue;
            }
        }
        //Console.WriteLine(Convert.ToString(number, 2));
        Console.WriteLine(number);
    }

    private static long RemoveCommand(long number, int bit)
    {
        long newNumber = 0;
        //Long has 64 bits, since we don't know how many we will need,
        //we use all 64.
        for (int bitInNumber = 0; bitInNumber < 64; bitInNumber++)
        {
            if (bitInNumber < bit)
            {
                long currentBit = (number >> bitInNumber) & 1L;
                newNumber |= currentBit << bitInNumber;
            }
            else if (bitInNumber > bit)
            {
                long currentBit = (number >> bitInNumber) & 1L;
                newNumber |= currentBit << bitInNumber - 1;
            }
        }

        return newNumber;
    }

    private static long InsertCommand(long number, int bit)
    {
        long newNumber = 0;
        //Long has 64 bits, since we don't know how many we will need,
        //we use all 64.
        for (int bitInNumber = 0; bitInNumber < 64; bitInNumber++)
        {
            if (bitInNumber < bit)
            {
                long currentBit = (number >> bitInNumber) & 1L;
                newNumber |= currentBit << bitInNumber;
            }
            else if (bitInNumber == bit)
            {
                newNumber |= 1L << bitInNumber;
            }
            else // bitInNumber > bit;
            {
                long currentBit = (number >> bitInNumber - 1) & 1L;
                newNumber |= currentBit << bitInNumber;
            }
        }

        return newNumber;
    }

    private static long FlipCommand(long number, int bit)
    {
        long flippedNumber = number ^ (1L << bit);

        return flippedNumber;
    }
}
