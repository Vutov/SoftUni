namespace Restaurants.Services.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.DataLayer;
    using Infrastructure;

    public class BaseController : ApiController
    {
        public BaseController(IRestaurantData data, IUserIdProvider idProvider)
        {
            this.Data = data;
            this.UserIdProvider = idProvider;
        }

        public BaseController()
            : this(new RestaurantData(new RestaurantsContext()), new AspNetUserIdProvider())
        {
        }

        protected IRestaurantData Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }
    }
}
