namespace Abstraction
{
    using System;

    class Circle : Figure
    {
        public Circle(double radius) : base(radius, 0) 
        {
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Width;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Width * this.Width;
            return surface;
        }
    }
}
