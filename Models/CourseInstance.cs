namespace StudentsApi.Models;

public class CourseInstance(DateTime startDate, DateTime endDate)
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;

    // FK
    public Guid CourseId { get; set; }
    // Navigation property
    public Course? Course { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}