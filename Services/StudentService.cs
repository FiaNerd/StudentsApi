using Microsoft.AspNetCore.Http.HttpResults;
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
            try
            {
                return _repo.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving students.", ex);
            }
        }

        public Student? GetStudentById(Guid id)
        {
            try
            {
                return _repo.GetStudentById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
