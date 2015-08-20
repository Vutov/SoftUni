namespace BookShop.WebServices.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using BookShop.Models;

    public class AuthorViewModel
    {
        public class AuthorBooksViewModel
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public IEnumerable<string> BookTitles { get; set; }

            public static Expression<Func<Author, AuthorBooksViewModel>> Create
            {
                get
                {
                    return a => new AuthorBooksViewModel()
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        BookTitles = a.Books.Select(b => b.Title).ToList()
                    };
                }
            }
        }

        public class AuthorInfoViewModel
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public static Expression<Func<Author, AuthorInfoViewModel>> Create
            {
                get
                {
                    return a => new AuthorInfoViewModel()
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                    };
                }
            }
        }
    }
}