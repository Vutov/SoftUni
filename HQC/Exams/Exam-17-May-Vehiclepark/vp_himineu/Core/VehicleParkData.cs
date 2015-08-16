namespace VehicleParkSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Wintellect.PowerCollections;
    
    public class VehicleParkData : IVehicleParkData
    {
        private readonly int[] emptySlotsPerSector;

        private readonly Dictionary<string, IVehicle> parkedSectorsAndPlaces;

        private readonly Dictionary<string, IVehicle> parkedLicensePlates;

        private readonly Dictionary<IVehicle, string> parkedCarsInSectroAndPlace;

        private readonly Dictionary<IVehicle, DateTime> expectedTimePerVehicle;

        private readonly MultiDictionary<string, IVehicle> ownersAndTheirVehicles;

        public VehicleParkData(int numberOfSectors)
        {
            this.parkedCarsInSectroAndPlace = new Dictionary<IVehicle, string>();
            this.parkedSectorsAndPlaces = new Dictionary<string, IVehicle>();
            this.parkedLicensePlates = new Dictionary<string, IVehicle>();
            this.expectedTimePerVehicle = new Dictionary<IVehicle, DateTime>();
            this.ownersAndTheirVehicles = new MultiDictionary<string, IVehicle>(false);
            this.emptySlotsPerSector = new int[numberOfSectors];
        }

        public bool IsEmptyPlace(int sector, int place)
        {
            if (this.parkedSectorsAndPlaces.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return false;
            }

            return true;
        }

        public bool HasParkedWithLicense(string licensePlate)
        {
            if (this.parkedLicensePlates.ContainsKey(licensePlate))
            {
                return true;
            }

            return false;
        }

        public void InsertVehicle(IVehicle vehicle, int sector, int place, DateTime time)
        {
            this.parkedCarsInSectroAndPlace[vehicle] = string.Format("({0},{1})", sector, place);
            this.parkedSectorsAndPlaces[string.Format("({0},{1})", sector, place)] = vehicle;
            this.parkedLicensePlates[vehicle.LicensePlate] = vehicle;
            this.expectedTimePerVehicle[vehicle] = time;
            this.ownersAndTheirVehicles[vehicle.Owner].Add(vehicle);
            this.emptySlotsPerSector[sector - 1]--;
        }

        public string GetParkedSpot(IVehicle vehicle)
        {
            if (!this.parkedCarsInSectroAndPlace.ContainsKey(vehicle))
            {
                throw new InvalidOperationException("No such vehicle");
            }

            return this.parkedCarsInSectroAndPlace[vehicle];
        }

        public DateTime GetExpectedTimeForVehicle(IVehicle vehicle)
        {
            if (!this.expectedTimePerVehicle.ContainsKey(vehicle))
            {
                throw new InvalidOperationException("No such vehicle");
            }

            return this.expectedTimePerVehicle[vehicle];
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            var sectorAndPlace = this.parkedCarsInSectroAndPlace[vehicle];
            this.parkedSectorsAndPlaces.Remove(sectorAndPlace);
            this.parkedCarsInSectroAndPlace.Remove(vehicle);
            this.parkedLicensePlates.Remove(vehicle.LicensePlate);
            this.expectedTimePerVehicle.Remove(vehicle);
            this.ownersAndTheirVehicles.Remove(vehicle.Owner, vehicle);
            int sector = int.Parse(sectorAndPlace.Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            this.emptySlotsPerSector[sector - 1]++;
        }

        public IVehicle GetVehicle(string licensePlate)
        {
            if (this.parkedLicensePlates.ContainsKey(licensePlate))
            {
                return this.parkedLicensePlates[licensePlate];
            }

            return null;
        }

        public int[] ParkingLotStatus()
        {
            return this.emptySlotsPerSector;
        }

        // Performance : changes the used dictionary from placesAndSectors to ownersAndTheirVehicles.
        // That way vehicles are get directly without searching.
        public IEnumerable<IVehicle> GetVehiclesByOwner(string owner)
        {
            var vehicles = this.ownersAndTheirVehicles[owner].ToList();
            return vehicles.OrderBy(v => this.expectedTimePerVehicle[v])
                    .ThenBy(v => v.LicensePlate);
        }
    }
}