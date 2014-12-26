using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitLock
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] inputNums = input.Split(' ');
        int[] numbers = Array.ConvertAll(inputNums, int.Parse);
        int totalBits = 12; //Working with 12 bits: 0 to 11;

        while (true)
        {
            input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }
            string[] commands = input.Split(' ');
            if (commands[0] == "check")
            {
                int possition = int.Parse(commands[1]);
                int len = numbers.Length; //All numbers;
                int count = 0;
                for (int i = 0; i < len; i++)
                {
                    int bit = (numbers[i] >> possition) & 1;
                    if (bit == 1)
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
            }
            else //rotate bits;
            {
                int number = int.Parse(commands[0]);
                int rotates = int.Parse(commands[2]);
                int len = rotates % totalBits; //To avoid full runs;
                for (int runs = 0; runs < len; runs++)
                {
                    int tempNumber = 0;
                    if (commands[1] == "left")
                    {
                        for (int bit = 0; bit < totalBits; bit++)
                        {
                            int currentBit = (numbers[number] >> bit) & 1;
                            if (bit == totalBits - 1)
                            {
                                tempNumber = tempNumber | currentBit;
                            }
                            else
                            {
                                tempNumber = tempNumber | (currentBit << bit + 1);
                            }
                        }
                    }
                    else //Right;
                    {
                        for (int bit = totalBits - 1; bit >= 0; bit--)
                        {
                            int currentBit = (numbers[number] >> bit) & 1;
                            if (bit == 0)
                            {
                                tempNumber = tempNumber | (currentBit << (totalBits - 1));
                            }
                            else
                            {
                                tempNumber = tempNumber | (currentBit << bit - 1);
                            }
                        }
                    }
                    numbers[number] = tempNumber;
                }
            }
        }
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
