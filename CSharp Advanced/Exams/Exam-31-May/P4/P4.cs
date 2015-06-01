using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace P4
{
    class P4
    {
        static void Main(string[] args)
        {
            var agregatedData = new Dictionary<string, Dictionary<string, int>>();

            var line = Console.ReadLine();
            while (!line.Equals("report"))
            {
                line = line.Trim();
                line = Regex.Replace(line, @"\s+", " ");
                var data = line.Split('|');
                var validData = data.Select(x => x.Trim()).ToList();
                var country = validData[1];
                var player = validData[0];
                if (!agregatedData.ContainsKey(country))
                {
                    agregatedData.Add(country, new Dictionary<string, int>());
                }

                if (!agregatedData[country].ContainsKey(player))
                {
                    agregatedData[country].Add(player, 0);
                }

                agregatedData[country][player]++;
                line = Console.ReadLine();
            }

            var countryWins = new Dictionary<string, int>();
            var countryNumPlayers = new Dictionary<string, int>();
            foreach (var country in agregatedData)
            {
                var totalWins = 0;
                foreach (var player in country.Value)
                {
                    totalWins += player.Value;
                }

                countryWins.Add(country.Key, totalWins);
                countryNumPlayers.Add(country.Key, country.Value.Count);
            }

            var newResult = countryWins.OrderByDescending(x => x.Value);

            foreach (var country in newResult)
            {
                var participants = countryNumPlayers[country.Key];
                Console.WriteLine("{0} ({1} participants): {2} wins", country.Key,participants, country.Value);
            }
        }
    }
}
