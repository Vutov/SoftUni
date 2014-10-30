using System;

class BitFlipper
{
    static void Main(string[] args)
    {
        ulong number = ulong.Parse(Console.ReadLine());
        int endBit = 62;
        while (endBit > 0)
        {
            endBit--;
            ulong last3Bits = (number >> endBit) & 7;
            if (last3Bits == 0 || last3Bits == 7)
            {
                number = number ^ ((ulong)7 << endBit);
                endBit -= 2;
            }            
        }

        Console.WriteLine(number);

    }
}
//121 -> 8
//01111001 -> 00001001
// 0111100111000000 -> 0000100000111111
//31168 -> 2111