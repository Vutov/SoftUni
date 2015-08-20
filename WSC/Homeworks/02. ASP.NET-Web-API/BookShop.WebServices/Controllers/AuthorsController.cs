namespace BookShop.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BookShop.Models;
    using Microsoft.Ajax.Utilities;
    using Models;
    using Models.ViewModels;

    [RoutePrefix("api/Authors")]
    public class AuthorsController : BaseController
    {
        public IHttpActionResult GetAuthorById(int id)
        {
            var author = this.Data.Authors.Find(a => a.Id == id);

            if (author == null)
            {
                return this.NotFound();
            }

            var authorView = author.Select(AuthorViewModel.AuthorInfoViewModel.Create);

            return this.Ok(authorView);
        }

        [Route("{id}/books")]
        public IHttpActionResult GetBooksForAuthorById(int id)
        {
            var author = this.Data.Authors.Find(a => a.Id == id);

            if (author == null)
            {
                return this.NotFound();
            }

            var authorView = author.Select(AuthorViewModel.AuthorBooksViewModel.Create);

            return this.Ok(authorView);
        }

        [Authorize]
        public IHttpActionResult PostAuthor([FromBody] AuthorBindingMethod model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var author = new Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            this.Data.Authors.Add(author);
            this.Data.SaveChanges();

            var authorView = new AuthorViewModel.AuthorInfoViewModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            return this.Ok(authorView);
        }
    }
}
