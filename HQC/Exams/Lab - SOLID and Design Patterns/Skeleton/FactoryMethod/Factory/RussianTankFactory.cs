namespace FactoryMethod.Factory
{
    using TankManufacturer.Units;

    public class RussianTankFactory: TankFactory
    {
        public override Tank CreateTank()
        {
            var tank = new Tank("T 34", 3.3, 75);
            return tank;
        }
    }
}
