using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models.DTOs;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseInstanceDTO?>> GetCourseInstanceById(Guid id)
        {
            try
            {
                var courseInstance = await _service.GetCourseInstanceById(id);

                return Ok(courseInstance);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<CourseInstanceDTO>> CreateCourseInstance([FromBody] CreateCourseInstanceDTO createCourseInstanceDTO)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                var result = await _service.CreateCourseInstance(createCourseInstanceDTO);

                return CreatedAtAction(nameof(GetCourseInstanceById), new { id = createCourseInstanceDTO.CourseId }, result);
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("already exist"))
                {
                    return Conflict(new { message = ex.Message });
                }

                return BadRequest(new { message = ex.Message });
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
