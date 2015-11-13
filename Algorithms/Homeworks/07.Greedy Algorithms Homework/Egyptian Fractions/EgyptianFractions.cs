using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyptian_Fractions
{
    internal class EgyptianFractions
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var fractions = input.Split('/').Select(int.Parse).ToList();
            var coef = (double)fractions[0] / fractions[1];
            if (coef > 1d)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            var devider = 2;
            var result = new List<string>();
            while (coef > 0.0000001d)
            {
                if (coef - 1d / devider >= 0)
                {
                    coef -= 1d / devider;
                    result.Add(string.Format("1/{0}", devider));
                }

                devider++;
            }

            Console.WriteLine("{0} = {1}", input, string.Join(" + ", result));
        }
    }
}
