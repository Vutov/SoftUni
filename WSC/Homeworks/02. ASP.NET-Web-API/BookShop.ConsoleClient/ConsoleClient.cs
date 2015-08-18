namespace BookShop.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;

    public class ConsoleClient
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();
            var bookCount = context.Books.Count();
            Console.WriteLine(bookCount);

            var booksAfter2000 = context.Books
                .Where(b => b.ReleaseDate >= new DateTime(2000, 1, 1))
                .Select(b => b.Title)
                .ToList();
            //booksAfter2000.ForEach(Console.WriteLine);

            var authors = context.Authors
                .Where(a => a.Books.Any(b => b.ReleaseDate <= new DateTime(1990, 1, 1)))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .ToList();
            //authors.ForEach(a => Console.WriteLine("{0} {1}", a.FirstName, a.LastName));

            var georgeBooks = context.Books
                .Where(b => b.Author.FirstName + " " + b.Author.LastName == "George Powell")
                .OrderByDescending(b => b.ReleaseDate)
                .ThenBy(b => b.Title)
                .Select(b => new
                {
                    b.Title,
                    b.ReleaseDate,
                    b.Copies
                })
                .ToList();
            //georgeBooks.ForEach(b => Console.WriteLine("{0} {1:dd-MM-yyyy} {2}", b.Title, b.ReleaseDate, b.Copies));
        }
    }
}
