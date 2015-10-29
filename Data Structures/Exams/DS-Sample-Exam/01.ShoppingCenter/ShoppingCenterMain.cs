namespace _01.ShoppingCenter
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ShoppingCenterMain
    {
        public static void Main(string[] args)
        {
            var data = new ShoppingCollection();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var regex = @"([^\s]+)\s(.+)";
                var matches = Regex.Matches(line, regex);
                var command = matches[0].Groups[1].ToString().Trim();
                var paramethers = matches[0]
                    .Groups[2]
                    .ToString()
                    .Split(';')
                    .Select(p => p.Trim())
                    .ToArray();
                switch (command)
                {
                    case "AddProduct":
                        data.AddProduct(paramethers);
                        Console.WriteLine("Product added");
                        break;
                    case "DeleteProducts":
                        var message = data.DeleteProducts(paramethers);
                        Console.WriteLine(message);
                        break;
                    case "FindProductsByName":
                        var producstByName = data.FindProductsByName(paramethers);
                        if (!producstByName.Any())
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            foreach (var product in producstByName)
                            {
                                Console.WriteLine(product);
                            }
                        }

                        break;
                    case "FindProductsByProducer":
                        var productsByProducer = data.FindProductsByProducer(paramethers);
                        if (!productsByProducer.Any())
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            foreach (var product in productsByProducer)
                            {
                                Console.WriteLine(product);
                            }
                        }

                        break;
                    case "FindProductsByPriceRange":
                        var productsByPrice = data.FindProductsByPriceRange(paramethers);
                        if (!productsByPrice.Any())
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            foreach (var product in productsByPrice)
                            {
                                Console.WriteLine(product);
                            }
                        }

                        break;
                }
            }
        }
    }
}