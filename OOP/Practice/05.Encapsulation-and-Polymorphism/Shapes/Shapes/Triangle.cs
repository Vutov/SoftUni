using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shapes
{
    class Triangle : BasicShape
    {
        private double sideC;

        public double SideC
        {
            get { return this.sideC; }
            set
            {
                if (IsValidSize(value))
                {
                    this.sideC = value;
                }
            }
        }

        public Triangle(double sideA, double sideB, double sideC)
            : base(sideA, sideB)
        {
            this.SideC = sideC;
        }

        /// <summary>
        /// Calculates area of the triangle, if the given sides cannot make triangle
        /// return NaN.
        /// </summary>
        /// <returns>double area or NaN</returns>
        public override double CalculateArea()
        {
            double halfPerimeter = this.CalculatePerimether() / 2;

            double areaSquared = halfPerimeter;
            areaSquared *= halfPerimeter - this.Width;
            areaSquared *= halfPerimeter - this.Height;
            areaSquared *= halfPerimeter - this.SideC;

            double area = Math.Sqrt(areaSquared);

            return area;
        }

        public override double CalculatePerimether()
        {
            double P = this.Width + this.Height + this.sideC;

            return P;
        }
    }
}
