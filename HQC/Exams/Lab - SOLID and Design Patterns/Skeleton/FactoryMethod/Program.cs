namespace TankManufacturer
{
    using System;
    using FactoryMethod.Factory;
    using Units;

    class Program
    {
        static void Main()
        {
            TankFactory tankFactory = new GermanTankFactory();
            // tankFactory = new RussianTankFactory();
            // tankFactory = new AmericanTankFactory();

            var tank = tankFactory.CreateTank();
            Console.WriteLine(tank);

        }
    }
}
