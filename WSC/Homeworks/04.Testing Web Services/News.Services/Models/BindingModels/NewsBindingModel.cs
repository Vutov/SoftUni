using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class NewsBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}