using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface IStudentService1
    {
        IEnumerable<Student> GetAllStudents();
        Student? GetStudentById(Guid id);
    }
}