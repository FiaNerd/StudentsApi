using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models;
using StudentsApi.Services;

namespace StudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Course> GetAllCourses()
        {
            return Ok(_service.GetAllCourses());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Course?> GetCourseById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest($"The id: {id} is not valid");
                }

                var courseById = _service.GetCourseById(id);

                if (courseById == null)
                { 
                    return NotFound("Can not find the id");
                }

                return Ok(courseById);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
