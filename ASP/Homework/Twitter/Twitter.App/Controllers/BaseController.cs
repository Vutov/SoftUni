namespace Twitter.App.Controllers
{
    using System.Web.Mvc;
    using Data;
    using Data.Data;

    public class BaseController : Controller
    {
        public BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new TwitterData(new ApplicationDbContext()))
        {
        }

        protected ITwitterData Data { get; set; }
    }
}