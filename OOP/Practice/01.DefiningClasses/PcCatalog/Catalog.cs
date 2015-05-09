using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcCatalog
{
    class Catalog
    {
        static void Main(string[] args)
        {
            List<Component> parts = new List<Component>()
            {
                new Component("CPU", 123.4M, "good"),
                new Component("RAM", 23.4M, "bad"),
                new Component("Screen", 13.4M),
                new Component("CD", 12.4M, "nice"),
                new Component("Motherboard", 1213.4M)
            };
            Computer myComputer = new Computer("My Pc", parts);
            Computer newComputer = new Computer("Other PC");
            Computer newComp = new Computer("New PC", new List<Component>()
            {
                new Component("CPU", 0.4M, "good"),
                new Component("RAM", 0.004M, "bad"),
            });
            myComputer.GetName();
            myComputer.GetComponents();
            myComputer.GetPrice();
            Console.WriteLine();
            newComputer.GetName();
            newComputer.GetComponents();
            newComputer.GetPrice();
            Console.WriteLine();
            List<Computer> computers = new List<Computer>() { myComputer, newComputer, newComp };
            computers.Sort((x, y) => (int)(x.Price - y.Price));
            computers.ForEach(Console.WriteLine);
        }
    }
}
