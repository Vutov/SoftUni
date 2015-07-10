namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Report
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var allCategories = dataMapper.GetAllCategories();
            var allProducts = dataMapper.GetAllProducts();
            var allOrders = dataMapper.GetAllOrders();

            // Names of the 5 most expensive products
            var firstProduct = allProducts
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name)
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, firstProduct));
            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var secondProduct = allProducts
                .GroupBy(p => p.CatId)
                .Select(grp => new
                {
                    Category = allCategories.First(c => c.Id == grp.Key).Name,
                    Count = grp.Count()
                })
                .ToList();
            foreach (var item in secondProduct)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var thirdProduct = allOrders
                .GroupBy(id => id.ProductId)
                .Select(grp => new
                {
                    Product = allProducts.First(p => p.Id == grp.Key).Name,
                    Quantities = grp.Sum(grpgrp => grpgrp.Quant)
                })
                .OrderByDescending(q => q.Quantities)
                .Take(5);
            foreach (var item in thirdProduct)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var category = allOrders
                .GroupBy(id => id.ProductId)
                .Select(g => new
                {
                    catId = allProducts.First(p => p.Id == g.Key).CatId,
                    price = allProducts.First(p => p.Id == g.Key).UnitPrice,
                    quantity = g.Sum(p => p.Quant)
                })
                .GroupBy(gg => gg.catId)
                .Select(grp => new
                {
                    category_name = allCategories.First(c => c.Id == grp.Key).Name,
                    total_quantity = grp.Sum(g => g.quantity * g.price)
                })
                .OrderByDescending(g => g.total_quantity)
                .First();
            Console.WriteLine("{0}: {1}", category.category_name, category.total_quantity);
        }
    }
}
