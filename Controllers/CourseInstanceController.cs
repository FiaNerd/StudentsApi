using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsApi.Models.DTOs;
using StudentsApi.Persistence;
using StudentsApi.Services;

namespace StudentsApi.Controllers
{
    [Route("api/course-instance")]
    [ApiController]
    public class CourseInstanceController : ControllerBase
    {
        private readonly ICourseInstanceService _service;
        public CourseInstanceController(ICourseInstanceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseInstanceDTO>>> GetAllCourseInstances()
        {
            try
            {
                var courseInstances = await _service.GetAllCourseInstances();
            
                return Ok(courseInstances);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[HttpGet("debug")]
        //public async Task<ActionResult> DebugEndpoint([FromServices] ApplicationDbContext context)
        //{
        //   var data = await context.CourseInstances
        //        .Include(ci => ci.Course)
        //        .Include(ci => ci.Students)
        //        .ToListAsync();

        //    return Ok(data);
        //}
    }
}
