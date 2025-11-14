using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface ICourseInstanceRepository
    {
        public IEnumerable<CourseInstance> GetAllCourseInstance();
    }
}
