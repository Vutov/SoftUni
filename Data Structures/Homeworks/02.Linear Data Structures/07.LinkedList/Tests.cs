using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LinkedList
{
    class Tests
    {
        static void Main(string[] args)
        {
            var testArr = new LinkedList<int>();
            Console.WriteLine("Elements:");
            testArr.Add(1);
            testArr.Add(4);
            testArr.Add(-1);
            testArr.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            Console.WriteLine("Count:");
            Console.WriteLine(testArr.Count());
            Console.WriteLine("Remove element [1]:");
            testArr.Remove(1);
            testArr.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            Console.WriteLine("Count:");
            Console.WriteLine(testArr.Count());
            Console.WriteLine("Remove element [1]:");
            testArr.Remove(1);
            testArr.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            Console.WriteLine("Count:");
            Console.WriteLine(testArr.Count());
            Console.WriteLine("Remove element [0]:");
            testArr.Remove(0);
            testArr.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            Console.WriteLine("Count:");
            Console.WriteLine(testArr.Count());
            testArr.Add(3);
            testArr.Add(5);
            testArr.Add(7);
            testArr.Add(0);
            Console.WriteLine("Enum:");
            foreach (var element in testArr)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("Elements:");
            testArr.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            Console.WriteLine("Index of 5");
            Console.WriteLine(testArr.FirstIndexOf(5));
            testArr.Add(3);
            testArr.Add(9);
            Console.WriteLine("Last Index of 3");
            Console.WriteLine("Elements:");
            testArr.ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            Console.WriteLine(testArr.LastIndexOf(3));
        }
    }
}
