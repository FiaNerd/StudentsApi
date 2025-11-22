using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public class CourseInstanceRepository : ICourseInstanceRepository
    {
        //private readonly List<CourseInstance> _courseInstances;

        public CourseInstanceRepository()
        {
            //var studentRepo = new StudentRepository();
            //    var courseRepo = new CourseRepository();

            //    var students = studentRepo.GetAllStudents().ToList();
            //    var courses = courseRepo.GetAllCourses().ToList(); 

            //    _courseInstances = new List<CourseInstance>
            //    {
            //        new CourseInstance(
            //            new DateTime(2025, 1, 10),
            //            new DateTime(2025, 3, 20),
            //            courses[0],
            //            new List<Student> { students[0], students[1] }
            //        ),
            //        new CourseInstance(
            //            new DateTime(2025, 4, 1),
            //            new DateTime(2025, 6, 15),
            //            courses[1], 
            //            new List<Student> { students[1] }
            //        )
            //    };
            //}

            //public IEnumerable<CourseInstance> GetAllCourseInstance()
            //{
            //    return _courseInstances;
            //}

            //public IEnumerable<CourseInstance> GetCoursesByStudent(Guid studentId)
            //{
            //    Console.WriteLine(studentId);
            //    return _courseInstances
            //        .Where(ci => ci.Students.Any(s => s.Id == studentId));
            //}
        }
        }
    }