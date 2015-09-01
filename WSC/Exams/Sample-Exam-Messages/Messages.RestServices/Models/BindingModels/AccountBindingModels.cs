using System.ComponentModel.DataAnnotations;

namespace Messages.RestServices.Models
{
    // Models used as parameters to AccountController actions.

    public class UserAccountBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
