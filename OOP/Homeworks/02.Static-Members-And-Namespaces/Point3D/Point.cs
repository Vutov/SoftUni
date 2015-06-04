using System;

namespace Point3D
{
    public class Point
    {
        static readonly Point StartingPoints = new Point(0, 0, 0);

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point StartingPoint()
        {
            return StartingPoints;
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", this.X, this.Y, this.Z);
        }
    }
}
