namespace VehicleParkSystem.Models
{
    public class Truck : Vehicle
    {
        private const decimal RegularRatePrice = 4.75m;

        private const decimal OvertimeRatePrice = 6.20m;

        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, RegularRatePrice, OvertimeRatePrice, reservedHours)
        {
        }
    }
}
