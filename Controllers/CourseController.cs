using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models.DTOs;
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
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            var courses = await _service.GetAllCourses();
         
            return  Ok(courses);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CourseDTO?>> GetCourseById(Guid id)
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
        public async Task<ActionResult<CourseDTO>> CreateCoure([FromBody] CreateCourseDTO courseRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                CourseDTO newCourse = await _service.CreateCourse(courseRequest);

                //return Created($"/api/course/{addCourse.Id}", addCourse);

                return CreatedAtAction(nameof(GetCourseById), new { id = newCourse.Id }, newCourse);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, couldn`t create a new course", ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<CourseDTO>> UpdateCourse(Guid id, [FromBody] UpdateCourseDTO updateRequest)
        {
            try
            {
                var updateCouse = await _service.UpdateCourse(id, updateRequest);

                if (updateCouse == null)
                {
                    return NotFound("Couldn't find the course");
                }

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            try
            {
                 await _service.DeleteCourse(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not delete the course", ex);
            }
        }
    }
}
