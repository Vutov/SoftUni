using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop
{
    class Battery
    {
        private string name;
        private double life;

        public Battery(string name, double life)
        {
            this.Name = name;
            this.Life = life;
        }

        public Battery(string name) : this(name, 0.0) { }

        public Battery() : this("", 0.0) { }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Battery must have name");
                }
            }
        }

        public double Life
        {
            get { return this.life; }
            set
            {
                if (value >= 0)
                {
                    this.life = value;
                }
                else
                {
                    throw new ArgumentException("Battery life must be positive");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("battery: {0}\nbattery life: {1}", this.name, this.life);
        }
    }
}
