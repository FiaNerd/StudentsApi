using StudentsApi.Models.DTOs;
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

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _repo.GetAllCourses();
        }

        public async Task<Course?> GetCourseById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id must not be empty", nameof(id));
            }

            var course = await _repo.GetCourseById(id);

            if (course is null)
            {
                throw new KeyNotFoundException($"Could not find a course with id {id}");
            }

            return course;
        }

        public async Task<Course> CreateCourse(CreateCourseDTO courseRequest)
        {
            if (string.IsNullOrWhiteSpace(courseRequest.Title))
            { 
                throw new ArgumentException("Course title must not be empty", nameof(courseRequest.Title));
            }

            if(string.IsNullOrWhiteSpace(courseRequest.Description))
            {
                throw new ArgumentException("Course description must not be empty", nameof(courseRequest.Description));
            }

            var newCourse = new Course(
                courseRequest.Title,
                courseRequest.Description
                );

            var isSuccess = await _repo.CreateCourse(newCourse);

            return isSuccess;

        }

        public async Task<Course?> UpdateCourse(Guid id, CreateCourseDTO course)
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
             )
            { 
             Id = id
            };

            var result = await _repo.UpdateCourse(id, updatedCourse);

            if (result is null)
            {
                throw new Exception("Failed to update course.");
            }

            return result;
        }

        public async Task<Course?> DeleteCourse(Guid id)
        {
            var courseDeleted = await _repo.DeleteCourse(id);

            return courseDeleted == null ?
                  throw new InvalidOperationException($"Student with ID {id} could not be deleted because it does not exist.")
                : courseDeleted;
        }
    }
}
