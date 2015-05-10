using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

class VladkosNotebook
{
    static void Main(string[] args)
    {
        var result = new SortedDictionary<string, SortedDictionary<string, List<string>>>();

        string line = Console.ReadLine();
        while (!line.Equals("END"))
        {
            string[] data = line.Split('|');
            string color = data[0];
            if (!result.ContainsKey(color))
            {
                result.Add(color, new SortedDictionary<string, List<string>>());
            }

            if (data[1] == "age")
            {
                if (!result[color].ContainsKey("age"))
                {
                    result[color].Add("age", new List<string>() { data[2] });
                }
                else
                {
                    result[color]["age"][0] = data[2];
                }

            }
            else if (data[1] == "name")
            {
                if (!result[color].ContainsKey("name"))
                {
                    result[color].Add("name", new List<string>() { data[2] });
                }
                else
                {
                    result[color]["name"][0] = data[2];
                }
            }
            else
            {
                if (!result[color].ContainsKey("opponents"))
                {
                    result[color]["opponents"] = new List<string>();
                    result[color]["wins"] = new List<string>();
                    result[color]["losses"] = new List<string>();
                }

                result[color]["opponents"].Add(data[2]);

                if (data[1] == "win")
                {
                    result[color]["wins"].Add("");
                }
                else
                {
                    result[color]["losses"].Add("");
                }

            }

            line = Console.ReadLine();
        }

        bool printed = false;
        foreach (var color in result)
        {
            bool hasOpponents = false;
            if (!color.Value.ContainsKey("age") || !color.Value.ContainsKey("name"))
            {
                continue;
            }

            double wins = 0;
            double losses = 0;
            printed = true;
            Console.WriteLine("Color: {0}", color.Key);
            foreach (var data in color.Value)
            {
                var value = data.Value;
                value.Sort(StringComparer.Ordinal);
                if (data.Key == "wins")
                {
                    wins = data.Value.Count;
                }
                else if (data.Key == "losses")
                {
                    losses = data.Value.Count;
                }
                else
                {
                    if (data.Key == "opponents")
                    {
                        hasOpponents = true;
                    }

                    Console.WriteLine("-{0}: {1}", data.Key, string.Join(", ", value));
                }
            }

            if (!hasOpponents)
            {
                Console.WriteLine("-opponents: (empty)");
            }

            Console.WriteLine("-rank: {0:F2}", (wins + 1) / (losses + 1));
        }

        if (!printed)
        {
            Console.WriteLine("No data recovered.");
        }

    }
}