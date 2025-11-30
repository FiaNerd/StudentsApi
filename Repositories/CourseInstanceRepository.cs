using StudentsApi.Models;
using StudentsApi.Persistence;
using System.Security.Cryptography.X509Certificates;

namespace StudentsApi.Repositories
{
    public class CourseInstanceRepository : ICourseInstanceRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseInstanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseInstance>> GetAllCourseInstance()
        {
            return await _context.CourseInstances.ToListAsync();
        }
    }