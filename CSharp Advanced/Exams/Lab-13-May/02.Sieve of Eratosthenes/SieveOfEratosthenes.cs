using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sieve_of_Eratosthenes
{
    class SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            int endNum = int.Parse(Console.ReadLine());

            var numbers = Enumerable.Range(0, endNum + 1).ToList();
            numbers[0] = -1;
            numbers[1] = -1;
            int p = 2;
            //while (p <= endNum)
            //{
            //    numbers = numbers.Select(x =>
            //    {
            //        if (x % p == 0)
            //        {
            //            if (x == p)
            //            {
            //                return x;
            //            }

            //            return -1;
            //        }

            //        return x;
            //    }).ToList();

            //    p++;
            //}

            for (int i = 2; i < numbers.Count; i++)
            {
                for (int j = i + i; j < numbers.Count; j += i)
                {
                    numbers[j] = -1;
                }
            }

            numbers.RemoveAll(x => x < 0);
            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
