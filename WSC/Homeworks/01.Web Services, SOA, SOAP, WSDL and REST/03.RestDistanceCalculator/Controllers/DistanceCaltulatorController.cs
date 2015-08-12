// An other way using routing

/*namespace _03.RestDistanceCalculator.Controllers
{
    using System;
    using System.Web.Http;

    public class DistanceCaltulatorController : ApiController
    {
        [Route("api/points/distance")]
        public double GetCalculateDistance(int startX, int startY, int endX, int endY)
        {
            double deltaX = startX - endX;
            double deltaY = startY - endY;

            var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }
}
*/