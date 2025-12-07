using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsApi.Models;
using StudentsApi.Models.DTOs;
using StudentsApi.Persistence;
using StudentsApi.Services;

namespace StudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<StudentDTO>> GetAllStudents()
        {

            var getStudents = await _studentService.GetAllStudents();

            return Ok(getStudents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO?>> GetStudentById(Guid id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] CreateStudentDTO studentRequest)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return ValidationProblem(ModelState);
                }

                var createdStudent = await _studentService.CreateStudent(studentRequest);

                return Created($"api/student/{createdStudent.Id}", createdStudent);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDTO?>> UpdateStudent(Guid id, [FromBody] CreateStudentDTO studentRequest)
        {
            try
            {
                var updatedStudent = await _studentService.UpdateStudent(id, studentRequest);

                if (updatedStudent == null)
                {
                    return NotFound($"Can not find the student with id {id}");
                }

                return NoContent();
            }
            catch
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                var deletedStudent = await _studentService.DeleteStudent(id);

                if (deletedStudent == null)
                {
                    return NotFound($"Can not find the student with id {id}");
                }

                return NoContent();
            }
            catch
            {
                throw;
            }
        }

        //[HttpGet("debug")]
        //public async Task<ActionResult> DebugEndpoint([FromServices] ApplicationDbContext context)
        //{
        //    var data = await context.Students
        //        .Include(s => s.CourseInstances)
        //            .ThenInclude(ci => ci.Course)
        //        .ToListAsync();

        //    return Ok(data);
        //}
    }
}
