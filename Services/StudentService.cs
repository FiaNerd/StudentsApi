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
            throw new NotImplementedException();
        }

        public Student? GetStudentById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
