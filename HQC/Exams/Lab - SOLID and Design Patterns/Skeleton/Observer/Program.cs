namespace Skyrim
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Units;

    class Program
    {
        static void Main()
        {
            // Dragon with 100 HP
            var dragon = new Dragon("Alduin", 300, 100);
            
            List<Warrior> warriors = new List<Warrior>();
            warriors.Add(new Warrior("Ulfric Stormcloak", 80, 80));
            warriors.Add(new Warrior("Cicero", 15, 50));
            warriors.Add(new Warrior("Jarl Balgruuf", 40, 30));

            foreach (var warrior in warriors)
            {
                dragon.Attach(warrior);
            }

            var war = warriors.First();
            Console.WriteLine(war.Inventory.FirstOrDefault());
            // Nothing happens
            dragon.HealthPoints -= 20;
            // Nothing happens
            dragon.HealthPoints -= 10;
            // Dragon dies
            dragon.HealthPoints -= 90;

            Console.WriteLine(war.Inventory.First());
        }
    }
}
