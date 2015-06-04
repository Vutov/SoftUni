using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point3D;

namespace Paths
{
    class Tests
    {
        static void Main(string[] args)
        {
            Storage.Save("1 2 3|12 34 4", "saved");
            var points = new List<Point>
            {
                new Point(1 , 3, 5),
                new Point(2 , 3, 5),
                new Point(5 , 13, 51),
                new Point(1 , 3, 25),
                new Point(1 , 3, 5),
                new Point(4 , 3, 6),
            };

            Storage.Save(points, "saved1");

            var loadedPoints = Storage.Load("saved1");
            var path = new Path3D(loadedPoints);

            Console.WriteLine(path);
        }
    }
}
