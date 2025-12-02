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
            return await _context.CourseInstances
                .Include(ci => ci.Students)
                .Include(ci => ci.Course)
                .ToListAsync();
        }

        public async Task<CourseInstance?> GetCourseInstanceById(Guid id)
        {
            try
            {
                var courseInstance = await _context.CourseInstances
                    .Include(ci => ci.Students)
                    .ThenInclude(s => s.CourseInstances)
                    .FirstOrDefaultAsync(ci => ci.Id == id);

                return courseInstance;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CourseInstance> CreateCourseInstance(CourseInstance courseInstance)
        {
            try
            {
               var result = _context.CourseInstances.Add(courseInstance);

               var saveCourseInstance =  await _context.SaveChangesAsync();

                if (saveCourseInstance > 0)
                {
                    return result.Entity;
                }

                return courseInstance;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to save the courseinstance to the database.", ex);
            }
        }
    }
}