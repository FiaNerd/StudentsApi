using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();
        public Student? GetStudentById(Guid id);
        public bool CreateStudent(Student student);
        public Student UpdateStudent(Guid id, Student updateStudent);
        public Student DeleteStudent(Guid id);
    }
}