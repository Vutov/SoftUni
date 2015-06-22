using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Country
{
    class Country : ICloneable, IComparable
    {
        private string name;
        private long population;
        private double area;
        private IList<string> cities;

        public Country(string name, long population, double area, IList<string> cities)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
            this.Cities = cities;
        }

        public string Name
        {
            get
            {
                return this.name;

            }
            set
            {
                if (value.Length != 0)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
            }
        }

        public long Population
        {
            get
            {
                return this.population;

            }
            set
            {
                if (value >= 0)
                {
                    this.population = value;
                }
                else
                {
                    throw new ArgumentException("Population cannot be negative!");
                }
            }
        }

        public double Area
        {
            get
            {
                return this.area;

            }
            set
            {
                if (value > 0)
                {
                    this.area = value;
                }
                else
                {
                    throw new ArgumentException("Area cannot be 0 or below!");
                }
            }
        }

        public IList<string> Cities { get; set; }

        public object Clone()
        {
            return new Country(this.Name, this.Population, this.Area, new List<string>(this.Cities));
        }

        public int CompareTo(object other)
        {
            var country = other as Country;
            if (country != null)
            {
                if (country.Area > this.Area)
                {
                    return 1;
                }

                if (country.Population > this.Population)
                {
                    return 1;
                }

                return country.Name.CompareTo(this.Name);
            }

            return 0;
        }

        public override bool Equals(object other)
        {
            
            if (other is Country)
            {
                var country = other as Country;
                if (country.Name == this.Name)
                {
                    return true;
                }
            }


            return false;
        }

        public override int GetHashCode()
        {
            return this.Population.GetHashCode() ^ this.Population.GetHashCode();
        }

        public static bool operator ==(Country first, Country second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Country first, Country second)
        {
            return !first.Equals(second);
        }
    }
}
