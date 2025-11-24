using StudentsApi.Models;

namespace StudentsApi.Services
{
    public interface ICourseService
    {
        public Task<IEnumerable<Course>> GetAllCourses();
        public Task<Course?> GetCourseById(Guid id);
        //public Course CreateCourse(CreateCourseRequest course);
        //public Course UpdateCourse(Guid id, CreateCourseRequest course);
        //public Course DeleteCourse(Guid id);
    }
}
