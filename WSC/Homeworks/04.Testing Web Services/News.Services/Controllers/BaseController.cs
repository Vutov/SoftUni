namespace News.Services.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.DataLayer;

    public class BaseController : ApiController
    {
        public BaseController(INewsData data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new NewsData(new NewsContext()))
        {
        }

        public INewsData Data { get; set; }
    }
}
