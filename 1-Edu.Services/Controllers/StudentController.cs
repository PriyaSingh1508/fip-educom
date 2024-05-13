using Edu.BLL.Helper;
using Edu.Shared.DTO;
using Edu.Shared.Interfaces.StudentInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Edu_App.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBLL _studentRepository;
        public StudentController(IStudentBLL studentRepository)
        {
            _studentRepository = studentRepository;

        }
        //[Authorize(Roles = ("Student"))]
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentRepository.GetAllStudents();
               
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

        }
        [HttpGet("GetStudentbyId/{id:int}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            try
            {
                var student = await _studentRepository.GetStudentById(id);
                if (await _studentRepository.NotAvailable(id))//Notavailable fxn
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentDetailDTO student)
        {
            try
            {
                if (student == null)
                {
                    return Ok(student);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }

                var response=await _studentRepository.AddStudent(student);


                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }


        }
        [HttpPut("UpdateStudent/{id:int}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] StudentDetailDTO student)
        {
            try
            {
                if (id != student.Id)
                {
                    return BadRequest("invalid Request");
                }

                if (await _studentRepository.NotAvailable(id))//not availablefxn
                {
                    return NotFound();
                }
                var updatedStudent = await _studentRepository.UpdateStudent(id, student);
                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteStudent/{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            if (await _studentRepository.NotAvailable(id))//not availablefxn
            {
                return NotFound();
            }
            var deletedStudent = await _studentRepository.DeleteStudent(id);
            return Ok(deletedStudent);
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            try
            {
                var userAvailable = _studentRepository.Login(login);
                if (userAvailable == null)
                {
                    return NotFound();
                }
                if (!PasswordHasher.VerifyPassword(login.Password, userAvailable.Password))
                {
                    return Ok("Wrong Password Entered");
                }

                return Ok(userAvailable);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }


        }
    }
}