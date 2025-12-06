using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public class EnrollStudentDTO
    {
        [Required]
        public Guid StudentId { get; set; } 

        [Required]
        public Guid CourseInstanceId { get; set; }
    }
}
