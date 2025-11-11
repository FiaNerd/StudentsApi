using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAllStudents();
        public Student? GetStudentById(Guid id);
        public Student CreateStudent(CreateStudentRequest student);
        public Student UpdateStudent(Guid id, CreateStudentRequest updateStudent);
        public Student DeleteStudent(Guid id);
    }
}
