using StudentsApi.Models;
using StudentsApi.Models.DTOs;

namespace StudentsApi.Services
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentDTO>> GetAllStudents();
        public Task<StudentDTO?> GetStudentById(Guid id);
        public Task<StudentDTO> CreateStudent(CreateStudentDTO student);
        public Task<StudentDTO?> UpdateStudent(Guid id, CreateStudentDTO updateStudent);
        public Task<StudentDTO?> DeleteStudent(Guid id);
    }
}
