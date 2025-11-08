using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAllStudents();
        public Student? GetStudentById(Guid id);
    }
}
