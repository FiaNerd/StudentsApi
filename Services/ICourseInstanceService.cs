using StudentsApi.Models.DTOs;

namespace StudentsApi.Services
{
    public interface ICourseInstanceService
    {
        public Task<IEnumerable<CourseInstanceDTO>> GetCourseInstances();
        public Task<CourseInstanceDTO?> GetCourseInstanceById(Guid id);
        public Task<CourseInstanceDTO> CreateCourseInstance(CourseInstanceDTO courseInstanceDTO);

    }
}
