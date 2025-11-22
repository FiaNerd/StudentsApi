using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAllStudents();
        public Task<Student?> GetStudentById(Guid id);
        public Task<Student> CreateStudent(CreateStudentRequest student);
        //public Student? UpdateStudent(Guid id, CreateStudentRequest updateStudent);
        //public Student? DeleteStudent(Guid id);
    }
}
