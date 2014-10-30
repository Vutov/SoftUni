using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitRoller
{
    static void Main(string[] args)
    {
        long number = long.Parse(Console.ReadLine());
        int frozen = int.Parse(Console.ReadLine());
        int rolls = int.Parse(Console.ReadLine());
        /*long number = 480678;
        int frozen = 18;
        int roll = 2;*/
        long rolledNum = number;

        for (int i = 0; i < rolls; i++)
        {
            //set the frozen bit.
            long rolling = number & (1 << frozen);
            for (int bit = 18; bit >= 0; bit--)//19 bits.
            {
                if (bit == frozen) // the frozen bit.
                {
                    continue;
                }
                else if (bit == frozen + 1) // before frozen bit.
                {
                    long currentBit = rolledNum & (1 << bit);
                    rolling = rolling | (currentBit >> 2);
                }
                else if (bit == 0)//last bit.
                {
                    long currentBit = rolledNum & 1;
                    if (frozen == 18)
                    {
                        rolling = rolling | (currentBit << 17);
                    }
                    else
                    {
                        rolling = rolling | (currentBit << 18);
                    }
                }
                else
                {
                    long currentBit = rolledNum & (1 << bit);
                    rolling = rolling | (currentBit >> 1);
                }
            }
            rolledNum = rolling;
            //Console.WriteLine(Convert.ToString(rollNum, 2).PadLeft(19, '0'));
            //Console.WriteLine("1101101010101101001");
        }
        Console.WriteLine(rolledNum);
    }
}
