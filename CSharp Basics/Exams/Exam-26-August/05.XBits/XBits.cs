using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class XBits
{
    static void Main(string[] args)
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int count = 0;

        for (int num = 0; num < 6; num++)
        {
            int thirdNum = int.Parse(Console.ReadLine());
            for (int bit = 29; bit >= 0; bit--)//32 bits total;
            {
                bool numOneMatch = ((firstNum >> bit) & 7) == 5;
                bool numTwoMatch = ((secondNum >> bit) & 7) == 2;
                bool numThreeMatch = ((thirdNum >> bit) & 7) == 5;
                if (numOneMatch && numTwoMatch && numThreeMatch)
                {
                    count++;
                }
            }
            firstNum = secondNum;
            secondNum = thirdNum;
        }
        Console.WriteLine(count);
    }
}