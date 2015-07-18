using System.Linq;
using System.Runtime.InteropServices;

namespace Entity
{
    using System;
    using System.Data.Entity;

    class Problems
    {
        private static void Main(string[] args)
        {
            using (var context = new AdsEntities())
            {
                // 01.Show Data from Related Tables

                // 98 requests
                var ads = context.Ads;
                foreach (var ad in ads)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}",
                        ad.Title, ad.AdStatus.Status,
                        (ad.CategoryId != null) ? ad.Category.Name : "no data",
                        (ad.TownId != null) ? ad.Town.Name : "no data",
                        ad.AspNetUser.Name);
                }

                // 4 requests
                var otherAds = context.Ads.Include(a => a.AdStatus)
                    .Include(a => a.Category).Include(a => a.Town)
                    .Include(a => a.AspNetUser);
                foreach (var ad in otherAds)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}",
                        ad.Title, ad.AdStatus.Status,
                        (ad.CategoryId != null) ? ad.Category.Name : "no data",
                        (ad.TownId != null) ? ad.Town.Name : "no data",
                        ad.AspNetUser.Name);
                }

                // 02.Play with ToList()
                Console.WriteLine();

                // 80 requests
                var allAds = context.Ads
                    .ToList()
                    .Where(a => a.AdStatus.Status.Equals("Published"))
                    .OrderBy(a => a.Date)
                    .SelectMany(a => new[]
                    {
                        a.Title,
                        (a.CategoryId != null) ? a.Category.Name : "no category",
                        (a.TownId != null) ? a.Town.Name : "no town"
                    })
                    .ToList();
                for (int i = 0; i < allAds.Count; i += 3)
                {
                    Console.WriteLine("{0} {1} {2}", allAds[i], allAds[i + 1], allAds[i + 2]);
                }

                // 4 requests
                var properWaysAds = context.Ads
                    .Where(a => a.AdStatus.Status.Equals("Published"))
                    .OrderBy(a => a.Date)
                    .Include(a => a.Category)
                    .Include(a => a.Town).ToList();
                properWaysAds.ForEach(a =>
                {
                    Console.WriteLine("{0} {1} {2}",
                        a.Title,
                        (a.CategoryId != null) ? a.Category.Name : "no category",
                        (a.TownId != null) ? a.Town.Name : "no town");
                });

                // 03.Select Everything vs. Select Certain Columns
                Console.WriteLine();

                // 4 requests
                var start = DateTime.Now;
                var allData = context.Ads;
                foreach (var ad in allData.Take(4))
                {
                    Console.WriteLine("{0}", ad.Title);
                }

                Console.WriteLine("{0}", DateTime.Now - start);
                Console.WriteLine();

                // 4 requests
                start = DateTime.Now;
                var selectedData = context.Ads.Select(a => a.Title);
                foreach (var ad in selectedData.Take(4))
                {
                    Console.WriteLine(ad);
                }

                Console.WriteLine("{0}", DateTime.Now - start);
                Console.WriteLine();
            }
        }
    }
}
