namespace _02.Products_in_Price_Range
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ProductsInPriceRange
    {
        public static void Main(string[] args)
        {
            var productsAndPrices = new OrderedMultiDictionary<int, string>(true);
            var rng = new Random();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 500000; i++)
            {
                var product = GenerateProduct(rng, i);
                var tokens = product.Split('|');
                var name = tokens[0].Trim();
                var price = int.Parse(tokens[1].Trim());
                productsAndPrices.Add(price, name);
            }

            Console.WriteLine("Seed time: " + stopwatch.Elapsed);
            stopwatch.Restart();
            Console.WriteLine("Query Start");
            var printed = new Set<int>();
            for (int i = 0; i < 10000; i++)
            {
                var startPrice = rng.Next(0, 100001);
                var endPrice = rng.Next(startPrice, 100001);
                var productsInRange = productsAndPrices.Range(startPrice, true, endPrice, true).Take(20);
                var count = productsInRange.Count();
                if (!printed.Contains(count))
                {
                    Console.WriteLine("{0} to {1} -> {2}", startPrice, endPrice, count);
                    printed.Add(count);
                }
            }

            Console.WriteLine("Query time: " + stopwatch.Elapsed);
            Console.WriteLine("All Done");
        }

        private static string GenerateProduct(Random rng, int num)
        {
            var product = new StringBuilder();
            product.Append("product");
            product.Append(num);
            product.Append("|");
            var price = rng.Next(1, 100001);
            product.Append(price);

            return product.ToString();
        }
    }
}
