namespace VehicleParkSystem
{
    public static class Message
    {
        public const string VehicleParkNotSetUp = "The vehicle park has not been set up";
        public const string VehicleParkCreated = "Vehicle park created";
        public const string NoSector = "There is no sector {0} in the park";
        public const string NoPlace = "There is no place {0} in sector {1}";
        public const string PlaceOccupied = "The place ({0},{1}) is occupied";
        public const string DuplicateLicense = "There is already a vehicle with license plate {0} in the park";
        public const string ParkedSucessfully = "{0} parked successfully at place ({1},{2})";
        public const string NoSuchVehicle = "There is no vehicle with license plate {0} in the park";
        public const string VehicleParkedAt = "{0}{1}Parked at {2}";
        public const string NoVehiclesByOwner = "No vehicles by {0}";
    }
}
