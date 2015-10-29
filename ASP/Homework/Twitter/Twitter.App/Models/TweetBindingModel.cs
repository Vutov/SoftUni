namespace Twitter.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TweetBindingModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Message { get; set; }
    }
}