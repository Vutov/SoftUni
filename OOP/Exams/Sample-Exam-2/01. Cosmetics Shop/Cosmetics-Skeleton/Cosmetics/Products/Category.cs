using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category: ICategory
    {
        private string name;
        private readonly List<IProduct> products; 

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
                
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value, 15, 2, string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                            "Category name", 2, 15)
                );
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.products.Contains(cosmetics))
            {
                var error = string.Format("Product {0} does not exist in category {1}!",
                    cosmetics.Name, this.Name);
                throw new ArgumentException(error);
            }

             this.products.Remove(cosmetics);
        }

        public string Print()
        {
            var sortedProducts = this.products
                .OrderBy(p => p.Brand)
                .ThenByDescending(p => p.Price)
                .ToList();
            var result = new StringBuilder();
            var productString = "products";
            if (this.products.Count == 1)
            {
                productString = "product";
            }

            var categoryInfo = string.Format("{0} category - {1} {2} in total", this.Name,
                this.products.Count, productString);
            result.Append(categoryInfo);
            sortedProducts.ForEach(p => result.Append(p.Print()));

            return result.ToString();
        }
    }
}
