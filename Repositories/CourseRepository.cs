using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly List<Course> courses = new()
   {
         new Course("Mathematics", "An introduction to mathematical concepts."),
         new Course("History", "A study of historical events and figures."),
         new Course("Biology", "Exploring the science of life and living organisms.")
   };
    public IEnumerable<Course> GetAllCourses()
        {
            return courses.OrderBy(course => course.Title).ToList();
        }

        public Course GetCourseById(Guid id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            return course!;
        }
    }
}
