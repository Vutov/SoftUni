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
        }
    }
}
