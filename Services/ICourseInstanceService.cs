using StudentsApi.Models.DTOs;

namespace StudentsApi.Services
{
    public interface ICourseInstanceService
    {
        public Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstances();
    }
}
