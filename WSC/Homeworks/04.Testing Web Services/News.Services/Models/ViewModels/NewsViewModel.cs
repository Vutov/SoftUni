namespace News.Services.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using News.Models;

    public class NewsViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishData { get; set; }

        public static Expression<Func<News, NewsViewModel>> Create
        {
            get
            {
                return n => new NewsViewModel()
                {
                    Title = n.Title,
                    Content = n.Content,
                    PublishData = n.PublishDate
                };
            }
        }
    }
}