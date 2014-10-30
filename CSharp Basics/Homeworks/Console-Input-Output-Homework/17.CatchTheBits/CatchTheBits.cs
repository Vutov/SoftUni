using System;

class CatchTheBits
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // num bits.
        int step = int.Parse(Console.ReadLine()); // step.
        int index = 0;
        string bits = "";
        int count = new int();
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int bit = 7; bit >= 0; bit--) // 8 bits.
            {
                if ((index % step == 1) || (step == 1 && index > 0))
                {
                    int neededBit = number & (1 << bit);
                    bits += (neededBit >> bit);
                    count++;
                    if (count == 8) // one bit done.
                    {
                        Console.WriteLine(Convert.ToInt32(bits, 2));
                        count = 0;
                        bits = "";
                    }
                }
                index++; 
            }
        }
        if (bits != "")// one bit needs padding.
        {
            string padding = new string('0', 8 - count);
            bits += padding;
            Console.WriteLine(Convert.ToInt32(bits, 2));
        }
    }
}