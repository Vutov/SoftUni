namespace Restaurants.Services.Infrastructure
{
    using System.Threading;
    using Microsoft.AspNet.Identity;

    public class AspNetUserIdProvider: IUserIdProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}