using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public class StudentWithCourseInstanceDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Your name needs to be at least 2 char")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid Email!")]
        public string Email { get; set; } = string.Empty;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<CourseInstanceDTO> CourseInstances { get; set; } = new List<CourseInstanceDTO>();
    }
}
