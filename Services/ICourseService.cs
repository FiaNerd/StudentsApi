using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface ICourseService
    {
        public IEnumerable<Course> GetAllCourses();
        public Course? GetCourseById(Guid id);
        public Course CreateCourse(CreateCourseRequest course);
        public Course UpdateCourse(Guid id, CreateCourseRequest course);
        public Course DeleteCourse(Guid id);
    }
}
