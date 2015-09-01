namespace Messages.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ChannelBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}