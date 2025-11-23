using StudentsApi.Models;
using StudentsApi.Persistence;
using System.Data;

namespace StudentsApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            _context.Database.EnsureCreated();

            return _context.Students.OrderBy(student => student.Name).ToList();
        }

        public async Task<Student?> GetStudentById(Guid id)
        {
            _context.Database.EnsureCreated();

            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            try
            {
                var result = await _context.Students.AddAsync(student);

                var saveResult = await _context.SaveChangesAsync();

                if (saveResult > 0)
                {
                    return result.Entity;
                }
                else
                {
                    throw new Exception("Failed to save the student to the database.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the student.", ex);
            }
        }

        public async Task<Student?> UpdateStudent(Guid id, Student updateStudent)
        {
            try
            {
                var existingStudent = await _context.Students.FindAsync(id);

                if (existingStudent == null)
                {
                    throw new Exception($"Student not found with {id}.");
                }

                _context.Entry(existingStudent).CurrentValues.SetValues(updateStudent);

                await _context.SaveChangesAsync();

                return existingStudent;
            }
            catch
            {
                throw;
            }
        }

        //public Student DeleteStudent(Guid id)
        //{
        //    try
        //    {
        //        var student = students.FirstOrDefault(s => s.Id == id);

        //        if (student is not null)
        //        {
        //            students.Remove(student);
        //        }

        //        return student!;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
