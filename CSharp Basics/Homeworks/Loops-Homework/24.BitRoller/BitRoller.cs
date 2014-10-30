using System;

class BitRoller
{
    static void Main(string[] args)
    {
        long number = long.Parse(Console.ReadLine());
        int frozenBit = int.Parse(Console.ReadLine());
        int rolls = int.Parse(Console.ReadLine());
        long rollingNum = number;

        for (int i = 0; i < rolls; i++)
        {
            long rolledNumber = rollingNum & (1 << frozenBit);
            for (int bit = 18; bit >= 0; bit--)//19 bits
            {
                if (bit == frozenBit)//Frozen bit;
                {
                    continue;
                }
                else if (bit == frozenBit + 1)//The bit before the frozen needs to move to
                {                            //one right after the frozen bit;
                    long currentBit = rollingNum & (1 << bit);
                    rolledNumber = rolledNumber | (currentBit >> 2);
                }
                else if (bit == 0)//Last bit needs to be moved to 18 position;
                {
                    long currentBit = rollingNum & 1;
                    if (frozenBit == 18)//first bit from left is frozen;
                    {
                        rolledNumber = rolledNumber | (currentBit << 17);
                    }
                    else
                    {
                        rolledNumber = rolledNumber | (currentBit << 18);
                    }
                }
                else
                {
                    long currentBit = rollingNum & (1 << bit);
                    rolledNumber = rolledNumber | (currentBit >> 1);
                }
            }
            rollingNum = rolledNumber;
        }
        Console.WriteLine(rollingNum);
    }
}