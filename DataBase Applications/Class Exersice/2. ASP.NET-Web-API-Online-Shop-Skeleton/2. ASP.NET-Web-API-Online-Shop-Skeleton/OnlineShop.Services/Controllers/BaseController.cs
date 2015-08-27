namespace OnlineShop.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseController : ApiController
    {
        public BaseController()
            : this(new OnlineShopContext())
        {
        }

        public BaseController(OnlineShopContext data)
        {
            this.Data = data;
        }

        protected OnlineShopContext Data { get; set; }
    }
}
