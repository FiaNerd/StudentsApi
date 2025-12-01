using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public class CreateCourseDTO
    {
        [Required]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Title has to have at least 2 characters and can not be longer then 80 char" )]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public ICollection<CourseInstanceDTO> CourseInstances { get; set; } = new List<CourseInstanceDTO>();
    }
}
