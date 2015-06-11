using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Shapes
{
    abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        protected double Width
        {
            get { return this.width; }
            set
            {
                if (IsValidSize(value))
                {
                    this.width = value;
                }
            }
        }

        protected double Height
        {
            get { return this.height; }
            set
            {
                if (IsValidSize(value))
                {
                    this.height = value;
                }
            }
        }

        protected BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        protected BasicShape(double radius)
        {
            this.Width = radius;
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimether();

        protected static bool IsValidSize(double size)
        {
            if (size >= 0)
            {
                return true;
            }

            throw new ArgumentException("Cannot be negative size");
        }
    }
}
