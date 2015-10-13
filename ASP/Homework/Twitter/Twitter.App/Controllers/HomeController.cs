namespace Twitter.App.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models;

    public class HomeController : BaseController
    {
        public ActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                throw new HttpException(400, "Bad Request");
            }

            var tweets = this.Data.Tweets.All()
                .OrderBy(t => t.TimeStamp)
                .Select(TweetViewModel.Create)
                .Skip((page - 1) * 10)
                .Take(10)
                .ToList();
            this.ViewBag.Page = page;

            return View(tweets);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}