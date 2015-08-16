namespace VehicleParkSystem.Models
{
    public class Car : Vehicle
    {
        private const decimal RegularRatePrice = 2m;

        private const decimal OvertimeRatePrice = 3.5m;

        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, RegularRatePrice, OvertimeRatePrice, reservedHours)
        {
        }
    }
}
