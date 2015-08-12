namespace _01.DistanceCalculator
{
    using System;
    using System.Drawing;

    public class DistanceService : IDistanceService
    {
        public double CalcDistance(Point startPoint, Point endPoint)
        {
            double deltaX = startPoint.X - endPoint.X;
            double deltaY = startPoint.Y - endPoint.Y;

            var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }
}
