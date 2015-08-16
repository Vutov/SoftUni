namespace VehicleParkSystem.Core
{
    using System;

    public class Layout
    {
        private int numberOfSectors;
        private int placesPerSector;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            this.numberOfSectors = numberOfSectors;
            this.placesPerSector = placesPerSector;
        }

        public int NumberOfSectors
        {
            get
            {
                return this.numberOfSectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of sectors must be positive.");
                }

                this.numberOfSectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }
    }
}