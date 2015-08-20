namespace BookShop.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models.ViewModels;

    [RoutePrefix("api/User")]
    public class UserController : BaseController
    {
        [Route("{username}/purchases")]
        public IHttpActionResult GetPurchsesForUser(string username)
        {
            var purchases = this.Data.Purchase.Find(p => p.ApplicationUser.UserName == username);

            if (purchases == null)
            {
                return this.BadRequest("No purchases for this user");
            }

            var userPurchasesView = purchases.Select(UsersPurchasesViewModel.Create).OrderBy(p => p.DateOfPurchase);
            return this.Ok(userPurchasesView);
        }
    }
}
