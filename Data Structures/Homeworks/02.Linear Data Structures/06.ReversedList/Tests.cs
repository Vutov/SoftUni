using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReversedList
{
    class Tests
    {
        static void Main(string[] args)
        {
            var testArr = new ReversedList<int>();
            testArr.Add(1);
            testArr.Add(10);
            testArr.Add(5);
            testArr.Add(2);

            Console.WriteLine("Elements:");
            testArr.ForEach(Console.WriteLine);
            Console.WriteLine("Count:");
            Console.WriteLine(testArr.Count());
            testArr.Add(-1);
            Console.WriteLine("Elements:");
            testArr.ForEach(Console.WriteLine);
            Console.WriteLine("Count:");
            Console.WriteLine(testArr.Count());
            Console.WriteLine("Capacity:");
            Console.WriteLine(testArr.Capacity());
            Console.WriteLine("Elements:");
            Console.WriteLine(string.Join(" ", testArr));
            Console.WriteLine("Index 2:");
            Console.WriteLine(testArr[2]);
            Console.WriteLine("Index 1:");
            Console.WriteLine(testArr[1]);
            Console.WriteLine("Index 0:");
            Console.WriteLine(testArr[0]);
            Console.WriteLine("Index 4:");
            Console.WriteLine(testArr[4]);
            testArr.Sort();
            Console.WriteLine("Sorted Elements:");
            Console.WriteLine(string.Join(" ", testArr));

        }
    }
}
