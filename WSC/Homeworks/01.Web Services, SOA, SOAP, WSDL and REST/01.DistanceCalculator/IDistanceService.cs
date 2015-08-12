namespace _01.DistanceCalculator
{
    using System.Drawing;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDistanceService
    {

        [OperationContract]
        double CalcDistance(Point startPoint, Point endPoint);
    }
}
