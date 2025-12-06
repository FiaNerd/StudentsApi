using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public class CreateCourseInstanceDTO
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Guid CourseId { get; set; }

    }
}
