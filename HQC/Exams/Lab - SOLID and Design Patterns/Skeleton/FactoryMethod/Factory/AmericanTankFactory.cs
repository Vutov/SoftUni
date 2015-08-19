namespace FactoryMethod.Factory
{
    using TankManufacturer.Units;

    public class AmericanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            var tank = new Tank("M1 Abrams", 5.4, 120);
            return tank;
        }
    }
}
