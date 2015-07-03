using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_and_Average
{
    class SumAndAvg
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                var elements = input.Split(' ').Select(int.Parse).ToList();
                Console.WriteLine("Sum={0}; Average={1}", elements.Sum(), elements.Average());
            }
            else
            {
                Console.WriteLine("Sum=0; Average=0");
            }
        }
    }
}
