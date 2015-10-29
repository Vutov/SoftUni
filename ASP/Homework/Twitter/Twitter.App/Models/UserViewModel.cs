namespace Twitter.App.Models
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class UserViewModel
    {
        public string UserName { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Create
        {
            get
            {
                return r => new UserViewModel()
                {
                    UserName = r.UserName,
                };
            }
        }
    }
}