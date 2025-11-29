using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "The course must have a name")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "The course must have a description")]
        [MinLength(10, ErrorMessage = "The description cannot have less then 10 characters")]
        public string Description { get; set; } = string.Empty;
    }
}
