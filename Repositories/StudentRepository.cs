using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public class StudentRepository
    {
        List<Student> students = new()
            {
                new Student("Alice", "no@mail.com"),
                new Student("Bob", "mail@nomail.com"),
                new Student("Charlie", "nomail@nomail.com")
            };

        public IEnumerable<Student> GetAllStudents()
        {
            // Implementation to retrieve all students from the data source
            return students;
        }

        public Student? GetStudentById(Guid id)
        { 
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
