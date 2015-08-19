namespace RPG
{
    using System;

    using Characters;
    using Weapons;

    public class Program
    {
        static void Main()
        {
            var axeWarrior = new Warrior(new Axe());
            var swordWarrior = new Warrior(new Sword());
            var axeMage = new Mage(new Axe());
            var swordMage = new Mage(new Sword());

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordMage);
        }
    }
}
