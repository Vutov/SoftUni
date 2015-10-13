namespace Twitter.App.Models
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class TweetViewModel
    {
        public string UserName { get; set; }

        public string Message { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> Create
        {
            get
            {
                return r => new TweetViewModel()
                {
                    UserName = r.User.UserName,
                    Message = r.Message
                };
            }
        }
    }
}