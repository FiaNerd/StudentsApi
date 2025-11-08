using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();
        public Student? GetStudentById(Guid id);
    }
}