using System;

namespace Point3D
{
    class DistanceCalculator
    {
        public static double Distance(Point pointA, Point pointB)
        {
            double deltaX = pointA.X - pointB.X;
            double deltaY = pointA.Y - pointB.Y;
            double deltaZ = pointA.Z - pointB.Z;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

            return distance;
        }
    }
}
