using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]

        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(\+9989)[01]*$", ErrorMessage = "Phone number should start with +9989 and contain only 0 or 1.")]

        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }
    }
}
