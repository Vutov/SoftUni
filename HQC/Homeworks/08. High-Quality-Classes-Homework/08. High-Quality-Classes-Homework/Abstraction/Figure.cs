namespace Abstraction
{
    using System;

    abstract class Figure
    {
        private double width;
        private double height;

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (this.IsValidSize(value))
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height; 
            }
            set
            {
                if (this.IsValidSize(value))
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

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

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
