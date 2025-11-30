using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface ICourseInstanceRepository
    {
        Task<IEnumerable<CourseInstance>> GetAllCourseInstances();
        //IEnumerable<CourseInstance> GetCoursesByStudent(Guid studentId);
    }
}
