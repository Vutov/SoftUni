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
        uint number = uint.Parse(Console.ReadLine());

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

    private static uint RemoveCommand(uint number, int bit)
    {
        uint newNumber = 0;
        for (int bitInNumber = 0; bitInNumber < 32; bitInNumber++)
        {
            if (bitInNumber < bit)
            {
                uint currentBit = (number >> bitInNumber) & 1u;
                newNumber |= currentBit << bitInNumber;
            }
            else if (bitInNumber > bit)
            {
                uint currentBit = (number >> bitInNumber) & 1u;
                newNumber |= currentBit << bitInNumber - 1;
            }
        }

        return newNumber;
    }

    private static uint InsertCommand(uint number, int bit)
    {
        uint newNumber = 0;
        //Working with 33 bits since we are adding one;
        for (int bitInNumber = 0; bitInNumber <= 32; bitInNumber++)
        {
            if (bitInNumber < bit)
            {
                uint currentBit = (number >> bitInNumber) & 1u;
                newNumber |= currentBit << bitInNumber;
            }
            else if (bitInNumber == bit)
            {
                newNumber |= 1u << bitInNumber;
            }
            else // bitInNumber > bit;
            {
                uint currentBit = (number >> bitInNumber - 1) & 1u;
                newNumber |= currentBit << bitInNumber;
            }
        }

        return newNumber;
    }

    private static uint FlipCommand(uint number, int bit)
    {
        uint flippedNumber = number ^ (1u << bit);

        return flippedNumber;
    }
}
