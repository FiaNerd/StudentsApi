using Microsoft.EntityFrameworkCore;
using StudentsApi.Persistence;

namespace StudentsApi.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.OrderBy(course => course.Title).ToListAsync();
        }

        public async Task<Course?> GetCourseById(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            return course;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            try
            {
                var result = await _context.Courses.AddAsync(course);

                var saveResult = await _context.SaveChangesAsync();

                if(saveResult > 0)
                {
                    return result.Entity;
                }
                else
                {
                    throw new Exception("Failed to save the course to the database.");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Course?> UpdateCourse(Guid id, Course courseToUpdate)
        {
            try
            {
                var updateCourse = await _context.Courses.FindAsync(id);

                if (updateCourse == null)
                {
                    return null;
                }

                _context.Entry(updateCourse).CurrentValues.SetValues(courseToUpdate);

                await _context.SaveChangesAsync();

                return updateCourse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Course?> DeleteCourse(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course is not null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return course;
            }

            throw new ArgumentException("Course not found", nameof(id));
        }
    }
}
