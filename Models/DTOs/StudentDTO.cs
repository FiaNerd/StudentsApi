using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentsApi.Models.DTOs
{
    public class StudentDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Your name needs to be at least 2 char")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid Email!")]
        public string Email { get; set; } = string.Empty;
    }
}
