namespace EnvironmentSystem.Models
{
    using System;

    public class Point : IEquatable<Point>, ICloneable
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public object Clone()
        {
            return new Point(this.X, this.Y);
        }
    }
}
