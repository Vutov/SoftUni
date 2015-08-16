namespace VehicleParkSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public class VehiclePark : IVehiclePark
    {
        private readonly Layout layout;
        private readonly IVehicleParkData vehicleParkData;

        public VehiclePark(int numberOfSectors, int placesPerSector, IVehicleParkData vehicleParkData)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.vehicleParkData = vehicleParkData;
        }

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.vehicleParkData = new VehicleParkData(numberOfSectors);
        }

        public string InsertCar(Car car, int sector, int place, DateTime time)
        {
            var message = this.InsertVehicle(car, sector, place, time);
            return message;
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime time)
        {
            var message = this.InsertVehicle(motorbike, sector, place, time);
            return message;
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime time)
        {
            var message = this.InsertVehicle(truck, sector, place, time);
            return message;
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal payedMoney)
        {
            var vehicle = this.vehicleParkData.GetVehicle(licensePlate);
            if (vehicle == null)
            {
                return string.Format(Message.NoSuchVehicle, licensePlate);
            }

            var startTime = this.vehicleParkData.GetExpectedTimeForVehicle(vehicle);
            int endHours = (int)Math.Round((endTime - startTime).TotalHours);

            var parkedAt = this.vehicleParkData.GetParkedSpot(vehicle);
            var ticket = new Ticket(vehicle, payedMoney, parkedAt, endHours);

            this.vehicleParkData.RemoveVehicle(vehicle);

            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = this.vehicleParkData.ParkingLotStatus();
            var result = places.Select((sector, place) =>
                    string.Format(
                    "Sector {0}: {1} / {2} ({3}% full)",
                    place + 1,
                    Math.Abs(sector),
                    this.layout.PlacesPerSector,
                    Math.Round((double)Math.Abs(sector) / this.layout.PlacesPerSector * 100)));

            return string.Join(Environment.NewLine, result);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.vehicleParkData.GetVehicle(licensePlate);
            if (vehicle == null)
            {
                return string.Format(Message.NoSuchVehicle, licensePlate);
            }

            var parkedAt = this.vehicleParkData.GetParkedSpot(vehicle);
            return string.Format(Message.VehicleParkedAt, vehicle, Environment.NewLine, parkedAt);
        }

        public string FindVehiclesByOwner(string owner)
        {
            var vehicles = this.vehicleParkData.GetVehiclesByOwner(owner);
            if (!vehicles.Any())
            {
                return string.Format(Message.NoVehiclesByOwner, owner);
            }

            var result = new List<string>();
            foreach (var vehicle in vehicles)
            {
                var parkedAt = this.vehicleParkData.GetParkedSpot(vehicle);
                var vehicleResult = string.Format(Message.VehicleParkedAt, vehicle, Environment.NewLine, parkedAt);
                result.Add(vehicleResult);
            }

            return string.Join(Environment.NewLine, result);
        }

        private string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime time)
        {
            if (sector > this.layout.NumberOfSectors)
            {
                return string.Format(Message.NoSector, sector);
            }

            if (place > this.layout.PlacesPerSector)
            {
                return string.Format(Message.NoPlace, place, sector);
            }

            if (!this.vehicleParkData.IsEmptyPlace(sector, place))
            {
                return string.Format(Message.PlaceOccupied, sector, place);
            }

            if (this.vehicleParkData.HasParkedWithLicense(vehicle.LicensePlate))
            {
                return string.Format(Message.DuplicateLicense, vehicle.LicensePlate);
            }

            this.vehicleParkData.InsertVehicle(vehicle, sector, place, time);

            return string.Format(Message.ParkedSucessfully, vehicle.GetType().Name, sector, place);
        }
    }
}