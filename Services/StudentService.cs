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

        public async Task<Student?> GetStudentById(Guid id)
        {
            try
            {
                return await _repo.GetStudentById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public Student CreateStudent(CreateStudentRequest studentRequest)
        //{
        //    try {
        //        var newSudent = new Student(
        //            studentRequest.Name,
        //            studentRequest.Email
        //            );

        //        bool isSuccess = _repo.CreateStudent(newSudent);

        //        if(isSuccess)
        //        {
        //            return newSudent;
        //        }

        //        throw new Exception("Failed to create student.");
        //    }
        //    catch 
        //    {
        //        throw;
        //    }
        //}

        //public Student UpdateStudent(Guid id, CreateStudentRequest studentRequest)
        //{
        //    try
        //    {
        //        var updateStudent = new Student(
        //            studentRequest.Name,
        //            studentRequest.Email
        //            );

        //        var isStudentUpdated = _repo.UpdateStudent(id, updateStudent);

        //       if (isStudentUpdated is not null)
        //        {
        //            return isStudentUpdated;
        //        }

        //        throw new Exception("Failed to update student.");
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        //public Student DeleteStudent(Guid id)
        //{
        //    var deletedStudent = _repo.DeleteStudent(id);

        //    return deletedStudent;
        //}
    }
}
