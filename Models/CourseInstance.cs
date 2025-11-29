namespace StudentsApi.Models;

public class CourseInstance(DateTime startDate, DateTime endDate, Course course /* List<Student> students*/)
{
    public Guid Id { get; } = Guid.NewGuid();

    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
    public Course Course { get; set; } = course;

    //public List<Student> Students { get; set; } = students;
}