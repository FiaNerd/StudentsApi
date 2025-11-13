using StudentsApi.Models;
using StudentsApi.Repositories;

namespace StudentsApi.Services
{
    public class CourseService : ICourseService
    {
       private readonly ICourseRepository _repo;

        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _repo.GetAllCourses();
        }

        public Course GetCourseById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id must not be empty", nameof(id));
            }

            var course = _repo.GetCourseById(id);

            if (course is null)
            {
                throw new KeyNotFoundException($"Could not find a course with id {id}");
            }

            return course;
        }

        public Course CreateCourse(CreateCourseRequest course)
        {
            var newCourse = new Course(
                course.Title,
                course.Description
                );

            bool success = _repo.CreateCourse(newCourse);

            if (success)
            {
                return newCourse;
            }

            throw new ArgumentException("Sorry couldnt create the course! Try agian!");
        }

        public Course UpdateCourse(Guid id, CreateCourseRequest course)
        {
            if (id == Guid.Empty)
            { 
                throw new ArgumentException("Id must not be empty", nameof(id));
            }

            var existingCourse = _repo.GetCourseById(id);

            if (existingCourse is null)
            {
                throw new KeyNotFoundException($"Course with id {id} not found.");
            }

            var updatedCourse = new Course(
                course.Title, 
                course.Description
             );

            var result = _repo.UpdateCourse(id, updatedCourse);
            if (result is null)
            {
                throw new Exception("Failed to update course.");
            }

            return result;
        }

        public Course DeleteCourse(Guid id)
        {
            var courseDeleted = _repo.DeleteCourse(id);

            if (courseDeleted is null)
            {
                throw new KeyNotFoundException($"Course with {id} could not be found!");
            }

            return courseDeleted;
        }
    }
}
