using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private string name;
        private string brand;

        protected Product(string name, string brand, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Gender = gender;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, "Name cannot be null or empty!");
                Validator.CheckIfStringLengthIsValid(value, 10, 3, string.Format("Product name must be between {0} and {1} symbols long!", 3, 10));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, "Brand cannot be null or empty!");
                Validator.CheckIfStringLengthIsValid(value, 10, 2, string.Format("Product brand must be between {0} and {1} symbols long!", 2, 10));
                this.brand = value;
            }
        }
        public abstract decimal Price { get; set; }

        public GenderType Gender { get; private set; }

        public abstract string Print();
    }
}
