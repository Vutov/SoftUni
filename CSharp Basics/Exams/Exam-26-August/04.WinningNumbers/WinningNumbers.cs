using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WinningNumbers
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        input = input.ToLower();
        int letSum = 0;
        foreach (char letter in input)
        {
            int value = (letter - 96); // a has int index 97, b is 98, ect;
            letSum += value;
        }
        //Console.WriteLine(letSum);
        int count = 0;
        for (int d1 = 0; d1 < 10; d1++)
        {
            for (int d2 = 0; d2 < 10; d2++)
            {
                for (int d3 = 0; d3 < 10; d3++)
                {
                    if (d1 * d2 * d3 == letSum)
                    {
                        for (int d4 = 0; d4 < 10; d4++)
                        {
                            for (int d5 = 0; d5 < 10; d5++)
                            {
                                for (int d6 = 0; d6 < 10; d6++)
                                {
                                    if (d4 * d5 * d6 == letSum)
                                    {
                                        Console.WriteLine("{0}{1}{2}-{3}{4}{5}",
                                            d1, d2, d3, d4, d5, d6);
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
        }
        if (count == 0)
        {
            Console.WriteLine("No");
        }
    }
}