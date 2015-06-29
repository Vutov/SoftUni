using System.Linq;
using Cosmetics.Products;

namespace Cosmetics.Engine
{
    using System.Collections.Generic;
    using Common;
    using Contracts;

    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            var category = new Category(name);

            return category;
        }

        public IShampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            var shampoo = new Shampoo(name, brand, price, gender, milliliters, usage);

            return shampoo;
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            var toothpaste = new Toothpaste(name, brand, price, gender, ingredients.ToArray());

            return toothpaste;
        }

        public IShoppingCart ShoppingCart()
        {
            var shoppingCard = new ShoppingCart();

            return shoppingCard;
        }
    }
}
