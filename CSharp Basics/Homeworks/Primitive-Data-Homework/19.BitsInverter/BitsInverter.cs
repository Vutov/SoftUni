using System;

class BitsInverter
{
    static void Main(string[] args)
    {
        int numBit = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index = 1;
        for (int i = 0; i < numBit; i++)
        {
            int number = int.Parse(Console.ReadLine());
            //starting left to right - starting from 7th bit.
            for (int bit = 7; bit >= 0; bit--) // 8 bits per number
            {
                if ((index % step == 1) || (step == 1 && index > 0))
                {// 1 % anything == 1
                 // index % step == 1 because it it is 1 + step, not only step. If it was 
                 // 2 + step, than -> index % step == 2 and ect.
                    number = number ^ (1 << bit);
                }
                index++; // to remembers the current position
            }
            Console.WriteLine(number);
        }
    }
}