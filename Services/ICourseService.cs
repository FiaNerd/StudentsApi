using StudentsApi.Models.DTOs;

namespace StudentsApi.Services
{
    public interface ICourseService
    {
        public Task<IEnumerable<CourseDTO>> GetAllCourses();
        public Task<CourseDTO?> GetCourseById(Guid id);
        public Task<CourseDTO> CreateCourse(CreateCourseDTO course);
        public Task<CourseDTO?> UpdateCourse(Guid id, UpdateCourseDTO course);
        public Task DeleteCourse(Guid id);
    }
}
