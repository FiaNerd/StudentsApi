using AutoMapper;
using StudentsApi.Models;
using StudentsApi.Models.DTOs;
using StudentsApi.Repositories;

namespace StudentsApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repo, IMapper mapper)
        {
             _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            try
            {
                var students = await _repo.GetAllStudents();

                return _mapper.Map<IEnumerable<StudentDTO>>(students);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving students.", ex);
            }
        }

        public async Task<StudentDTO?> GetStudentById(Guid id)
        {
            try
            {
                var student = await _repo.GetStudentById(id);
                return _mapper.Map<StudentDTO?>(student);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<StudentDTO> CreateStudent(CreateStudentDTO studentRequest)
        {
            try
            {
                var newSudent = new Student(
                    studentRequest.Name,
                    studentRequest.Email
                    );

                var isSuccess = await _repo.CreateStudent(newSudent);

                if (isSuccess is not null) 
                {
                    return _mapper.Map<StudentDTO>(isSuccess);
                }

                    throw new Exception("Failed to create student.");
            }
            catch
            {
                throw;
            }
        }

        public async Task<StudentDTO?> UpdateStudent(Guid id, CreateStudentDTO studentRequest)
        {
            try
            {
                var updateStudent = new Student(
                    studentRequest.Name,
                    studentRequest.Email
                    )
                { 
                    Id = id
                };

                var isStudentUpdated = await _repo.UpdateStudent(id, updateStudent);

                if (isStudentUpdated is not null)
                {
                    return _mapper.Map<StudentDTO>(isStudentUpdated);
                }

                throw new Exception("Failed to update student.");
            }
            catch
            {

                throw;
            }
        }

        public async Task<StudentDTO?> DeleteStudent(Guid id)
        {
            try
            {
                var deletedStudent = await _repo.DeleteStudent(id);

                if (deletedStudent is null)
                {
                    return null;
                }

                return _mapper.Map<StudentDTO>(deletedStudent);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
