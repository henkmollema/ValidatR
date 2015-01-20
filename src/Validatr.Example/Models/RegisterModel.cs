using System.ComponentModel.DataAnnotations;

namespace Validatr.Example.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "A username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A password is required.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Password confirmation is required.")]
        [Compare("Password", ErrorMessage = "The provided passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "An email address is required.")]
        [EmailAddress(ErrorMessage = "The provided email address is not valid.")]
        public string Email { get; set; }
    }
}
