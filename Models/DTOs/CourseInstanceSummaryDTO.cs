using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public class CourseInstanceSummaryDTO
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}
