using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface ICourseService
    {
        public IEnumerable<Course> GetAllCourses();
        public Course? GetCourseById(Guid id);
        public Course CreateCourse(Course course);
        public Course UpdateCourse(Guid id, Course course);
        public Course DeleteCourse(Guid id);
    }
}
