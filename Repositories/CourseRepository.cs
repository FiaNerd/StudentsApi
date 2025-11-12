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

        public Course? GetCourseById(Guid id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            return course!;
        }

        public bool CreateCourse(Course course)
        {
            try
            {
                  courses.Add(course);

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Course UpdateCourse(Guid id, Course courseRepo)
        {
            try
            {
                var updateCourse = courses.FirstOrDefault(c => c.Id == id);

                if (updateCourse is not null)
                {
                    updateCourse.Title = courseRepo.Title;
                    updateCourse.Description = courseRepo.Description;
                }

                return updateCourse!;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
