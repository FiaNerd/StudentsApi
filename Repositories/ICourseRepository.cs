using StudentsApi.Models;
using StudentsApi.Services;

namespace StudentsApi.Repositories
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAllCourses();
        public Course? GetCourseById(Guid id);
        public bool CreateCourse(Course course);
        public Course UpdateCourse(Guid id, Course course);
        public Course DeleteCourse(Guid id);
    }
}
