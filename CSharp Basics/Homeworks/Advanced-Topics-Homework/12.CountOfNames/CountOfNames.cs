//NOTE: There is mistake in the example. It is quite easy to notice, Nakov is used 4 times not 5
//and N is before S in the alphabet.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountOfNames
{
    static void Main(string[] args)
    {
        //Read the names and add to array;
        string allNames = Console.ReadLine();
        string[] names = allNames.Split(' ');
        //Sort and add to dictionary;
        Array.Sort(names);
        Dictionary<string, int> namesAndCounts = new Dictionary<string, int>();
        foreach (string name in names)
        {
            int count;
            if (namesAndCounts.TryGetValue(name, out count))
            {
                namesAndCounts[name] += 1;
            }
            else
            {
                namesAndCounts.Add(name, 1);
            }
        }
        //Print the result;
        foreach (var entry in namesAndCounts)
        {
            Console.WriteLine("{0} -> {1}", entry.Key, entry.Value);
        }

    }
}
