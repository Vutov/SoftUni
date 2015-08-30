namespace OnlineShop.Services.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.Data;

    public class BaseController : ApiController
    {
        public BaseController()
            : this(new OnlineShopData(new OnlineShopContext()))
        {
        }

        public BaseController(IOnlineShopData data)
        {
            this.Data = data;
        }

        protected IOnlineShopData Data { get; set; }
    }
}
