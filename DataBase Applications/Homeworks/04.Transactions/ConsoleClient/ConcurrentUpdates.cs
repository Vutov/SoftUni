using System.Data.Entity.Infrastructure;
using Models;

namespace ConsoleClient
{
    using System;
    using System.Linq;
    using Data;

    class ConcurrentUpdates
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application started.");
            using (var context = new NewsDb())
            {
                var news = context.News.ToList();
                var count = 1;
                news.ForEach(n =>
                {
                    Console.WriteLine("{0}. {1}", count, n.Content);
                    count++;
                });

                var continueReading = true;
                while (continueReading)
                {
                    Console.WriteLine("Enter news content:");
                    var content = Console.ReadLine();
                    var newNews = new News() { Content = content };
                    context.News.Add(newNews);

                    try
                    {
                        context.SaveChanges();
                        continueReading = false;
                        Console.WriteLine("Changes successfully saved in the DB.");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Conflict! Text from DB: {0}", content);
                    }
                }
            }
        }
    }
}
