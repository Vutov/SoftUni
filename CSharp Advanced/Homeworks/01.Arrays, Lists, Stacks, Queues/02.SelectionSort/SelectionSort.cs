using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SelectionSort
{
    static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
        int len = input.Count;
        for (int i = 0; i < len; i++)
        {
            int k = i;
            for (int j = i + 1; j < len; j++)
            {
                if (input[j] < input[k])
                {
                    k = j;
                }
            }
            int tmp = input[i];
            input[i] = input[k];
            input[k] = tmp;
            Console.WriteLine(string.Join(" ", input));
        }
        Console.WriteLine(string.Join(" ", input));
    }
}

