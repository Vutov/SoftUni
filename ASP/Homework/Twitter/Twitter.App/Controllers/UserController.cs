namespace Twitter.App.Controllers
{
    using System.Web.Mvc;

    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return this.View();
        }
    }
}