using StudentsApi.Models;
using StudentsApi.Models.DTOs;

namespace StudentsApi.Repositories
{
    public interface ICourseInstanceRepository
    {
        Task<IEnumerable<CourseInstance>> GetAllCourseInstances();
        Task<CourseInstance> CreateCourseInstance(CourseInstance courseInstance);
    }
}
