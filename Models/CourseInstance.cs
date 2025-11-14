namespace StudentsApi.Models
{
    public class CourseInstance (string title, string description, Course course, List<Student> students)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;

        public Course Course { get; set; } = course;
        public List<Student> Students { get; set; } = students;
    }
}
