using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Tests
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>()
            {
                new Cat("Catt", 10, Gender.Female),
                new Cat("Grr", 14, Gender.Male),
                new Cat("Caty", 1, Gender.Female),
                new Dog("Dogy", 2, Gender.Female),
                new Dog("Sharo", 5, Gender.Male),
                new Frog("FRogy", 4, Gender.Female),
                new Frog("Pesho", 3, Gender.Male),
                new Kitten("Catt", 3),
                new Tomcat("Catt", 6),
            };

            animals.ForEach(x =>
            {
                Console.WriteLine(x);
                Console.WriteLine(x.ProduceSound());
            });

            //Animal type -> (total age, number of animals seen);
            var catalog = new Dictionary<string, List<double>>();
            animals.ForEach(x =>
            {
                string animalType = x.GetType().Name;
                if (!catalog.ContainsKey(animalType))
                {
                    catalog.Add(animalType, new List<double>());
                    catalog[animalType].Add(0);
                    catalog[animalType].Add(0);
                }

                catalog[animalType][0] += x.Age;
                catalog[animalType][1] += 1;
            });

            foreach (var animal in catalog)
            {
                Console.WriteLine("{0}s average age is {1:#.##} years", animal.Key, animal.Value[0] / animal.Value[1]);
            }
        }
    }
}
