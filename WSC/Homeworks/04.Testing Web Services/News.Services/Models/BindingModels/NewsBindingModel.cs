using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Services.Models.BindingModels
{
    public class NewsBindingModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}