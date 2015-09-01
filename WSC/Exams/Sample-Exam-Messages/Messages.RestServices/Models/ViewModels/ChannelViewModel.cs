using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages.RestServices.Models.ViewModels
{
    using System.Linq.Expressions;
    using Data.Models;

    public class ChannelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Channel, ChannelViewModel>> Create
        {
            get
            {
                return c => new ChannelViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                };
            }
        }
    }
}