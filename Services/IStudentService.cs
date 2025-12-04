using StudentsApi.Models;
using StudentsApi.Models.DTOs;

namespace StudentsApi.Services
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentInfoDTO>> GetAllStudents();
        public Task<Student?> GetStudentById(Guid id);
        public Task<Student> CreateStudent(CreateStudentDTO student);
        public Task<Student?> UpdateStudent(Guid id, CreateStudentDTO updateStudent);
        public Task<Student?> DeleteStudent(Guid id);
    }
}
