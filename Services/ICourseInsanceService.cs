using StudentsApi.Models.DTOs;

namespace StudentsApi.Services
{
    public interface ICourseInsanceService
    {
        public Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstances();
    }
}
