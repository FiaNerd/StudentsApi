using StudentsApi.Models;
using StudentsApi.Repositories;

namespace StudentsApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
             _repo = repo;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _repo.GetAllStudents();
        }

        public Student? GetStudentById(Guid id)
        {
            return _repo.GetStudentById(id);
        }
    }
}
