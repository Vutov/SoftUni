using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Shapes;

namespace Shapes
{
    class Tests
    {
        static void Main(string[] args)
        {
            var shapes = new List<BasicShape>()
            {
                new Rectangle(20.2, 10.4),
                new Triangle(3, 4, 5),
                new Circle(4)
            };

            shapes.ForEach(x =>
            {
                Console.WriteLine("{0}, P = {1:f}, Area = {2:f}",
                    x.GetType().Name, x.CalculatePerimether(), x.CalculateArea());
            });
        }
    }
}
