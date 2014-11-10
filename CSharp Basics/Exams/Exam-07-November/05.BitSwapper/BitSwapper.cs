using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitSwapper
{
    static void Main(string[] args)
    {
        //uint[] numbers = { 15, 983040, 15728640, 784 };
        //uint[] numbers = { 15, 983040 };

        uint[] numbers = new uint[4];
        //Get numbers;
        for (int i = 0; i < 4; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }
        while (true)
        {
            //Get commands;
            string command = Console.ReadLine();
            if (command == "End")
            {
                break;
            }
            //string command = "2 5";//1st command
            int[] firstNumCommand = Array.ConvertAll(command.Split(' '), int.Parse);
            //command = "3 1";//2nd line;
            command = Console.ReadLine();
            int[] secondNumCommand = Array.ConvertAll(command.Split(' '), int.Parse);
            uint firstNum = numbers[firstNumCommand[0]];
            uint secondNum = numbers[secondNumCommand[0]];
            int firstSwapSet = firstNumCommand[1];
            int secondSwapSet = secondNumCommand[1];
            uint mask = 15u;
            int firstNumPosition = firstSwapSet * 4;
            int secondNumPosition = secondSwapSet * 4;
            //Get bits;
            uint firstNumBits = (firstNum >> firstNumPosition) & mask;
            uint secondNumBits = (secondNum >> secondNumPosition) & mask;
            //Working with one number;
            if (firstNumCommand[0] == secondNumCommand[0])
            {
                //Set bits to 0000 so the new ones can be set;
                firstNum = firstNum & ~(mask << firstNumPosition);
                firstNum = firstNum & ~(mask << secondNumPosition);
                //Set new bits;
                firstNum = firstNum | (secondNumBits << firstNumPosition);
                firstNum = firstNum | (firstNumBits << secondNumPosition);
                //Update the num;
                numbers[firstNumCommand[0]] = firstNum;
            }
            else //Working with 2 numbers;
            {
                //Set bits to 0000 so the new ones can be set;
                firstNum = firstNum & ~(mask << firstNumPosition);
                secondNum = secondNum & ~(mask << secondNumPosition);
                //Set new bits;
                firstNum = firstNum | (secondNumBits << firstNumPosition);
                secondNum = secondNum | (firstNumBits << secondNumPosition);
                //Update numbers;
                numbers[firstNumCommand[0]] = firstNum;
                numbers[secondNumCommand[0]] = secondNum;
            }
        }
        //Print;
        foreach (uint number in numbers)
        {
            Console.WriteLine(number);
        }

    }
}