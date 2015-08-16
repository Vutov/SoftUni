namespace VehicleParkSystem.Interfaces
{
    public interface IVehicle
    {
        string LicensePlate { get; }

        string Owner { get; }

        decimal RegularRate { get; }

        decimal OvertimeRate { get; }

        int ReservedHours { get; }
    }
}