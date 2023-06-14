using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }
    }
}
