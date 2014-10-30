using System;

class ThreeBitExchange
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

    private static uint BinaryResult(uint number)
    {
        uint firstBit;
        uint secondBit;
        for (int i = 3; i <= 5; i++) //pre-condition: bit 3-5 and 24-26 are swaped.
        {
            firstBit = ExtractBit(number, i);
            secondBit = ExtractBit(number, 21 + i); // 21+3 = 24, etc.
            if (firstBit != secondBit) // if the bits are not the same, than they
            {                        // have to be replaced with their counterpart.
                number = BitReplacer(number, firstBit, i + 21);
                number = BitReplacer(number, secondBit, i);
            }
        }
        return number;
    }

    private static void PrintBinaryResult(uint number)
    {
        Console.WriteLine("{0} -> {1}", number, BinaryResult(number));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your number: ");
        uint n = uint.Parse(Console.ReadLine());
        PrintBinaryResult(n);
        Console.WriteLine("Condition numbers:");
        //test with condition numbers.
        PrintBinaryResult(1140867093);
        PrintBinaryResult(255406592);
        PrintBinaryResult(4294901775); // uint number
        PrintBinaryResult(5351);
        PrintBinaryResult(2369124121);
    }
}