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
        public async Task<ActionResult<Course>> GetAllCourses()
        {
            var courses = await _service.GetAllCourses();
         
            return  Ok(courses);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Course?>> GetCourseById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest($"The id: {id} is not valid");
                }

                var courseById = await _service.GetCourseById(id);

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

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCoure([FromBody] CreateCourseRequest courseRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                var addCourse = await _service.CreateCourse(courseRequest);

                return Created($"/api/course/{addCourse.Id}", addCourse);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, couldn`t create a new course", ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(Guid id, [FromBody] CreateCourseRequest courseRequest)
        {
            try
            {
                var updateCouse = await _service.UpdateCourse(id, courseRequest);

                if (updateCouse == null)
                {
                    return NotFound("Couldn't find the course");
                }

                return Ok(updateCouse);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(Guid id)
        {
            try
            {
                var courseDelete = await _service.DeleteCourse(id);

                if (courseDelete == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception("Could delete the course", ex);
            }
        }
    }
}
