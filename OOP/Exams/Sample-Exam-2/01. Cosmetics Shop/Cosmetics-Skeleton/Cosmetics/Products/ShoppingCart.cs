using System.Collections.Generic;
using Cosmetics.Contracts;

namespace Cosmetics.Engine
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly List<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.products.Contains(product);
        }

        public decimal TotalPrice()
        {
            var totalPrice = 0M;
            this.products.ForEach(p => totalPrice += p.Price);

            return totalPrice;
        }
    }
}
