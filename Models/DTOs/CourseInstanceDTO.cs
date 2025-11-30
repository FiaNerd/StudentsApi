using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public class CourseInstanceDTO
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
