using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAllStudents();
        public Student? GetStudentById(Guid id);
        public bool CreateStudent(Student student);
        public Student UpdateStudent(Guid id, Student updateStudent);
    }
}
