using StudentsApi.Models;
using StudentsApi.Models.DTOs;

namespace StudentsApi.Repositories
{
    public interface ICourseInstanceRepository
    {
        Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstance();
        //IEnumerable<CourseInstance> GetCoursesByStudent(Guid studentId);
    }
}
