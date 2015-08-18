namespace BookShop.WebServices.Controllers
{
    using System.Web.Http;
    using System.Linq;
    using System.Web.OData;
    using BookShop.Models;
    using Data;
    using Models;
    using Models.ViewModels;

    [RoutePrefix("api/Authors")]
    public class AuthorsController : ApiController
    {
        public IHttpActionResult GetAuthorById(int id)
        {
            var context = new BookShopContext();
            var author = context.Authors
                .Select(a => new
                {
                    a.Id,
                    a.FirstName,
                    a.LastName,
                    BookTitles = a.Books.Select(b => b.Title)
                })
                .FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                return this.NotFound();
            }

            var authorView = new AuthorViewModel.AuthorBooksViewModel()
            {
                FirstName = author.FirstName,
                LastName = author.FirstName,
                BookTitles = author.BookTitles
            };
            return this.Ok(authorView);
        }

        [Route("{id}/books")]
        public IHttpActionResult GetBooksForAuthorById(int id)
        {
            var context = new BookShopContext();
            var author = context.Authors
                .Select(a => new
                {
                    a.Id,
                    Books = a.Books.Select(b => new
                    {
                        b.Title,
                        Author = b.Author.FirstName + " " + b.Author.LastName,
                        b.AgeRestriction,
                        b.Copies,
                        b.EditionType,
                        b.Decription,
                        b.Price,
                        b.ReleaseDate,
                        Categories = b.Categories.Select(c => c.Name)
                    })
                })
                .FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                return this.NotFound();
            }

            return this.Ok(author);
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

            var context = new BookShopContext();
            context.Authors.Add(author);
            context.SaveChanges();

            var authorView = new AuthorViewModel.AuthorInfoViewModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            return this.Ok(authorView);
        }
    }
}
