namespace OnlineShop.Services.Models.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using OnlineShop.Models;


    public class AdViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public OwnerViewModel Owner { get; set; }

        public AdTypeViewModel Type { get; set; }

        public DateTime PostDateTime { get; set; }

        public IEnumerable<CategoryViewModel> Category { get; set; }

        public static Expression<Func<Ad, AdViewModel>> Create
        {
            get
            {
                return a => new AdViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Owner = new OwnerViewModel()
                    {
                        Id = a.OwnerId,
                        Username = a.Owner.UserName
                    },
                    Type = new AdTypeViewModel() { Type = a.Type.Name },
                    PostDateTime = a.PostedOn,
                    Category = a.Categories.Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                };
            }
        }
    }
}