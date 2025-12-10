using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public class CourseInstanceDTO
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public CourseSummaryDTO Course { get; set; } = null!;
        public ICollection<StudentSummaryDTO> Students { get; set; } = new List<StudentSummaryDTO>();
    }
}