using System.ComponentModel.DataAnnotations;

namespace StudentsApi.Models
{
    public class Student (string name, string email)
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = name;

        [Required]
        public string Email { get; set; } = email;
    }
}
