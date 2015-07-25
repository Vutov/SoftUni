using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Client
{
    using System.Web.Script.Serialization;
    using System.Xml.Linq;
    using Data;

    public class Client
    {
        public static void Main(string[] args)
        {
            var context = new ProductsEntity();
            var serializer = new JavaScriptSerializer();

            // Products In Range

            var productsInRange = context.Products
                .Where(p => p.Buyer == null)
                .OrderByDescending(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            var serializedProductsInRange = serializer.Serialize(productsInRange);

            // Uncomment for the result, it might look nasty since it is formatted
            // without any spaces.
            //Console.WriteLine(serializedProductsInRange);

            // Successfully Sold Products
            var soldProduct = context.Users
                .Where(u => u.ProductsSold.Count > 1 &&
                            u.ProductsSold.Where(p => p.Buyer != null).Count() > 0)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastname = u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        pice = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .ToList();

            var serializedSoldProduct = serializer.Serialize(soldProduct);
            //Console.WriteLine(serializedSoldProduct);

            // Categories By Products Count
            var productsByCategory = context.Categories
                .OrderByDescending(c => c.Products.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count,
                    averagePrice = c.Products.Average(p => p.Price),
                    totalRavenue = c.Products.Sum(p => p.Price)
                })
                .ToList();

            var serializedProductsByCategory = serializer.Serialize(productsByCategory);
            //Console.WriteLine(serializedProductsByCategory);

            // Users and Products
            var xmlUsers = context.Users
                .Where(u => u.ProductsSold.Count > 1 &&
                            u.ProductsSold.Where(p => p.Buyer != null).Count() > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    Products = u.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                })
                .ToList();

            var xml = new XDocument();
            var root = new XElement("users");
            root.SetAttributeValue("count", xmlUsers.Count);
            xml.Add(root);

            foreach (var user in xmlUsers)
            {
                var userNode = new XElement("user");
                if (user.FirstName != null)
                {
                    userNode.SetAttributeValue("first-name", user.FirstName);
                }

                if (user.LastName != null)
                {
                    userNode.SetAttributeValue("last-name", user.LastName);
                }

                if (user.Age != 0)
                {
                    userNode.SetAttributeValue("age", user.Age);
                }

                var productsNode = new XElement("sold-products");
                productsNode.SetAttributeValue("count", user.Products.Count());
                foreach (var product in user.Products)
                {
                    var productNode = new XElement("product");
                    productNode.SetAttributeValue("name", product.Name);
                    productNode.SetAttributeValue("price", product.Price);

                    productsNode.Add(productNode);
                }

                userNode.Add(productsNode);
                root.Add(userNode);
            }

            //Console.WriteLine(xml);
        }
    }
}
