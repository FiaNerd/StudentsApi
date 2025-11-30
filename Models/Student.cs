namespace StudentsApi.Models
{
    public class Student (string name, string email)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;

        public ICollection<CourseInstance> CourseInstances { get; set; } = new List<CourseInstance>();
    }
}
