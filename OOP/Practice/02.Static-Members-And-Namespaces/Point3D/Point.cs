using System;

namespace Point3D
{
    public class Point
    {

        static readonly Point startingPoint = new Point();
        private double x;
        private double y;
        private double z;

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point(double x = 0, double y = 0, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point StartingPoint()
        {
            return startingPoint;
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", this.x, this.y, this.z);
        }
    }
}
