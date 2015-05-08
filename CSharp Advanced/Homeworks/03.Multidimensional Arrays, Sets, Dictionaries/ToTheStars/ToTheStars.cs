using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ToTheStars
{
    static void Main(string[] args)
    {
        var planets = new Dictionary<string, List<float>>();
        for (int i = 0; i < 3; i++)
        {
            string[] data = Console.ReadLine().Split(' ');
            string name = data[0];
            float x = float.Parse(data[1]);
            float y = float.Parse(data[2]);
            planets[name] = new List<float>();
            planets[name].Add(x);
            planets[name].Add(y);
        }

        float[] pos = Console.ReadLine().Split(' ').Select(float.Parse).ToArray();
        int turns = int.Parse(Console.ReadLine());
        for (int i = 0; i <= turns; i++)
        {
            bool nearPlanet = false;
            foreach (var planet in planets)
            {
                var coords = planet.Value;
                if (pos[0] >= coords[0] - 1 && pos[0] <= coords[0] + 1 &&
                    pos[1] >= coords[1] - 1 && pos[1] <= coords[1] + 1)
                {
                    Console.WriteLine(planet.Key.ToLower());
                    nearPlanet = true;
                }
            }

            if (!nearPlanet)
            {
                Console.WriteLine("space");
            }

            pos[1]++;
        }
    }
}