using Microsoft.EntityFrameworkCore;
using StudentsApi.Models;
using StudentsApi.Persistence;

namespace StudentsApi.Repositories
{
    public class CourseInstanceRepository : ICourseInstanceRepository
    {
        private readonly ApplicationDbContext _context;

            public CourseInstanceRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<CourseInstance>> GetAllCourseInstances()
            {
                return await _context.CourseInstances.ToListAsync();
            }
        }
    }