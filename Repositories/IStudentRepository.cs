using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();
        public Student? GetStudentById(Guid id);
        public Student CreateStudent(Student student);
        public Student UpdateStudent(Guid id, Student student);
        public Student DeleteStudent(Guid id);
    }
}