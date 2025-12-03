using StudentsApi.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models
{
    public class CourseInstanceWithCourseDTO
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        //public CourseDTO Course { get; set; } = null!;
        public ICollection<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }
}
