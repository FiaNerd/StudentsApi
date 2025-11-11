using StudentsApi.Models;
using System.Data;

namespace StudentsApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> students = new()
                {
                    new Student("Alice", "no@mail.com"),
                    new Student("Bob", "mail@nomail.com"),
                    new Student("Charlie", "nomail@nomail.com")
                };

        public IEnumerable<Student> GetAllStudents()
        {
            return students.OrderBy(student => student.Name).ToList();
        }

        public Student? GetStudentById(Guid id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
        public bool CreateStudent(Student student)
        {
            try
            {
                students.Add(student);

                return true;
            }
            catch
            {

                throw;
            }
        }
        public Student UpdateStudent(Guid id, Student updateStudent)
        {
            try
            {
                var student = students.FirstOrDefault(s => s.Id == id);

                if (student is not null)
                { 
                    student.Name = updateStudent.Name;
                    student.Email = updateStudent.Email;
                }

                return student!;
            }
            catch 
            {

                throw;
            }
        }

        public Student DeleteStudent(Guid id)
        {
            try
            {
                var student = students.FirstOrDefault(s => s.Id == id);

                if (student is not null)
                {
                    students.Remove(student);
                }

                return student!;
            }
            catch
            {
                throw;
            }
        }
    }
}
