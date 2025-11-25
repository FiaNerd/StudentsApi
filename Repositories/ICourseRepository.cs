using StudentsApi.Models;
using StudentsApi.Services;

namespace StudentsApi.Repositories
{
    public interface ICourseRepository
    {
        public Task<IEnumerable<Course>> GetAllCourses();
        public Task<Course?> GetCourseById(Guid id);
        public Task<Course> CreateCourse(Course course);
        public Task<Course?> UpdateCourse(Guid id, Course course);
        //public Task<Course?> DeleteCourse(Guid id);
    }
}
