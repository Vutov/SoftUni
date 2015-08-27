namespace OnlineShop.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Ad> ownAds;

        public ApplicationUser()
        {
            this.ownAds = new HashSet<Ad>();
        }

        public ICollection<Ad> OwnAds
        {
            get { return this.ownAds; }
            set { this.ownAds = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(
                this, 
                authenticationType);

            return userIdentity;
        }
    }
}
