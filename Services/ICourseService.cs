using StudentsApi.Models.DTOs;

namespace StudentsApi.Services
{
    public interface ICourseService
    {
        public Task<IEnumerable<CourseDTO>> GetAllCourses();
        public Task<Course?> GetCourseById(Guid id);
        public Task<Course> CreateCourse(CreateCourseDTO course);
        public Task<Course?> UpdateCourse(Guid id, CreateCourseDTO course);
        public Task<Course?> DeleteCourse(Guid id);
    }
}
