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
            Point somePoint = new Point(10, 2, 100);
            Point otherPoint = new Point(40, 50, 70);
            Console.WriteLine("Starting points {0}", Point.StartingPoint());
            Console.WriteLine("Current coordinates {0}", somePoint);
            double dist = DistanceCalculator.Distance(somePoint, otherPoint);
            Console.WriteLine("Distance between {0} and {1} : {2:F}", somePoint, otherPoint, dist);
        }
    }
}
