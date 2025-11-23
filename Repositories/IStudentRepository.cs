using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();
        public Task<Student?> GetStudentById(Guid id);
        public Task<Student> CreateStudent(Student student);
        public Task<Student?> UpdateStudent(Guid id, Student updateStudent);
        //public Student? DeleteStudent(Guid id);
    }
}