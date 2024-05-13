using Edu.BLL.Teacher;
using Edu.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Data;

namespace Edu.Services.Controllers
{
    //[Authorize(Roles = ("Teacher"))]
    [Route("teacher")]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherBLL _teacherService;

        public TeacherController(TeacherBLL teacherService)
        {
            _teacherService = teacherService;
           
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDetailsDTO userModel)
        {

            var response = await _teacherService.RegisterTeacher(userModel);

            return Ok(response);
        }
    }
}
