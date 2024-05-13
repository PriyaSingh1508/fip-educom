using AutoMapper;
using Edu.BLL.Admin;
using Edu.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Edu.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdminsAsync()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminByIdAsync(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return NotFound($"Admin with ID {id} not found");
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminAsync([FromBody] AdminDTO adminDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _adminService.CreateAdminAsync(adminDTO);

            return Ok(new { message="added successfully", admin=adminDTO});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdminAsync(int id, [FromBody] AdminDTO adminDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _adminService.UpdateAdminAsync(id, adminDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminAsync(int id)
        {
            await _adminService.DeleteAdminAsync(id);
            return NoContent();
        }
    }
}
