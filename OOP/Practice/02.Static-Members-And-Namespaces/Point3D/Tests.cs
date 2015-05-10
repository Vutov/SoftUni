using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    class Tests
    {
        static void Main(string[] args)
        {
            Point somePoint = new Point(1, 2);
            Console.WriteLine(Point.StartingPoint());
            Console.WriteLine(somePoint);
            double dist = DistanceCalculator.Distance(somePoint, new Point());
            Console.WriteLine(dist);
        }
    }
}
