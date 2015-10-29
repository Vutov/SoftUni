namespace Restaurants.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Rating> givenRatings;

        public ApplicationUser()
        {
            this.givenRatings = new HashSet<Rating>();
        }

        public virtual ICollection<Rating> GivenRatings
        {
            get { return this.givenRatings; }
            set { this.givenRatings = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            return await manager.CreateIdentityAsync(this, authenticationType);
        }
    }
}
