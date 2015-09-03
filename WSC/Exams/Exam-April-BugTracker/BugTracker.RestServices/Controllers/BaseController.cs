namespace BugTracker.RestServices.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.DataLayer;

    public class BaseController : ApiController
    {
        public BaseController()
            : this(new BugTrackerData(new BugTrackerDbContext()))
        {
        }

        public BaseController(IBugTrackerData data)
        {
            this.Data = data;
        }

        public IBugTrackerData Data { get; set; }
    }
}
