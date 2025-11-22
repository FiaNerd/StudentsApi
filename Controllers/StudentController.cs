using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models;
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
        public ActionResult<Student> GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student?>> GetStudentById(Guid id)
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
        public ActionResult<Student> CreateStudent([FromBody] CreateStudentRequest studentRequest)
        {
            try
            {
                var createdStudent = _studentService.CreateStudent(studentRequest);

                return Created($"api/student/{createdStudent.Id}", createdStudent);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        //[HttpPut("{id}")]
        //public ActionResult<Student> UpdateStudent(Guid id, [FromBody] CreateStudentRequest studentRequest)
        //{
        //    try
        //    {
        //        var updatedStudent = _studentService.UpdateStudent(id, studentRequest);

        //        if(updatedStudent == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(updatedStudent);
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}
    }
}
