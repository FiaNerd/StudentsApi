using StudentsApi.Models;
using StudentsApi.Models.DTOs;

namespace StudentsApi.Repositories
{
    public interface ICourseInstanceRepository
    {
        Task<IEnumerable<CourseInstance>> GetCourseInstances();
        Task<CourseInstance?> GetCourseInstanceById(Guid id);
        Task<CourseInstance> CreateCourseInstance(CourseInstance courseInstance);
    }
}
