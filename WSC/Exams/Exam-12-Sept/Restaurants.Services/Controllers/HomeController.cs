namespace Restaurants.Services.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.Redirect("Help");
        }
    }
}
