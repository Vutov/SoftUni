namespace VehicleParkSystem.Models
{
    using System.Text;
    using Interfaces;

    public class Ticket
    {
        public Ticket(IVehicle vehicle, decimal payedMoney, string parkedPlace, int endTime)
        {
            this.Vehicle = vehicle;
            this.PayedMoney = payedMoney;
            this.ParkedPlace = parkedPlace;
            this.EndTime = endTime;
        }

        public IVehicle Vehicle { get; private set; }

        public decimal PayedMoney { get; private set; }

        public string ParkedPlace { get; private set; }

        public int EndTime { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            var overTime = this.CalculateOverTime();
            var expectedPrice = this.CalculateExpectedPrice();

            result.AppendLine(new string('*', 20))
                .AppendFormat("{0}", this.Vehicle)
                .AppendLine()
                .AppendFormat("at place {0}", this.ParkedPlace)
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", expectedPrice)
                .AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", overTime)
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", expectedPrice + overTime)
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", this.PayedMoney)
                .AppendLine()
                .AppendFormat("Change: ${0:F2}", this.PayedMoney - (expectedPrice + overTime))
                .AppendLine()
                .Append(new string('*', 20));

            return result.ToString();
        }

        private decimal CalculateOverTime()
        {
            var overTime = 0m;
            if (this.EndTime > this.Vehicle.ReservedHours)
            {
                overTime = (this.EndTime - this.Vehicle.ReservedHours) * this.Vehicle.OvertimeRate;
            }

            return overTime;
        }

        private decimal CalculateExpectedPrice()
        {
            return this.Vehicle.ReservedHours * this.Vehicle.RegularRate;
        }
    }
}
