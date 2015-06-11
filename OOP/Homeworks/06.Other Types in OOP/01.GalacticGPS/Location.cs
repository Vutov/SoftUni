using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GalacticGPS
{
    struct Location
    {
        private double latitude;
        private double longtitude;
        private Planet planet;

        public Location(double latitude, double longtitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longtitude = longtitude;
            this.Planet = planet;
        }

        public double Latitude {
            get
            {
                return this.latitude;
                
            }
            set
            {
                if (value < -90 || 90 < value)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.latitude = value;
            } 
        }

        public double Longtitude
        {
            get
            {
                return this.longtitude;
                
            }
            set
            {
                if (value < -180 || 180 < value)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.longtitude = value;
            }
        }

        public Planet Planet { get; set; }

        public override string ToString()
        {
            var result = string.Format("{0}, {1} - {2}", this.Latitude, this.Longtitude, this.Planet);

            return result;
        }
    }
}
