using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Fraction_Calculator
{
    class Tests
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denomerator);
            Console.WriteLine(result);
        }
    }
}
