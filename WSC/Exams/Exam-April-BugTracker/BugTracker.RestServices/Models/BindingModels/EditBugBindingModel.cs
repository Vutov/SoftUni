using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditBugBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}