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

        [HttpPost]
        public ActionResult<Course> CreateCoure([FromBody] CreateCourseRequest courseRequest)
        {
            try
            {
                var addCourse = _service.CreateCourse(courseRequest);

                if (addCourse == null)
                {
                    return BadRequest();
                }

                return Created($"/api/course/{addCourse.Id}", addCourse);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, couldn`t create a new course", ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Course> UpdateCourse(Guid id, [FromBody] CreateCourseRequest courseRequest)
        {
            try
            {
                var updateCouse = _service.UpdateCourse(id, courseRequest);

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
        public ActionResult<Course> DeleteCourse(Guid id) 
        {
            try
            {
                var courseDelete = _service.DeleteCourse(id);

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
