using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcCatalog
{
    class Computer
    {
        private string name;
        private List<Component> components;
        private decimal price = 0;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length >= 5)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name must be at least 5 symbols long!");
                }
            }
        }

        public List<Component> Components
        {
            get { return this.components; }
            set
            {
                this.components = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                decimal totalPrice = this.Components.Sum(component => component.Price);
                this.price = totalPrice;
            }
        }

        public Computer(string name, List<Component> components)
        {
            this.Name = name;
            this.Components = components;
            this.Price = components.Sum(component => component.Price);
        }

        public Computer(string name) : this(name, new List<Component>()) { }

        public void GetComponents()
        {
            Console.Write("Components: ");
            if (components.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine();
                foreach (var component in this.Components)
                {
                    Console.WriteLine("{0} witch costs: {1:f} BGN", component.Name, component.Price);
                }
            }
        }

        public void GetPrice()
        {
            Console.WriteLine("Total price is: {0:f}", this.price);
        }

        public void GetName()
        {
            Console.WriteLine("Computers name is: {0}", this.name);
        }

        public override string ToString()
        {
            return string.Format("Computer name: {0}\nprice: {1}", this.name, this.price);
        }
    }
}
