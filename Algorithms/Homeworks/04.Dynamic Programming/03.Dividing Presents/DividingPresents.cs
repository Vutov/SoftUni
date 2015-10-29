using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Dividing_Presents
{
    class DividingPresents
    {
        static void Main(string[] args)
        {
            var input = "2,2,4,4,1,1";
            //var input = "3,2,3,2,2,77,89,23,90,11";
            var sequence = input.Split(',').Select(int.Parse).ToList();
            sequence.Sort();
            var alan = new List<int>();
            var alanValue = 0;
            var bob = new List<int>();
            var bobValue = 0;
            for (int i = sequence.Count - 1; i >= 0 ; i--)
            {
                if (bobValue < alanValue)
                {
                    bobValue += sequence[i];
                    bob.Add(sequence[i]);
                }
                else
                {
                    alanValue += sequence[i];
                    alan.Add(sequence[i]);
                }
            }

            Console.WriteLine("Difference: {0}", Math.Abs(alanValue - bobValue));
            Console.WriteLine("Alan:{0} Bob:{1}", alanValue, bobValue);
            Console.WriteLine("Alan takes: {0}", string.Join(" ", alan));
            Console.WriteLine("Bob takes: {0}", string.Join(" ", bob));
        }
    }
}
