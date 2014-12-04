using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitCopy
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int bitPossition = int.Parse(Console.ReadLine());

        //Get bit;
        int bit = (number >> bitPossition) & 1;
        //Set bit to zero;
        number = number & ~(1 << 2);
        //Swap bits;
        number = number | (bit << 2);

        Console.WriteLine(number);
    }
}
