using Edu.Security;
using Edu.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Edu.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            var response =await _jwtTokenHandler.GenerateJwtToken(request);
            if (response == null)
            {
                return Unauthorized(new { message= "Email or Password is Invalid" , statusCode=401});
            }
            return Ok(response);
        }


    }
}
