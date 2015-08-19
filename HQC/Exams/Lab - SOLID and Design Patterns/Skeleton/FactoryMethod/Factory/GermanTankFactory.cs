namespace FactoryMethod.Factory
{
    using TankManufacturer.Units;

    public class GermanTankFactory: TankFactory
    {
        public override Tank CreateTank()
        {
            var tank = new Tank("Tiger", 4.5, 120);
            return tank;
        }
    }
}
