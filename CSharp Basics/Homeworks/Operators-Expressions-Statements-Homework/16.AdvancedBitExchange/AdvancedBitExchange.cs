using System;

class AdvancedBitExchange
{
    // Get the bit in the need position.
    private static uint ExtractBit(uint number, int position)
    {
        uint bit = (number >> position) & 1;
        return bit;
    }

    // Replace the bit with its counterpart.
    private static uint BitReplacer(uint number, uint bit, int position)
    {
        uint replacedBit;
        if (bit == 0)
        {
            replacedBit = number & ~(1u << position);
        }
        else
        {
            replacedBit = number | (1u << position);
        }
        return replacedBit;
    }

    private static uint BinaryResult(uint number, int p, int q, int k)
    {
        uint firstBit;
        uint secondBit;
        for (int i = 0; i < k; i++) //pre-condition: bits {p, p+1, …, p+k-1}
        { // are swaped with bits {q, q+1, …, q+k-1}.
            firstBit = ExtractBit(number, (p + i)); // p + 0 = p, p + 1 = p + 1, etc.
            secondBit = ExtractBit(number, (q + i)); // same goes for q
            if (firstBit != secondBit) // if the bits are not the same, than they
            {                        // have to be replaced with their counterpart.
                number = BitReplacer(number, firstBit, q + i);
                number = BitReplacer(number, secondBit, p + i);
            }
        }
        return number;
    }

    private static void PrintBinaryResult(uint number, int p, int q, int k)
    {
        if ((p + k - 1) > 31 || (q + k - 1) > 31) // 32 bits, if index > 31
        {// is out of range. (bits start from 0)
            Console.WriteLine("{0} -> out of range", number);
        }
        else if(Math.Min(p, q) + k - 1 >= Math.Max(p, q))
        {
            Console.WriteLine("{0} -> overlapping", number);
        } 
        else
        {
            Console.WriteLine("{0} -> {1}", number, BinaryResult(number, p, q, k));
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your number: ");
        uint n = uint.Parse(Console.ReadLine());
        Console.WriteLine("Please enter your p: ");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter your q: ");
        int q = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter your k: ");
        int k = int.Parse(Console.ReadLine());
        PrintBinaryResult(n, p, q, k);
        Console.WriteLine("Condition numbers:");
        //test with condition numbers.
        PrintBinaryResult(1140867093, 3, 24, 3);
        PrintBinaryResult(4294901775, 24, 3, 3);
        PrintBinaryResult(2369124121, 2, 22, 10);
        PrintBinaryResult(987654321, 2, 8, 11);
        PrintBinaryResult(123456789, 26, 0, 7);
        PrintBinaryResult(3333333333, -1, 0, 33);
    }
}