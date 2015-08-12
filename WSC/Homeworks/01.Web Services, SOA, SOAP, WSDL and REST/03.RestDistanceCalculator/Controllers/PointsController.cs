namespace _03.RestDistanceCalculator.Controllers
{
    using System;
    using System.Web.Http;

    public class PointsController : ApiController
    {
        // [HttpGet] if service is called just Distance without 'Get'.
        public IHttpActionResult GetDistance(int startX, int startY, int endX, int endY)
        {
            double deltaX = startX - endX;
            double deltaY = startY - endY;

            var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return this.Ok(distance);
        }
    }
}
