namespace StudentsApi.Models;

public class CourseInstance(DateTime startDate, DateTime endDate)
{
    public Guid Id { get; } = Guid.NewGuid();

    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;

    // FK
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
}