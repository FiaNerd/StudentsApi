using Microsoft.EntityFrameworkCore;
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

           
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students
                .Include(s => s.CourseInstances)
                .ThenInclude(ci => ci.Course)
                .OrderBy(student => student.Name).ToListAsync();
        }

        public async Task<Student?> GetStudentById(Guid id)
        {
            return await _context.Students
                .Include(s => s.CourseInstances)
                .ThenInclude(ci => ci.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
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

        public async Task<Student> EnrollStudentInCourseInstance(Guid studentId, Guid courseInstanceId)
        {
           var student =  await _context.Students
                .Include(s => s.CourseInstances)
                .ThenInclude(ci => ci.Course)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
            {
                throw new Exception($"Student not found with {studentId}.");
            }

            var courseInstance = await _context.CourseInstances
                .Include(ci => ci.Course)
                .FirstOrDefaultAsync(ci => ci.Id == courseInstanceId);

            if (courseInstance == null)
            {
                return student;
            }

            if(!student.CourseInstances.Any(ci => ci.Id == courseInstanceId))
            {
                student.CourseInstances.Add(courseInstance);
                await _context.SaveChangesAsync();
            }

            return student;
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

        public async Task<Student?> DeleteStudent(Guid id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student is not null)
                {
                   _context.Students.Remove(student);

                    await _context.SaveChangesAsync();

                    return student!;
                }

                throw new Exception($"Student not found with {id}.");

            }
            catch
            {
                throw;
            }
        }

       
    }
}
