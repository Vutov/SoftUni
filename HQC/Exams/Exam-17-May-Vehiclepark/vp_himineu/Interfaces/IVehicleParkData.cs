namespace VehicleParkSystem.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IVehicleParkData
    {
        bool IsEmptyPlace(int sector, int place);

        bool HasParkedWithLicense(string licensePlate);

        void InsertVehicle(IVehicle vehicle, int sector, int place, DateTime time);

        string GetParkedSpot(IVehicle vehicle);

        DateTime GetExpectedTimeForVehicle(IVehicle vehicle);

        void RemoveVehicle(IVehicle vehicle);

        IVehicle GetVehicle(string licensePlate);

        int[] ParkingLotStatus();

        IEnumerable<IVehicle> GetVehiclesByOwner(string owner);
    }
}
