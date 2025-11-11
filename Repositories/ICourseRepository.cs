using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAllCourses();
        public Course GetCourseById(Guid id);
    }
}
