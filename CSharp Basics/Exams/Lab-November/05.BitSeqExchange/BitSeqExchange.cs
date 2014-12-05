using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitSeqExchange
{
    static void Main(string[] args)
    {
        long number = long.Parse(Console.ReadLine());
        //Get bits;
        long thirdBit = (number >> 3) & 7L;
        long TwentyfourthBit = (number >> 24) & 7L;
        //Zero the bits;
        number = number & ~(7L << 3);
        number = number & ~(7L << 24);
        //Swap the bits;
        number = number | (TwentyfourthBit << 3);
        number = number | (thirdBit << 24);
        Console.WriteLine(number);
    }
}