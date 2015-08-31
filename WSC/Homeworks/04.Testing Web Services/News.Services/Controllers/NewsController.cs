namespace News.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.DataLayer;
    using Models.BindingModels;
    using Models.ViewModels;
    using News.Models;

    [RoutePrefix("api/news")]
    public class NewsController : BaseController
    {
        public NewsController()
            : base()
        {
        }

        public NewsController(INewsData data)
            : base(data)
        {
        }

        public IHttpActionResult GetAllNews()
        {
            var news = this.Data.News.All()
                .OrderByDescending(n => n.PublishDate)
                .Select(NewsViewModel.Create);

            return this.Ok(news);
        }

        public IHttpActionResult PostNewNews([FromBody] NewsBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Invalid news model");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = new News()
            {
                Content = model.Content,
                Title = model.Title,
                PublishDate = model.PublishDate
            };

            this.Data.News.Add(news);
            this.Data.SaveChanges();

            var newsView = new NewsViewModel()
            {
                Title = news.Title,
                Content = news.Content,
                PublishData = news.PublishDate
            };
            return this.Created(Uri.UriSchemeHttp, newsView);
        }

        public IHttpActionResult PutUpdateNews([FromUri] int id, [FromBody] NewsBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Invalid news model");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = this.Data.News.GetById(id);
            if (news == null)
            {
                return this.BadRequest("No news with id: " + id);
            }

            news.Title = model.Title;
            news.Content = model.Content;
            news.PublishDate = model.PublishDate;

            this.Data.SaveChanges();

            var newNews = this.Data.News.GetById(id);
            var newsView = new NewsViewModel()
            {
                Title = newNews.Title,
                Content = newNews.Content,
                PublishData = newNews.PublishDate
            };
            return this.Ok(newsView);
        }

        public IHttpActionResult DeleteNews(int id)
        {
            var news = this.Data.News.GetById(id);
            if (news == null)
            {
                return this.BadRequest("No news with id: " + id);
            }

            this.Data.News.Delete(news);
            this.Data.SaveChanges();
            return this.Ok();
        }
    }
}
