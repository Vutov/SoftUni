using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Prime_Factorization
{
    class PrimeFactorization
    {

        static List<int> GetPrimes(int number)
        {
            int divider = 2;
            var dividers = new List<int>();
            while (divider < number)
            {
                while (number % divider == 0)
                {
                    number /= divider;
                    dividers.Add(divider);
                }
                divider++;
            }

            dividers.Add(divider);

            return dividers;
        }

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var dividers = GetPrimes(number);

            Console.WriteLine("{0} = {1}", number, string.Join(" * ", dividers));
        }
    }
}
