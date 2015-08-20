namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Models;

    public class DbInizializer : DropCreateDatabaseIfModelChanges<BookShopContext>
    {
        protected override void Seed(BookShop.Data.BookShopContext context)
        {
            var random = new Random();

            using (var authorReader = new StreamReader("../../../authors.txt"))
            {
                var aurthorLine = authorReader.ReadLine();
                aurthorLine = authorReader.ReadLine();
                while (aurthorLine != null)
                {
                    var authorData = aurthorLine.Split(' ');
                    var author = new Author() { FirstName = authorData[0], LastName = authorData[1] };
                    context.Authors.Add(author);

                    aurthorLine = authorReader.ReadLine();
                }
            }

            context.SaveChanges();

            var authors = context.Authors.ToList();
            using (var reader = new StreamReader("../../../books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = random.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (EditionType)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                    var title = data[5];

                    context.Books.Add(new Book()
                    {
                        Author = author,
                        EditionType = edition,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title
                    });

                    line = reader.ReadLine();
                }
            }

            context.SaveChanges();

            var books = context.Books.ToList();
            using (var categoriesReader = new StreamReader("../../../categories.txt"))
            {
                var categoryName = categoriesReader.ReadLine();
                while (categoryName != null)
                {
                    var bookIndex = random.Next(0, books.Count);
                    var category = new Category() { Name = categoryName, BookId = bookIndex };
                    context.Categories.Add(category);

                    categoryName = categoriesReader.ReadLine();
                }
            }

            base.Seed(context);
        }
    }
}
