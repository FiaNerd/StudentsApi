using StudentsApi.Models;
using StudentsApi.Models.DTOs;

namespace StudentsApi.Repositories
{
    public interface ICourseInstanceRepository
    {
        Task<IEnumerable<CourseInstance>> GetAllCourseInstances();
        Task<CourseInstance?> GetCourseInstanceById(Guid id);
        Task<CourseInstance> CreateCourseInstance(CourseInstance courseInstance);
    }
}
