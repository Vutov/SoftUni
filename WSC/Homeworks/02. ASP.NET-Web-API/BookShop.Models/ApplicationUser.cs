namespace BookShop.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<ApplicationUser> applicationUsers;

        public ApplicationUser()
        {
            this.applicationUsers = new HashSet<ApplicationUser>();
        }

        public virtual ICollection<ApplicationUser> ApplicationUsers
        {
            get { return this.applicationUsers; }
            set { this.applicationUsers = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }
    }
}
