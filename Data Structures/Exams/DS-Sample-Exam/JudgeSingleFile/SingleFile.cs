namespace _01.ShoppingCenter
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ShoppingCenter
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
namespace _01.ShoppingCenter
{
    using System;

    public class Product : IComparable<Product>, IEquatable<Product>
    {
        public Product(int id, string name, decimal price, string producer)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Producer != other.Producer)
            {
                return this.Producer.CompareTo(other.Producer);
            }

            if (this.Price != other.Price)
            {
                return this.Price.CompareTo(other.Price);
            }

            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(Product other)
        {
            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("f2"));
        }
    }
}
namespace _01.ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ShoppingCollection
    {
        private int nextId;
        private readonly Dictionary<string, OrderedSet<Product>> productsByName;
        private readonly Dictionary<string, OrderedSet<Product>> productsByProducer;
        private readonly Dictionary<string, OrderedSet<Product>> productsByNameAndProducer;
        private readonly OrderedDictionary<decimal, OrderedSet<Product>> productsByPrice;

        public ShoppingCollection()
        {
            this.nextId = 0;
            this.productsByName = new Dictionary<string, OrderedSet<Product>>();
            this.productsByProducer = new Dictionary<string, OrderedSet<Product>>();
            this.productsByNameAndProducer = new Dictionary<string, OrderedSet<Product>>();
            this.productsByPrice = new OrderedDictionary<decimal, OrderedSet<Product>>();
        }

        public int NextId
        {
            get
            {
                this.nextId++;
                return this.nextId;
            }
            set
            {
                this.nextId = value;
            }
        }

        public void AddProduct(string[] paramethers)
        {
            var name = paramethers[0];
            var price = decimal.Parse(paramethers[1]);
            var producer = paramethers[2];
            var product = new Product(this.NextId, name, price, producer);

            // Products by name
            if (!this.productsByName.ContainsKey(name))
            {
                this.productsByName.Add(name, new OrderedSet<Product>());
            }

            this.productsByName[name].Add(product);

            // Products by producer
            if (!this.productsByProducer.ContainsKey(producer))
            {
                this.productsByProducer.Add(producer, new OrderedSet<Product>());
            }

            this.productsByProducer[producer].Add(product);

            // Products by name and producer
            var key = this.CombineNameAndProducerAsKey(name, producer);
            if (!this.productsByNameAndProducer.ContainsKey(key))
            {
                this.productsByNameAndProducer.Add(key, new OrderedSet<Product>());
            }

            this.productsByNameAndProducer[key].Add(product);

            // Products by price
            if (!this.productsByPrice.ContainsKey(price))
            {
                this.productsByPrice.Add(price, new OrderedSet<Product>());
            }

            this.productsByPrice[price].Add(product);
        }

        public IEnumerable<Product> FindProductsByPriceRange(string[] paramethers)
        {
            var fromPrice = decimal.Parse(paramethers[0]);
            var toPrice = decimal.Parse(paramethers[1]);
            var products = this.productsByPrice.Range(fromPrice, true, toPrice, true);
            var result = new OrderedSet<Product>();
            foreach (var price in products)
            {
                foreach (var product in price.Value)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public IEnumerable<Product> FindProductsByProducer(string[] paramethers)
        {
            var producer = paramethers[0];
            if (this.productsByProducer.ContainsKey(producer))
            {
                var products = this.productsByProducer[producer];
                return products;
            }

            return new List<Product>();
        }

        public IEnumerable<Product> FindProductsByName(string[] paramethers)
        {
            var name = paramethers[0];
            if (this.productsByName.ContainsKey(name))
            {
                var products = this.productsByName[name];
                return products;
            }

            return new List<Product>();
        }

        public string DeleteProducts(string[] paramethers)
        {
            if (paramethers.Count() == 1)
            {
                var deletedElements = this.DeleteByProducer(paramethers[0]);
                if (deletedElements == 0)
                {
                    return "No products found";
                }

                return deletedElements + " products deleted";
            }
            else
            {
                var deletedElements = this.DeleteByNameAndProducer(paramethers[0], paramethers[1]);
                if (deletedElements == 0)
                {
                    return "No products found";
                }

                return deletedElements + " products deleted";
            }
        }

        private int DeleteByProducer(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                var products = this.productsByProducer[producer];
                var deletedProducts = products.Count;
                while (products.Count != 0)
                {
                    this.DeleteProduct(products.GetLast());
                }

                return deletedProducts;
            }

            return 0;
        }

        private int DeleteByNameAndProducer(string name, string producer)
        {
            var key = this.CombineNameAndProducerAsKey(name, producer);
            if (this.productsByNameAndProducer.ContainsKey(key))
            {
                var products = this.productsByNameAndProducer[key];
                var deletedProducts = products.Count;
                while (products.Count != 0)
                {
                    this.DeleteProduct(products.GetLast());
                }

                return deletedProducts;
            }

            return 0;
        }

        private void DeleteProduct(Product product)
        {
            this.productsByName[product.Name].Remove(product);
            this.productsByProducer[product.Producer].Remove(product);
            this.productsByPrice[product.Price].Remove(product);
            var key = this.CombineNameAndProducerAsKey(product.Name, product.Producer);
            this.productsByNameAndProducer[key].Remove(product);
        }

        private string CombineNameAndProducerAsKey(string name, string producer)
        {
            return name + "|-|" + producer;
        }
    }
}