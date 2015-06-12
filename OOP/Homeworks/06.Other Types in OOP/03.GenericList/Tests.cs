using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomList.Attributes;

namespace CustomList
{
    class Tests
    {
        static void Main(string[] args)
        {
            Type type = typeof(GenericList<>);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (var version in allAttributes)
            {
                if (version is CurrVersion)
                {
                    Console.WriteLine(version);
                }
            }

            Console.WriteLine(new string('-', 50));
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

            try
            {
                Console.WriteLine(myList[34]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception: {0}",ex.Message);
            }
        }
    }
}
