using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class ChangeEvenBits
{
    static void Main(string[] args)
    {
        //int totalNumbers = 1;
        int totalNumbers = int.Parse(Console.ReadLine());
        int[] numbers = new int[totalNumbers];
        for (int i = 0; i < totalNumbers; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            //numbers[i] = 22;
        }
        BigInteger lastNum = int.Parse(Console.ReadLine());
        //BigInteger lastNum = 240;
        int changedBits = 0;

        foreach (int number in numbers)
        {
            string binaryNum = Convert.ToString(number, 2);
            int numLen = binaryNum.Length;
            //Set bits;
            for (int bit = 0; bit < numLen * 2; bit += 2)
            {
                BigInteger currentBit = (lastNum >> bit) & 1;
                if (currentBit == 0)
                {
                    changedBits++;
                }
                lastNum |= (1 << bit);
            }
        }
        Console.WriteLine(lastNum);
        Console.WriteLine(changedBits);

    }
}
