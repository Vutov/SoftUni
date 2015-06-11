using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shapes
{
    class Circle : BasicShape
    {

        public Circle(double radius)
            : base(radius)
        {
        }

        public override double CalculateArea()
        {
            double area = Math.PI * Math.Pow(this.Width, 2);

            return area;
        }

        public override double CalculatePerimether()
        {
            double p = 2 * Math.PI * this.Width;

            return p;
        }
    }
}
