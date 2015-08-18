namespace BookShop.WebServices.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Models.ViewModels;

    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [Route("{username}/purchases")]
        public IHttpActionResult GetPurchsesForUser(string username)
        {
            var context = new BookShopContext();
            var purchases = context.Purchases
                .Where(p => p.ApplicationUser.UserName == username)
                .Select(p => new
                {
                    p.ApplicationUser.UserName,
                    p.Book.Title,
                    p.Book.Price,
                    p.DateOfPurchase,
                    p.IsRecalled
                })
                .OrderBy(p => p.DateOfPurchase)
                .ToList();

            if (!purchases.Any())
            {
                return this.BadRequest("No purchases for this user");
            }

            var userPurchasesView = new List<UsersPurchasesViewModel>();
            purchases.ForEach(p => userPurchasesView.Add(new UsersPurchasesViewModel()
            {
                Username = p.UserName,
                BookTitle = p.Title,
                Price = p.Price,
                DateOfPurchase = p.DateOfPurchase,
                IsRecalled = p.IsRecalled
            }));
            return this.Ok(userPurchasesView);
        }
    }
}
