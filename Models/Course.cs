namespace StudentsApi.Models
{
    public class Course (string title, string description)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
    }
}
