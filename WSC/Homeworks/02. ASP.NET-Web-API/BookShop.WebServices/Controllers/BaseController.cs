namespace BookShop.WebServices.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.Data;

    public class BaseController : ApiController
    {
        public BaseController(IBookShopData bookShopData)
        {
            this.Data = bookShopData;
        }

        public BaseController()
            : this(new BookShopData(new BookShopContext()))
        {

        }

        protected IBookShopData Data { get; set; }
    }
}
