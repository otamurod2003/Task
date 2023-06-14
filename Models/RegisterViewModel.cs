using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class RegisterViewModel
    {
     
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        [Display(Name ="Email")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
       
        [Compare("Password",ErrorMessage="Password and confirmation do not match")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
