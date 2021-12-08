using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Students.Data;
using Students.Data.Entites;

namespace Students.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentRepository repository, ILogger<StudentController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Get all the Students available 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            try
            {
                return Ok(_repository.GetAllStudents());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get students: {ex}");
                return BadRequest("Failed to get students.");
            }
        }

        /// <summary>
        /// Add a new Student
        /// </summary>
        /// <param name="model">These are your student properties</param>
        /// <returns>StudentID</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Student model)
        {
            try
            {
                _repository.AddEntity(model);
                if (_repository.SaveAll())
                {
                    return Created($"/api/students/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new Student: {ex}");
            }

            return BadRequest("Failed to save new Student update.");
        }

        /// <summary>
        /// Delete a Student
        /// </summary>
        /// <param name="model">These are your student properties</param>
        /// <returns>StudentID</returns>
        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            try
            {
                if (_repository.CheckIfExists(id))
                {
                    _repository.DeleteStudent(id);
                    return Ok("The student deleted");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new Student: {ex}");
            }

            return BadRequest("Failed to locate student for deleting.");
        }
    }
}
