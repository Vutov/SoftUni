using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PaintBall
{
    static void Main(string[] args)
    {
        int count = 0;//Determine whatever the command is odd or ever;
        int[] numbers = new int[10];
        for (int i = 0; i < 10; i++)
        {
            numbers[i] = 1023;
        }
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            count++;

            string[] commands = input.Split(' ');
            int row = int.Parse(commands[0]);
            int col = int.Parse(commands[1]);
            int distance = int.Parse(commands[2]);

            int startNum = row - distance;
            int startBit = col - distance;
            if (startBit < 0) //Going off the 10 bits;
            {
                startBit = 0;
            }
            int endBit = col + distance;
            if (endBit > 9) //Going off the 10 bits;
            {
                endBit = 9;
            }
            int len = distance * 2 + 1; //Number of numbers affected;
            for (int i = 0; i < len; i++)
            {
                for (int bit = startBit; bit <= endBit; bit++)
                {
                    //Going outside the range of numbers;
                    if (startNum + i >= 0 && startNum + i < numbers.Length)
                    {
                        if (count % 2 == 1) //Odd = turn into 0;
                        {
                            numbers[startNum + i] &= ~(1 << bit);
                        }
                        else //Even = turn into 1;
                        {
                            numbers[startNum + i] |= (1 << bit);
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
        //foreach (var num in numbers)
        //{
        //    Console.WriteLine(num);
        //}
        int totalSum = numbers.Sum();
        Console.WriteLine(totalSum);

    }
}