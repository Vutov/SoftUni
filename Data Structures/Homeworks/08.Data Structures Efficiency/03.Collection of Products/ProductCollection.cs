namespace _03.Collection_of_Products
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class ProductCollection
    {
        private readonly Dictionary<int, Product> productsById;
        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice;
        private readonly OrderedMultiDictionary<string, Product> productsByTitle;
        private readonly OrderedMultiDictionary<string, Product> productsByTitleAndPrice;
        private readonly OrderedDictionary<string, OrderedMultiDictionary<decimal, Product>> productsByTitleAndPriceRange;
        private readonly OrderedMultiDictionary<string, Product> productsBySupplierAndPrice;
        private readonly OrderedDictionary<string, OrderedMultiDictionary<decimal, Product>> productsBySupplierAndPriceRange;


        public ProductCollection()
        {
            this.productsById = new Dictionary<int, Product>();
            this.productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
            this.productsByTitle = new OrderedMultiDictionary<string, Product>(true);
            this.productsByTitleAndPrice = new OrderedMultiDictionary<string, Product>(true);
            this.productsByTitleAndPriceRange = new OrderedDictionary<string, OrderedMultiDictionary<decimal, Product>>();
            this.productsBySupplierAndPrice = new OrderedMultiDictionary<string, Product>(true);
            this.productsBySupplierAndPriceRange = new OrderedDictionary<string, OrderedMultiDictionary<decimal, Product>>();
        }


        public void Add(Product product)
        {
            this.productsById.Add(product.Id, product);
            this.productsByPrice.Add(product.Price, product);
            this.productsByTitle.Add(product.Title, product);
            this.productsByTitleAndPrice.Add(product.Title + "_" + product.Price, product);
            if (!this.productsByTitleAndPriceRange.ContainsKey(product.Title))
            {
                this.productsByTitleAndPriceRange.Add(product.Title, new OrderedMultiDictionary<decimal, Product>(true));
            }

            this.productsByTitleAndPriceRange[product.Title][product.Price].Add(product);
            this.productsBySupplierAndPrice.Add(product.Supplier + "_" + product.Price, product);
            if (!this.productsBySupplierAndPriceRange.ContainsKey(product.Supplier))
            {
                this.productsBySupplierAndPriceRange.Add(product.Supplier, new OrderedMultiDictionary<decimal, Product>(true));                
            }

            this.productsBySupplierAndPriceRange[product.Supplier][product.Price].Add(product);
        }

        public void Remove(int id)
        {
            var product = this.productsById[id];
            this.productsByPrice.Remove(product.Price, product);
            this.productsByTitle.Remove(product.Title, product);
            this.productsByTitleAndPrice.Remove(product.Title + "_" + product.Price, product);
            this.productsByTitleAndPriceRange[product.Title].Remove(product.Price, product);
            if (this.productsByTitleAndPriceRange[product.Title].Count == 0)
            {
                this.productsByTitleAndPriceRange.Remove(product.Title);
            }

            this.productsBySupplierAndPrice.Remove(product.Supplier + "_" + product.Price, product);
            this.productsBySupplierAndPriceRange[product.Supplier].Remove(product.Price, product);
            if (this.productsBySupplierAndPriceRange[product.Supplier].Count == 0)
            {
                this.productsBySupplierAndPriceRange.Remove(product.Supplier);
            }

        }

        public OrderedMultiDictionary<decimal, Product>.View FindByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return this.productsByPrice.Range(minPrice, true, maxPrice, true);
        }

        public IEnumerable<Product> FindByTitle(string title)
        {
            return this.productsByTitle[title];
        }

        public IEnumerable<Product> FindByTitleAndPrice(string title, decimal price)
        {
            return this.productsByTitleAndPrice[title + "_" + price];
        }


        public OrderedMultiDictionary<decimal, Product>.View FindByTitleAndPriceRange(string title, decimal minPrice, decimal maxPrice)
        {
            return this.productsByTitleAndPriceRange[title].Range(minPrice, true, maxPrice, true);
        }

        public IEnumerable<Product> FindBySupplier(string supplier, decimal price)
        {
            return this.productsBySupplierAndPrice[supplier + "_" + price];
        }

        public OrderedMultiDictionary<decimal, Product>.View FindBySupplierAndRange(string supplier, decimal minPrice, decimal maxPrice)
        {
            return this.productsBySupplierAndPriceRange[supplier].Range(minPrice, true, maxPrice, true);
        }
    }
}
