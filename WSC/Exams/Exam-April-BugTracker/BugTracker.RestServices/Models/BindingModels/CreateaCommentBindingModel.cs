namespace BugTracker.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateaCommentBindingModel
    {
        [Required]
        public string Text { get; set; }
    }
}