namespace _04.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main(string[] args)
        {
            var countryInfo = new Dictionary<string, Dictionary<string, double>>();

            var command = Console.ReadLine();
            while (!command.Equals("report"))
            {
                var commandInfo = command.Split('|');
                var country = commandInfo[1];
                var city = commandInfo[0];
                var population = double.Parse(commandInfo[2]);

                if (!countryInfo.ContainsKey(country))
                {
                    countryInfo.Add(country, new Dictionary<string, double>());
                }

                if (!countryInfo[country].ContainsKey(city))
                {
                    countryInfo[country].Add(city, population);
                }

                command = Console.ReadLine();
            }

            var orderedCountries = countryInfo.OrderByDescending(c => c.Value.Values.Sum());

            foreach (var country in orderedCountries)
            {
                var orderedCities = country.Value.OrderByDescending(c => c.Value);
                Console.WriteLine("{0} (total population: {1})", country.Key, country.Value.Sum(c => c.Value));
                foreach (var city in orderedCities)
                {
                    Console.WriteLine("=>" + city.Key + ": " + city.Value);
                }
            }
        }
    }
}
