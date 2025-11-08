using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> students = new()
                {
                    new Student("Alice", "no@mail.com"),
                    new Student("Bob", "mail@nomail.com"),
                    new Student("Charlie", "nomail@nomail.com")
                };

        public IEnumerable<Student> GetAllStudents()
        {
            // Fix: Specify the key selector explicitly for OrderBy
            return students.OrderBy(student => student.Name);
        }

        public Student? GetStudentById(Guid id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
