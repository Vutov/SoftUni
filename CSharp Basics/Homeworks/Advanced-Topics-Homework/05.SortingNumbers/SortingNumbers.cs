using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SortingNumbers
{
    static void Main(string[] args)
    {
        int len = int.Parse(Console.ReadLine());
        int[] numbers = new int[len];

        for (int i = 0; i < len; i++)
        {
            int number = int.Parse(Console.ReadLine());
            numbers[i] = number;
        }
        Array.Sort(numbers);
        for (int i = 0; i < len; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
