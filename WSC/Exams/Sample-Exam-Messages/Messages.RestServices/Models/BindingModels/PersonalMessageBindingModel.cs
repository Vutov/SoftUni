namespace Messages.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class PersonalMessageBindingModel
    {
        [Required]
        public string Recipient { get; set; }

        [Required]
        public string Text { get; set; }
    }
}