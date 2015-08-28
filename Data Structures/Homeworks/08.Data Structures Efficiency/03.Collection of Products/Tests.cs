namespace _03.Collection_of_Products
{
    using System;

    public class Tests
    {
        public static void Main(string[] args)
        {
            var collection = new ProductCollection();
            collection.Add(new Product(1, "a", "b", 1));
            collection.Add(new Product(10, "s", "b", 1));
            collection.Add(new Product(2, "aa", "b1", 2));
            collection.Add(new Product(3, "aaa", "b", 3));
            collection.Add(new Product(4, "a2", "b1", 4));
            collection.Add(new Product(5, "a3", "b", 5));
            collection.Add(new Product(6, "a", "b1", 6));

            var supplier = collection.FindBySupplier("b", 1);
            foreach (var product in supplier)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Remove 1");
            collection.Remove(1);

            supplier = collection.FindBySupplier("b", 1);
            foreach (var product in supplier)
            {
                Console.WriteLine(product);
            }

            var pricesInRange = collection.FindByPriceRange(1, 5);
            foreach (var product in pricesInRange)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            var byTitleAndPrice = collection.FindByTitleAndPrice("s", 1);
            foreach (var product in byTitleAndPrice)
            {
                Console.WriteLine(product);
            }

            var supplerAndRange = collection.FindBySupplierAndRange("b1", 2, 4);
            foreach (var product in supplerAndRange)
            {
                Console.WriteLine(product);
            }
        }
    }
}
