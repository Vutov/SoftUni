namespace VehicleParkSystem.Models
{
    public class Motorbike : Vehicle
    {
        private const decimal RegularRatePrice = 1.35m;

        private const decimal OvertimeRatePrice = 3m;

        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, RegularRatePrice, OvertimeRatePrice, reservedHours)
        {
        }
    }
}
