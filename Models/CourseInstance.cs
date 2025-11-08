namespace StudentsApi.Models
{
    public class CourseInstance (string title, string description)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
    }
}
