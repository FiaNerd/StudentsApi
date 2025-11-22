using StudentsApi.Models;

namespace StudentsApi.Repositories
{
    public interface ICourseInstanceRepository
    {   
        IEnumerable<CourseInstance> GetAllCourseInstance();
        IEnumerable<CourseInstance> GetCoursesByStudent(Guid studentId);
    }
}
