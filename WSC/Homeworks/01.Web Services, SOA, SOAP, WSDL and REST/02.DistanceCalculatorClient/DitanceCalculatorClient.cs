namespace _02.DistanceCalculatorClient
{
    using System;
    using DistanceService;

    public class DitanceCalculatorClient
    {
        public static void Main(string[] args)
        {
            var service = new DistanceServiceClient();
            var startPoint = new Point {x = 10, y = 10};
            var endPoint = new Point {x = 15, y = 15};
            var distance = service.CalcDistance(startPoint, endPoint);
            Console.WriteLine(distance);
        }
    }
}
