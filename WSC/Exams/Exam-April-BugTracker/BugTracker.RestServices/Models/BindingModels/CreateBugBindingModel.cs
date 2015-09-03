namespace BugTracker.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateBugBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}