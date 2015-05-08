using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ActivityTracker
{
    static void Main(string[] args)
    {
        int logs = int.Parse(Console.ReadLine());
        string regex = "\\d{2}\\/(\\d{2})\\/\\d{4}\\s+([\\w\\W]+?)\\s+(\\d+)";
        var data = new SortedDictionary<int, SortedDictionary<string, int>>();
        for (int i = 0; i < logs; i++)
        {
            foreach (Match m in Regex.Matches(Console.ReadLine(), regex))
            {
                int month = int.Parse(m.Groups[1].ToString());
                string name = m.Groups[2].ToString();
                int dist = int.Parse(m.Groups[3].ToString());
                if (!data.ContainsKey(month))
                {
                    data.Add(month, new SortedDictionary<string, int>());
                }

                if (!data[month].ContainsKey(name))
                {
                    data[month].Add(name, 0);
                }

                data[month][name] += dist;
            }
        }

        foreach (var month in data)
        {
            Console.Write("{0}: ", month.Key);
            var buffer = new List<string>();
            foreach (var name in month.Value)
            {
                buffer.Add(name.Key + "(" + name.Value + ")");
            }
            Console.WriteLine(string.Join(", ", buffer));
        }
    }
}