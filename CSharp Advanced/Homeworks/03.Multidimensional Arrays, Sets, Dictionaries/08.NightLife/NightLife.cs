using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

internal class NightLife
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var info = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();
        while (!input.Equals("END"))
        {
            string[] data = input.Split(';');
            string city = data[0];
            string venue = data[1];
            string performar = data[2];
            if (!info.ContainsKey(city))
            {
                info.Add(city, new SortedDictionary<string, SortedSet<string>>());
            }

            if (!info[city].ContainsKey(venue))
            {
                info[city].Add(venue, new SortedSet<string>());
            }

            info[city][venue].Add(performar);
            input = Console.ReadLine();
        }

        //Print;
        foreach (var city in info)
        {
            Console.WriteLine(city.Key);
            foreach (var pair in city.Value)
            {
                Console.WriteLine("->{0}: {1}",pair.Key, string.Join(", ", pair.Value));
            }
        }
    }
}