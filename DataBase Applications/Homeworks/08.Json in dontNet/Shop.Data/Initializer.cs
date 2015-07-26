using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Web.Script.Serialization;
    using System.Xml.Linq;
    using Models;

    public class Initializer : DropCreateDatabaseIfModelChanges<ProductsEntity>
    {
        protected override void Seed(ProductsEntity context)
        {
            var doc = XDocument.Load("users.xml");
            var users = doc.Root.Elements();
            foreach (XElement user in users)
            {
                var currUser = new User();
                if (user.Attribute("first-name") != null)
                {
                    currUser.FirstName = user.Attribute("first-name").Value;
                }

                if (user.Attribute("last-name") != null)
                {
                    currUser.LastName = user.Attribute("last-name").Value;
                }

                if (user.Attribute("age") != null)
                {
                    currUser.Age = int.Parse(user.Attribute("age").Value);
                }

                context.Users.AddOrUpdate(currUser);
            }

            context.SaveChanges();

            var jsonCategories = File.ReadAllText("categories.json");
            var deserializer = new JavaScriptSerializer();
            var categories = deserializer.Deserialize<JsonCategory[]>(jsonCategories);

            foreach (var category in categories)
            {
                var currCategory = new Category()
                {
                    Name = category.Name
                };

                context.Categories.AddOrUpdate(currCategory);
            }

            context.SaveChanges();

            var json = File.ReadAllText("products.json");
            var products = deserializer.Deserialize<JsonProduct[]>(json);
            var categoryIds = context.Categories.Select(c => c.Id).ToList();
            var usersIds = context.Users.Select(u => u.Id).ToList();
            var rng = new Random();

            foreach (var product in products)
            {
                var sellerId = usersIds[rng.Next(0, usersIds.Count)];
                var buyerId = usersIds[rng.Next(0, usersIds.Count)];
                var categoryId = categoryIds[rng.Next(0, categoryIds.Count)];
                var seller = context.Users.Find(sellerId);
                var buyer = context.Users.Find(buyerId);
                var category = context.Categories.Find(categoryId);
                var currProduct = new Product()
                {
                    Seller = seller,
                    Name = product.Name,
                    Price = product.Price,
                    Categories = new List<Category>()
                    {
                        category
                    }
                };

                // Leaves some products not sold.
                if (rng.Next(0, 10) != 0)
                {
                    currProduct.Buyer = buyer;
                }

                context.Products.AddOrUpdate(currProduct);
            }

            context.SaveChanges();
            

            base.Seed(context);
        }
    }
}
