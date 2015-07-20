namespace CodeFirst.DataModel
{
    using System;
    using System.Linq;
    using Data;

    public class Client
    {
        public static void Main(string[] args)
        {
            var context = new MountainsContext();
            var mountains = context.Mountains
                .Select(m => new
                {
                    m.Name,
                    Countries = m.Countries.Select(c => c.CountryName),
                    Peaks = m.Peaks.Select(p => new
                    {
                        p.Name,
                        p.Elevation
                    })
                })
                .ToList();

            mountains.ForEach(m =>
            {
                var countries = m.Countries.ToList();
                Console.WriteLine("{0} in {1} with peaks:", m.Name,
                    string.Join(", ", countries));
                m.Peaks.ToList().ForEach(p =>
                {
                    Console.WriteLine(" {0} : {1} elevation", p.Name, p.Elevation);
                });
            });
        }
    }
}
