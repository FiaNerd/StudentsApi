using Microsoft.EntityFrameworkCore;
using StudentsApi.Models;
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
            _context.Database.EnsureCreated();
            return await _context.Courses.OrderBy(course => course.Title).ToListAsync();
        }

        public async Task<Course?> GetCourseById(Guid id)
        {
            _context.Database.EnsureCreated();
            var course = await _context.Courses.FindAsync(id);
            return course;
        }

        //public bool CreateCourse(Course course)
        //{
        //    try
        //    {
        //          courses.Add(course);

        //        return true;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public Course UpdateCourse(Guid id, Course courseRepo)
        //{
        //    try
        //    {
        //        var updateCourse = courses.FirstOrDefault(c => c.Id == id);

        //        if (updateCourse is not null)
        //        {
        //            updateCourse.Title = courseRepo.Title;
        //            updateCourse.Description = courseRepo.Description;
        //        }

        //        return updateCourse!;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public Course DeleteCourse(Guid id)
        //{
        //    var course = courses.FirstOrDefault(c => c.Id == id);

        //    if (course is not null)
        //    { 
        //        courses.Remove(course);
        //    }

        //    return course!;
        //}
    }
}
