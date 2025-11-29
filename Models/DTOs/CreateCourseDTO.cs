using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models.DTOs
{
    public struct CreateCourseDTO (string title, string description)
    {
        [Required]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Title has to have at least 2 characters and can not be longer then 80 char" )]
        public string Title { get; set; } = title;

        [Required]
        public string Description { get; set; } = description;
    }
}
