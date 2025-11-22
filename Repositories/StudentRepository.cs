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
        //public bool CreateStudent(Student student)
        //{
        //    try
        //    {
        //        students.Add(student);

        //        return true;
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}
        //public Student UpdateStudent(Guid id, Student updateStudent)
        //{
        //    try
        //    {
        //        var student = students.FirstOrDefault(s => s.Id == id);

        //        if (student is not null)
        //        { 
        //            student.Name = updateStudent.Name;
        //            student.Email = updateStudent.Email;
        //        }

        //        return student!;
        //    }
        //    catch 
        //    {

        //        throw;
        //    }
        //}

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
