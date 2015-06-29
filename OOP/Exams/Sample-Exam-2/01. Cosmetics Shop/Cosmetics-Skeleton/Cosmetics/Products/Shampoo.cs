using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private decimal price;
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price = price;
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage { get; private set; }

        public override decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = Milliliters * value;
            }
        }

        public override string Print()
        {
            var result = string.Format(@"- {0} - {1}:
  * Price: ${2}
  * For gender: {3}
  * Quantity: {4} ml
  * Usage: {5}",
               this.Brand, this.Name, this.Price, this.Gender, this.Milliliters, this.Usage);

            return "\n" + result;
        }
    }
}
