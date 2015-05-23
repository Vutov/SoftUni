using System;

namespace Abstraction
{
    abstract class Figure
    {
        private double width;
        private double height;

        public double Width
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
        public double Height
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

        protected Figure(double width = 0, double height = 0)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double CalcPerimeter()
        {
            throw new NotImplementedException();
        }

        public virtual double CalcSurface()
        {
            throw new NotImplementedException();
        }

        private bool IsValidSize(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Side cannot be negative!");
            }

            return true;
        }
    }
}
