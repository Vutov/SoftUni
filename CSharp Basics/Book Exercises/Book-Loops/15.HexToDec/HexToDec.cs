using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.HexToDec
{
    class HexToDec
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a binary number:");
            string hexadecimal = Console.ReadLine();
            int value = Convert.ToInt32(hexadecimal, 16);
            Console.WriteLine("{0} in decemetric is {1}.", hexadecimal, value);
        }
    }
}
