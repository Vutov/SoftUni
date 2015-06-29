using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        public Toothpaste(string name, string brand, decimal price, GenderType gender, params string[] ingrediants)
            : base(name, brand, gender)
        {
            ingrediants.ToList().ForEach(i =>
            {
                var error = string.Format("Each ingredient must be between {0} and {1} symbols long!", 4, 12);
                Validator.CheckIfStringLengthIsValid(i, 12, 4, error);
            });

            this.Ingredients = string.Join(", ", ingrediants);
            this.Price = price;
        }

        public string Ingredients { get; private set; }

        public override decimal Price { get; set; }

        public override string Print()
        {
            var result = string.Format(@"- {0} - {1}:
  * Price: ${2}
  * For gender: {3}
  * Ingredients: {4}",
                this.Brand, this.Name, this.Price, this.Gender, this.Ingredients);

            return "\n" + result;
        }
    }
}
