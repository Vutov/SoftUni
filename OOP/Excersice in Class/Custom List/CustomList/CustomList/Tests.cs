using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Tests
    {
        static void Main(string[] args)
        {
            GenericList<int> myList = new GenericList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(15);
            myList.Add(6);
            myList.Add(1);
            myList.Add(1);
            myList.Add(1);
            myList.Add(1);
            myList.Add(1);
            myList.Add(1);
            myList.Add(6);
            myList.Add(6);
            myList.Add(6);
            myList.Add(6);
            myList.Add(6);
            myList.Add(6);
            myList.Add(-1);

            Console.WriteLine(myList.Max());
            Console.WriteLine(myList.Min());
            Console.WriteLine(myList[3]);

            myList.Remove(15);

            myList[0] = 50;

            myList.Sort();

            Console.WriteLine(myList);

            myList.Reverse();

            Console.WriteLine(myList);

            Console.WriteLine(myList.Contains(1000));
        }
    }
}
