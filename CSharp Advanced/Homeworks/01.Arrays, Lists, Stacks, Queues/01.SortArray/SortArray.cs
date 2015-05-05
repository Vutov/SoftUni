using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortArray
{
    static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
        input.Sort();
        Console.WriteLine(string.Join(" ", input));
    }
}

