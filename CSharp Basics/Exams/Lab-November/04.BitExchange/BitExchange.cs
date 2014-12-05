using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitExchange
{
    static void Main(string[] args)
    {
        long number = long.Parse(Console.ReadLine());
        //Get bits;
        long thirdBit = (number >> 3) & 1L;
        long TwentyfourthBit = (number >> 24) & 1L;
        //Zero the bits;
        number = number & ~(1L << 3);
        number = number & ~(1L << 24);
        //Swap the bits;
        number = number | (TwentyfourthBit << 3);
        number = number | (thirdBit << 24);
        Console.WriteLine(number);
    }
}
