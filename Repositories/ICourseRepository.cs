using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface ICourseRepository
    {
        public Course GetAllCourses();
        public Course GetCoursesById(Guid id);
    }
}
